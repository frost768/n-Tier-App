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
    [Authorize(Roles="SuperAdmin,Admin,Operator",
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class YetkiliController : ControllerBase
    {
        private readonly IYetkiliRepo _yetkiliRepo;

        public YetkiliController(IYetkiliRepo yetkiliRepo)
        {
            _yetkiliRepo = yetkiliRepo;
        }

        
        [HttpGet(ApiRoutes.Yetkililer.GetAll)]
        public  async Task<ActionResult<IEnumerable<Yetkili>>> GetAll()
        {
            return await _yetkiliRepo.GetAll();
        }

       
        [HttpGet(ApiRoutes.Yetkililer.Get)]

        public async Task<ActionResult<Yetkili>> Get([FromRoute] int id)
        {
            var yetkili = await _yetkiliRepo.GetByIdAsync(id);

            if (yetkili == null)
            {
                return NotFound();
            }

            return yetkili;
        }

        [HttpPut(ApiRoutes.Yetkililer.Update)]
        public bool Update([FromBody] Yetkili yetkili)
        {
            
            return  _yetkiliRepo.Update(yetkili); 
        }

        
        [HttpPost(ApiRoutes.Yetkililer.Create)]
        public async Task<bool> Create([FromBody] Yetkili yetkili)
        {
            return await _yetkiliRepo.CreateAsync(yetkili);
            
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route(ApiRoutes.Yetkililer.DeleteId),HttpDelete]
        public bool Delete(int id)
        {
            return  _yetkiliRepo.Delete(id);
    
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPost(ApiRoutes.Yetkililer.Delete)]
        public bool Delete([FromBody] Yetkili entity)
        {
            return _yetkiliRepo.Delete(entity);

        }
        
        [HttpPost(ApiRoutes.Yetkililer.Filter)]
        public List<Yetkili> Filter([FromBody] Yetkili entity)
        {

            Expression<Func<Yetkili, bool>> predicate = PredicateBuilder.New<Yetkili>(true);
            if(entity.Ad!=null) predicate=predicate.And(x => x.Ad == entity.Ad);
            if(entity.E_Posta!=null) predicate = predicate.And(x => x.E_Posta == entity.E_Posta);
            if(entity.Soyad!=null) predicate = predicate.And(x => x.Soyad == entity.Soyad);
            if(entity.Telefon!=null) predicate = predicate.And(x => x.Telefon == entity.Telefon);
       

            return _yetkiliRepo.Filter(predicate);

        }


    }
}
