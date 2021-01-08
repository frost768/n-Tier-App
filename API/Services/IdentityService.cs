using API.Domain;
using API.Options;
using BusinessLayer.Interfaces;
using Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using API.Helpers;
using System.Threading.Tasks;
using DataAccess;

namespace API.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IKullaniciRepo _kullaniciRepo;
        private readonly JWTSettings _jwtSettings;
        private readonly DBContext _context;
        private readonly TokenValidationParameters _tokenValidationParameters;
        public IdentityService(IKullaniciRepo kullaniciRepo, JWTSettings jwtSettings, DBContext context, TokenValidationParameters tokenValidationParameters)
        {
            _kullaniciRepo = kullaniciRepo;
            _jwtSettings = jwtSettings;
            _context = context;
            _tokenValidationParameters = tokenValidationParameters;
        }
        public async Task<AuthenticationResult> RegisterAsync(string username, string password)
        {
            
            var existingUser = await _kullaniciRepo.FindByName(username);
            if (existingUser!=null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Bu kullanıcı adı daha önce kullanılmış." }
                };
            }
            var newUser = new Kullanici { Username = username, Password = Cipher.Encrypt(password,username) };
            var createdUser = await _kullaniciRepo.CreateAsync(newUser);
            if (!createdUser)
            {
                return new AuthenticationResult
                {
                    Errors = new string[] { "Kullanıcı oluşturulamadı." },
                    Success = false

                };

            }

            return await GenerateUserToken(newUser);

        }
        public async Task<AuthenticationResult> LoginAsync(string username, string password)
        {
            var user = await _kullaniciRepo.FindByName(username);
            if (user==null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Kullanıcı bulunamadı" }
                };
            }
            var passwordCheck = await  _kullaniciRepo.CheckPassword(username, Cipher.Encrypt(username,password));
            if (!passwordCheck)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Parola ya da kullanıcı adı yanlış, lütfen tekrar deneyin." }
                };
            }

            return await GenerateUserToken(user);
        }

        public async Task<AuthenticationResult> RefreshTokenAsync(string requestToken, string requestRefreshToken)
        {
            var validatedToken = GetTokenPrincipal(requestToken);

            if (validatedToken == null)
            {
                return new AuthenticationResult {Errors = new[] {"Invalid Token"}};
            }

            var expiryDateUnix =
                long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            
            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            if (expiryDateTimeUtc > DateTime.UtcNow)
            {
                return new AuthenticationResult {Errors = new[] {"This token hasn't expired yet"}};
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = await _context.RefreshTokens.SingleOrDefaultAsync(x => x.Token == requestRefreshToken);

            if (storedRefreshToken == null)
            {
                return new AuthenticationResult {Errors = new[] {"This refresh token does not exist"}};
            }

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                return new AuthenticationResult {Errors = new[] {"This refresh token has expired"}};
            }

            if (storedRefreshToken.Invalidated)
            {
                return new AuthenticationResult {Errors = new[] {"This refresh token has been invalidated"}};
            }

            if (storedRefreshToken.Used)
            {
                return new AuthenticationResult {Errors = new[] {"This refresh token has been used"}};
            }

            if (storedRefreshToken.JwtId != jti)
            {
                return new AuthenticationResult {Errors = new[] {"This refresh token does not match this JWT"}};
            }

            storedRefreshToken.Used = true;
            _context.RefreshTokens.Update(storedRefreshToken);
            await _context.SaveChangesAsync();

            var user = await _kullaniciRepo.GetByIdAsync(int.Parse(validatedToken.Claims.Single(x => x.Type == "id").Value));
            return await GenerateUserToken(user);
        }

        private ClaimsPrincipal GetTokenPrincipal(string token)
        {
            var tokenHandler= new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                if (!IsJwtWithValidSecurityAlg(validatedToken))
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlg(SecurityToken validatedToken)
        {
            var result =(validatedToken is JwtSecurityToken jwtSecurityToken) &&
                        jwtSecurityToken.Header.Enc.Equals(SecurityAlgorithms.HmacSha256,
                            StringComparison.InvariantCultureIgnoreCase);

            return result;
        }
       

        private async Task<AuthenticationResult> GenerateUserToken(Kullanici user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role.ToString()),

            };
            
            var createdAt = DateTime.UtcNow;
            var expireAt = DateTime.UtcNow.AddMilliseconds(10000);
            
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expireAt,
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = createdAt
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                UserId = user.Id,
                CreationDate = createdAt,
                ExpiryDate = expireAt.AddSeconds(30)
            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
            
            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token
                
            };
        }
      
    }
}
