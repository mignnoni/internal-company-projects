using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OurProjects.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query { get; }

        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);

    }
}
