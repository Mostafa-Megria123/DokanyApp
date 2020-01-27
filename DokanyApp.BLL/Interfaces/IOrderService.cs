using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public interface IOrderService
    {
        Task Add(Order order);
        Task Update(Order order);
        Task Remove(int Id);
        IQueryable<Order> Get();
        Task<Order> FindById(int Id);
    }
}
