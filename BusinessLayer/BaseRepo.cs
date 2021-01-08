using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BusinessLayer
{
    public class BaseRepo<TEntity> : IEntityRepo<TEntity> where TEntity : class, new()
    {
        protected DBContext _context;
        protected DbSet<TEntity> _table;

        public BaseRepo(){
        }

            
        public BaseRepo(DBContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();

        }
       
        public  TEntity GetById(int id) => _table.Find(id);
        public async Task<TEntity> GetByIdAsync(int id) => await _table.FindAsync(id);
        

        public async Task<bool> CreateAsync(TEntity entity)
        {
            try
            {
                await _table.AddAsync(entity);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
               await _context.SaveChangesAsync();
            }
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            return _table.ToListAsync();
        }

        public  bool Delete(int id)
        {
            var result = false;
            if (Exists(id)) 
            {
                TEntity e= GetById(id); 
                result= _table.Remove(e) != null; 
                _context.SaveChanges();
            }
            return result;
            

        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _table.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _context.SaveChanges();
            }
        }

        

        
        public bool Update(TEntity entity)
        {
            
            try
            {
              // T found= GetById(id);

                _table.Update(entity);
                

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _context.SaveChanges();
                
            }
        }


        public bool Exists(int id)
        {
            return GetById(id)!=null;
        }

        public List<TEntity> Filter(Expression<Func<TEntity,bool>> filter)
        {


            return _table.Where(filter).ToList();
        }

        
    }
}
