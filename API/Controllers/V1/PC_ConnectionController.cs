using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Interfaces;
using Entities;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Contracts.V1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers.V1
{
    [ApiController]
    [Authorize(Roles="Admin,SuperAdmin,Operator",
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class PcConnectionController : ControllerBase
    {
        private readonly IBilgisayarBaglantiRepo _PC_ConnectionRepo;

        public PcConnectionController(IBilgisayarBaglantiRepo PC_ConnectionRepo)
        {
            _PC_ConnectionRepo = PC_ConnectionRepo;
        }

        [HttpGet(ApiRoutes.BilgisayarBaglantilari.GetAll)]
        public  async Task<ActionResult<IEnumerable<BilgisayarBaglanti>>> GetAll()
        {
            return await _PC_ConnectionRepo.GetAll();
        }

        [HttpGet(ApiRoutes.BilgisayarBaglantilari.GetSubeConnections)]
        public  ActionResult<IEnumerable<BilgisayarBaglanti>> GetAll([FromRoute]int id)
        {
            return  _PC_ConnectionRepo.GetSubePC_Connection(id);
        }


        [HttpGet(ApiRoutes.BilgisayarBaglantilari.Get)]

        public async Task<ActionResult<BilgisayarBaglanti>> Get([FromRoute] int id)
        {
            var pcConnection = await _PC_ConnectionRepo.GetByIdAsync(id);

            if (pcConnection == null)
            {
                return NotFound();
            }

            return pcConnection;
        }


        [HttpPut(ApiRoutes.BilgisayarBaglantilari.Update)]
        public bool Update([FromBody] BilgisayarBaglanti PC_Connection)
        {
            
            return  _PC_ConnectionRepo.Update(PC_Connection); 
        }


        [HttpPost(ApiRoutes.BilgisayarBaglantilari.Create)]
        public async Task<bool> Create([FromBody] BilgisayarBaglanti PC_Connection)
        {
            return await _PC_ConnectionRepo.CreateAsync(PC_Connection);
            
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpDelete(ApiRoutes.BilgisayarBaglantilari.DeleteId)]
        public bool Delete(int id)
        {
            return  _PC_ConnectionRepo.Delete(id);
    
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPost(ApiRoutes.BilgisayarBaglantilari.Delete)]
        public bool Delete([FromBody] BilgisayarBaglanti entity)
        {
            return _PC_ConnectionRepo.Delete(entity);

        }
        
        [HttpPost(ApiRoutes.BilgisayarBaglantilari.Filter)]
        public List<BilgisayarBaglanti> Filter([FromBody] BilgisayarBaglanti entity)
        {

            Expression<Func<BilgisayarBaglanti, bool>> predicate = PredicateBuilder.New<BilgisayarBaglanti>(true);
            if(entity.Aciklama!=null) predicate=predicate.And(x => x.Aciklama == entity.Aciklama);
            if(entity.Programs!=null) predicate = predicate.And(x => x.Programs == entity.Programs);
     
            

            return _PC_ConnectionRepo.Filter(predicate);

        }


    }
}
