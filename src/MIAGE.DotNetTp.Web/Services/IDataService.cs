using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MIAGE.DotNetTp.Web.Services
{
    public interface IDataService<T> where T : class
    {
        T Add(T entity);
        bool Any(Expression<Func<T, bool>> predicate);
        void Delete(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}