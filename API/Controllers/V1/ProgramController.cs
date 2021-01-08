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

    public class ProgramController : ControllerBase
    {
        private readonly IProgramRepo _programRepo;

        public ProgramController(IProgramRepo programRepo)
        {
            _programRepo = programRepo;
        }

        
        [Route(ApiRoutes.Programlar.GetAll), HttpGet]
        public  async Task<ActionResult<IEnumerable<Entities.Program>>> GetAll()
        {
            return await _programRepo.GetAll();
        }

       
        [Route(ApiRoutes.Programlar.Get),HttpGet]

        public async Task<ActionResult<Entities.Program>> Get([FromRoute] int id)
        {
            var program = await _programRepo.GetByIdAsync(id);

            if (program == null)
            {
                return NotFound();
            }

            return program;
        }

        [Route(ApiRoutes.Programlar.Update), HttpPut]
        public bool Update([FromBody] Entities.Program program)
        {
            
            return  _programRepo.Update(program); 
        }

        
        [Route(ApiRoutes.Programlar.Create),HttpPost]
        public async Task<bool> Create([FromBody] Entities.Program program)
        {
            return await _programRepo.CreateAsync(program);
            
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route(ApiRoutes.Programlar.DeleteId),HttpDelete]
        public bool Delete(int id)
        {
            return  _programRepo.Delete(id);
    
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route(ApiRoutes.Programlar.Delete), HttpPost]
        public bool Delete([FromBody] Entities.Program entity)
        {
            return _programRepo.Delete(entity);

        }
        
        [Route(ApiRoutes.Programlar.Filter), HttpPost]
        public List<Entities.Program> Filter([FromBody] Entities.Program entity)
        {

            Expression<Func<Entities.Program, bool>> predicate = PredicateBuilder.New<Entities.Program>(true);
            if(entity.Ad!=null) predicate=predicate.And(x => x.Ad == entity.Ad);
            
       

            return _programRepo.Filter(predicate);

        }


    }
}
