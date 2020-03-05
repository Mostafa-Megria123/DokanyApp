using DokanyApp.BLL.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> Get();
        Task<List<OrderDTO>> FindByUser(int userId);
        Task<OrderDTO> FindById(int Id);
        Task Remove(int Id);
        Task<int> Add(OrderCreationDto order);
        Task Update(Order order);
    }
}
