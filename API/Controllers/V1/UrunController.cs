using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLayer;
using API.Contracts.V1;
using BusinessLayer.Interfaces;
using Entities;
using LinqKit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers.V1
{
    [ApiController]
    [Authorize(Roles="SuperAdmin,Admin,Operator",
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class UrunController : ControllerBase
    {
        private readonly IUrunRepo _urunRepo;

        public UrunController(IUrunRepo urunRepo)
        {
            _urunRepo = urunRepo;
        }

       
        [Route(ApiRoutes.Urunler.GetAll), HttpGet]
        public  async Task<ActionResult<IEnumerable<Urun>>> GetAll()
        {
            return await _urunRepo.GetAll();
        }



        [Route(ApiRoutes.Urunler.Get),HttpGet]

        public async Task<ActionResult<Urun>> Get([FromRoute] int id)
        {
            var urun = await _urunRepo.GetByIdAsync(id);

            if (urun == null)
            {
                return NotFound();
            }

            return urun;
        }

 
        [Route(ApiRoutes.Urunler.Update), HttpPut]
        public bool Update([FromBody] Urun urun)
        {
            
            return  _urunRepo.Update(urun); 
        }

        [Route(ApiRoutes.Urunler.Create),HttpPost]
        public async Task<bool> Create([FromBody]Urun urun)
        {
            return await _urunRepo.CreateAsync(urun);
            
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route(ApiRoutes.Urunler.DeleteId),HttpDelete]
        public bool Delete(int id)
        {
            return  _urunRepo.Delete(id);
    
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route(ApiRoutes.Urunler.Delete), HttpPost]
        public bool Delete([FromBody] Urun entity)
        {
            return _urunRepo.Delete(entity);

        }
        
        [Route(ApiRoutes.Urunler.Filter), HttpPost]
        public List<Urun> Filter([FromBody] Urun entity)
        {

            Expression<Func<Urun, bool>> predicate = PredicateBuilder.New<Urun>(true);
            if(entity.Urun_adi!=null) predicate=predicate.And(x => x.Urun_adi == entity.Urun_adi);
  

            return _urunRepo.Filter(predicate);

        }


    }
}
