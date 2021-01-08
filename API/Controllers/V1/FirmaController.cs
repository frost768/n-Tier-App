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
    [Authorize(Roles="Admin,SuperAdmin,Operator",
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class FirmaController : ControllerBase
    {
        private readonly IFirmaRepo _firmaRepo;
        private readonly IVergiDairesi _vergiDairesiRepo;
        

        public FirmaController(IFirmaRepo firmaRepo, IVergiDairesi vergiDairesiRepo)
        {
            _firmaRepo = firmaRepo;
            _vergiDairesiRepo = vergiDairesiRepo;
        }

        [HttpGet(ApiRoutes.VergiDaireleri.GetAll)]
        public async  Task<List<VergiDairesi>> GetAllVergi()
        {
            return await _vergiDairesiRepo.GetAll();
        }
        
        [HttpGet(ApiRoutes.Firmalar.GetAll)]
        public async  Task<List<Firma>> GetAll()
        {
            return await _firmaRepo.GetAll();
        }



        
        [HttpGet(ApiRoutes.Firmalar.Get)]

        public async Task<ActionResult<Firma>> Get([FromRoute] int id)
        {
            var firma = await _firmaRepo.GetByIdAsync(id);

            if (firma == null)
            {
                return NotFound();
            }

            return Ok(firma);
        }

        [HttpPut(ApiRoutes.Firmalar.Update)]
        public bool Update([FromBody] Firma firma)
        {
            
            return _firmaRepo.Update(firma); 
        }

  
        [HttpPost(ApiRoutes.Firmalar.Create)]
        public async Task<ActionResult<bool>> Create([FromBody]Firma firma)
        {
            return await _firmaRepo.CreateAsync(firma);
            
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpDelete(ApiRoutes.Firmalar.DeleteId)]
        public bool Delete(int id)
        {
            return  _firmaRepo.Delete(id);
        }
        
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPost(ApiRoutes.Firmalar.Delete)]
        public bool Delete([FromBody] Firma entity)
        {
            return _firmaRepo.Delete(entity);

        }
        
        [HttpPost(ApiRoutes.Firmalar.Filter)]
        public List<Firma> Filter([FromBody] Firma entity)
        {

            Expression<Func<Firma, bool>> predicate = PredicateBuilder.New<Firma>(true);
            if(entity.Ad!=null) predicate=predicate.And(x => x.Ad == entity.Ad);
            if(entity.Il!=null) predicate = predicate.And(x => x.Il == entity.Il);
            if(entity.Ilce!=null) predicate = predicate.And(x => x.Ilce == entity.Ilce);
            if(entity.E_posta!=null) predicate = predicate.And(x => x.E_posta == entity.E_posta);
            //if(entity.Id!=0) predicate.Or(x => x.Id == entity.Id);
            if(entity.Telefon!=null) predicate = predicate.And(x => x.Telefon == entity.Telefon);
            if(entity.Vergi_no!=null) predicate = predicate.And(x => x.Vergi_no == entity.Vergi_no);
            //foreach (var item in entity.GetType().GetProperties())
            //{ if(item.GetValue(entity)==null)
            //   predicate = predicate.Or<Firma>(x => x.GetType().GetProperty(item.Name) == entity.GetType().GetProperty(item.Name));
            //}
            

            return _firmaRepo.Filter(predicate);

        }


    }
}
