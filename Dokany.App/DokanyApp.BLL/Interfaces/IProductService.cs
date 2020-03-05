using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public interface IProductService
    {
        Task<List<ProductDTO>> Get();
        Task<ProductDTO> FindById(int Id);
        Task Remove(int Id);
        Task<int> Add(Product product);
        Task Update(Product product);
    }
}
   
