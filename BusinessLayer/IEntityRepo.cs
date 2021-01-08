using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer
{
    public interface IEntityRepo<TEntity>
    {
        public TEntity GetById(int id);
        public Task<TEntity> GetByIdAsync(int id);
        public Task<bool> CreateAsync(TEntity entity);
       
        public Task<List<TEntity>> GetAll();
        public bool Update(TEntity entity);
        public bool Delete(int id);
        public bool Delete(TEntity entity);
        public bool Exists(int id);
        public List<TEntity> Filter(Expression<Func<TEntity, bool>> entity);
        
    }
}
