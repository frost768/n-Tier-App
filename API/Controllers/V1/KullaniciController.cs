using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.Contracts.V1;
using BusinessLayer.Interfaces;
using Entities;
using LinqKit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.V1
{
    
    [ApiController]
    [Authorize(Roles="Admin,SuperAdmin",
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciRepo _kullaniciRepo;

        public KullaniciController(IKullaniciRepo kullaniciRepo)
        {
            _kullaniciRepo = kullaniciRepo;
        }

        
        
        [HttpGet(ApiRoutes.Kullanicilar.GetAll)]
        public async  Task<List<Kullanici>> GetAll()
        {
            return await _kullaniciRepo.GetAll();
        }



        
        [HttpGet(ApiRoutes.Kullanicilar.Get)]

        public async Task<ActionResult<Kullanici>> Get([FromRoute] int id)
        {
            var kullanici = await _kullaniciRepo.GetByIdAsync(id);

            if (kullanici == null)
            {
                return NotFound();
            }

            return Ok(kullanici);
        }

        [HttpPut(ApiRoutes.Kullanicilar.Update)]
        public bool Update([FromBody] Kullanici kullanici)
        {
            
            return _kullaniciRepo.Update(kullanici); 
        }

  
        [HttpPost(ApiRoutes.Kullanicilar.Create)]
        public async Task<ActionResult<bool>> Create([FromBody]Kullanici kullanici)
        {
            return await _kullaniciRepo.CreateAsync(kullanici);
            
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete(ApiRoutes.Kullanicilar.DeleteId)]
        public bool Delete(int id)
        {
            return  _kullaniciRepo.Delete(id);
        }
        
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost(ApiRoutes.Kullanicilar.Delete)]
        public bool Delete([FromBody] Kullanici entity)
        {
            return _kullaniciRepo.Delete(entity);

        }
        
        [HttpPost(ApiRoutes.Kullanicilar.Filter)]
        public List<Kullanici> Filter([FromBody] Kullanici entity)
        {

            Expression<Func<Kullanici, bool>> predicate = PredicateBuilder.New<Kullanici>(true);
            if(entity.Username!=null) predicate=predicate.And(x => x.Username == entity.Username);
            if(entity.Password!=null) predicate = predicate.And(x => x.Password == entity.Password);
            

            return _kullaniciRepo.Filter(predicate);

        }


    }
}
