using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public interface IAdminService
    {
        Task Add(User user);
        Task Remove(int Id);
        IQueryable<User> Get();
        Task<User> FindById(int Id);
    }
}
