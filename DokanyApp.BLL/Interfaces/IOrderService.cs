using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> Get();
        Task<OrderDTO> FindById(int Id);
        Task Remove(int Id);
        Task<int> Add(Order order);
        Task Update(Order order);
    }
}
