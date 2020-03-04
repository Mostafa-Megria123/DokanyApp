using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL.Interfaces
{
    public interface ICartItemService
    {
        Task<List<CartItemDTO>> Get();
        Task<CartItemDTO> Any(CartItemDTO cartItemDTO);
        Task<CartItemDTO> FindById(int Id);
        Task Remove(int Id);
        Task Add(CartItemDTO cartItemDTO);
        Task Update(CartItemDTO cartItemDTO);
    }
}
