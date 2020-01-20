using DokanyApp.BLL;

namespace DokanyApp.DAL
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public EFRepository()
        {

        }
        public void Add(T item)
        {
            throw new System.NotImplementedException();
        }

        public System.Linq.IQueryable<T> Get()
        {
            throw new System.NotImplementedException();
        }

        public void Modify(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
