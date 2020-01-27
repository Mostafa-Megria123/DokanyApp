using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get();
        void Add(T item);
        void Remove(T item);
        void Modify(T item);
    }
}
