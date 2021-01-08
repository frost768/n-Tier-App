using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLayer;
using API.Contracts.V1;
using BusinessLayer.RepoS;
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

    public class SubeController : ControllerBase
    {
        private readonly ISubeRepo _subeRepo;
        public SubeController(ISubeRepo subeRepo)
        {
            _subeRepo = subeRepo;
        }

        [Route(ApiRoutes.Subeler.GetAll), HttpGet]
        public  async Task<ActionResult<IEnumerable<Sube>>> GetAllAsync()
        {
            return await _subeRepo.GetAll();
        }


        [Route(ApiRoutes.Subeler.GetByFirmaId), HttpGet]
        public List<Sube> GetByFirmaId([FromRoute]int id)
        {
            return  _subeRepo.GetFirmaSube(id);
        }


        [Route(ApiRoutes.Subeler.Get),HttpGet]

        public async Task<ActionResult<Sube>> Get([FromRoute] int id)
        {
            var sube = await _subeRepo.GetByIdAsync(id);

            if (sube == null)
            {
                return NotFound();
            }

            return sube;
        }


        [Route(ApiRoutes.Subeler.Update), HttpPut]
        public bool Update([FromBody] Sube sube)
        {
            
            return  _subeRepo.Update(sube); 
        }

        [Route(ApiRoutes.Subeler.Create),HttpPost]
        public async Task<bool> Create([FromBody]Sube sube)
        {
            return await _subeRepo.CreateAsync(sube);
            
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route(ApiRoutes.Subeler.DeleteId),HttpDelete]
        public bool Delete(int id)
        {
            return  _subeRepo.Delete(id);
    
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route(ApiRoutes.Subeler.Delete), HttpPost]
        public bool Delete([FromBody] Sube entity)
        {
            return _subeRepo.Delete(entity);

        }
        
        [Route(ApiRoutes.Subeler.Filter), HttpPost]
        public List<Sube> Filter([FromBody] Sube entity)
        {

            Expression<Func<Sube, bool>> predicate = PredicateBuilder.New<Sube>(true);
            if(entity.Ad!=null) predicate=predicate.And(x => x.Ad == entity.Ad);
            if(entity.Il!=null) predicate = predicate.And(x => x.Il == entity.Il);
            if(entity.Ilce!=null) predicate = predicate.And(x => x.Ilce == entity.Ilce);

            return _subeRepo.Filter(predicate);

        }


    }
}
