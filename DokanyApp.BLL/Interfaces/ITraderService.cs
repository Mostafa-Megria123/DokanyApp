using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public interface ITraderService
    {
        Task Add(User user);
        Task Remove(int Id);
        IQueryable<User> Get();
        Task<User> FindById(int Id);
    }
}
