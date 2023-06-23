using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        //List<T> GetAll(Expression<Func<T, bool>> filter, Expression<Func<T, object>> includes);
        List<T> GetAll(Expression<Func<T, bool>> filter, params string[] includes);
        T Get(Expression<Func<T, bool>> filter, params string[] includes);
        T Get2(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
   

    }
}
