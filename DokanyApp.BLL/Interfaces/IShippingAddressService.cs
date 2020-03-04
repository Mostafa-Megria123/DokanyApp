using DokanyApp.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL.Interfaces
{
    public interface IShippingAddressService
    {
        Task<List<ShippingAddressDto>> Get();
        Task<ShippingAddressDto> FindById(int Id);
        Task Remove(int Id);
        Task Add(ShippingAddressDto shippingAddress);
        Task Update(ShippingAddressDto shippingAddress);
        Task<ShippingAddressDto> Any(ShippingAddressDto shippingAddress);
    }
}
