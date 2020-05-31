using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL.Interfaces
{
    public interface ICartItemService
    {
        Task<List<CartItemDTO>> Get();
        Task<CartItemDTO> FindById(int Id);
        Task<List<CartItemDTO>> Any(CartItemDTO cartItemDTO);
        Task Remove(int Id);
        Task Add(CartItemDTO cartItemDTO);
        Task Update(CartItemDTO cartItemDTO);
    }
}
