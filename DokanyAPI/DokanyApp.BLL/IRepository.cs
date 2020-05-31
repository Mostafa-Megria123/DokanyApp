using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> Get();
        Task<T> GetById(int id);
        Task Remove(T item);
        Task Add(T item);
        Task Update(T item);
        Task<List<T>> GetByWhere(Expression<Func<T, bool>> expression);

    }
}
