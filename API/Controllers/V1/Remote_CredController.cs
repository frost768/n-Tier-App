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

    public class Remote_CredController : ControllerBase
    {
        private readonly IRemote_CredRepo _remoteCredRepo;

        public Remote_CredController(IRemote_CredRepo remoteCredRepo)
        {
            _remoteCredRepo = remoteCredRepo;
        }

        
        [Route(ApiRoutes.Remote_Creds.GetAll), HttpGet]
        public  async Task<ActionResult<IEnumerable<RemoteCred>>> GetAll()
        {
            return await _remoteCredRepo.GetAll();
        }

       
        [Route(ApiRoutes.Remote_Creds.Get),HttpGet]

        public async Task<ActionResult<RemoteCred>> Get([FromRoute] int id)
        {
            var remoteCred = await _remoteCredRepo.GetByIdAsync(id);

            if (remoteCred == null)
            {
                return NotFound();
            }

            return remoteCred;
        }

        [Route(ApiRoutes.Remote_Creds.Update), HttpPut]
        public bool Update([FromBody] RemoteCred remoteCred)
        {
            
            return  _remoteCredRepo.Update(remoteCred); 
        }

        
        [Route(ApiRoutes.Remote_Creds.Create),HttpPost]
        public async Task<bool> Create([FromBody] RemoteCred remoteCred)
        {
            return await _remoteCredRepo.CreateAsync(remoteCred);
            
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route(ApiRoutes.Remote_Creds.DeleteId),HttpDelete]
        public bool Delete(int id)
        {
            return  _remoteCredRepo.Delete(id);
    
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route(ApiRoutes.Remote_Creds.Delete), HttpPost]
        public bool Delete([FromBody] RemoteCred entity)
        {
            return _remoteCredRepo.Delete(entity);

        }
        
        [Route(ApiRoutes.Remote_Creds.Filter), HttpPost]
        public List<RemoteCred> Filter([FromBody] RemoteCred entity)
        {

            Expression<Func<RemoteCred, bool>> predicate = PredicateBuilder.New<RemoteCred>(true);
            /*if(entity.!=null) predicate=predicate.And(x => x.Ad == entity.Ad);
            if(entity.E_Posta!=null) predicate = predicate.And(x => x.E_Posta == entity.E_Posta);
            if(entity.Soyad!=null) predicate = predicate.And(x => x.Soyad == entity.Soyad);
            if(entity.Telefon!=null) predicate = predicate.And(x => x.Telefon == entity.Telefon);*/
       

            return _remoteCredRepo.Filter(predicate);

        }


    }
}
