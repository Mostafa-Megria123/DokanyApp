using DokanyApp.BLL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.DAL
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly EFUnitOfWork dbContext;
        private readonly IUnitOfWork uof;

        public EFRepository(EFUnitOfWork dbContext,
            IUnitOfWork uof)
        {
            this.dbContext = dbContext;
            this.uof = uof;
        }

        public Task<List<T>> Get()
        {
            return dbContext.Set<T>().ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return dbContext.FindAsync<T>(id);
        }

        public async Task Remove(T item)
        {
            dbContext.Remove(item);
            dbContext.Entry(item).State = EntityState.Deleted;

            await dbContext.CommitAsync();
        }

        public async Task Add(T item)
        {
            dbContext.Add(item);
            dbContext.Entry(item).State = EntityState.Added;

            await dbContext.CommitAsync();
        }

        public async Task Update(T item)
        {
            dbContext.Update(item);
            dbContext.Entry(item).State = EntityState.Modified;

            await dbContext.CommitAsync();
        }
    }
}
