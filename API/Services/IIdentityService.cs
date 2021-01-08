using API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string username, string password);
        Task<AuthenticationResult> LoginAsync(string username, string password);

        Task<AuthenticationResult> RefreshTokenAsync(string requestToken, string requestRefreshToken);
    }
}
