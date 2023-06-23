using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> where TEntity : class,IEntity,new() 
        where TContext:DbContext,new()
    {

        public async void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                 context.Add(entity);
                 context.SaveChanges();
            }
        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includes)
        {
            using (TContext context = new TContext())
            {          
                    TEntity result = new TEntity();
                    foreach (var include in includes)
                    {
                        result = context.Set<TEntity>().Include(include).SingleOrDefault(filter);
                    }
                    return result;
                
            }
            
        }
        public TEntity Get2(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter,params string[]? includes)
        {
            using (TContext context = new TContext())
            {
                var result=new List<TEntity>();
                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        result = filter == null ? context.Set<TEntity>().Include(include).ToList() : context.Set<TEntity>().Where(filter).Include(include).ToList();

                    }
                    return result;
                }
                else
                {
                    result= filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                }
                return result;
            }
        }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
