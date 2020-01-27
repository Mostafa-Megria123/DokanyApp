using DokanyApp.BLL;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DokanyApp.DAL
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private EFUnitOfWork dbContext;
        public EFRepository(EFUnitOfWork dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(T item)
        {
            dbContext.Entry(item).State = EntityState.Added;
        }

        public IQueryable<T> Get()
        {
            return dbContext.Set<T>();
        }

        public void Modify(T item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Remove(T item)
        {
            dbContext.Entry(item).State = EntityState.Deleted;
        }
    }
}
