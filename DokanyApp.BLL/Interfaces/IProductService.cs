using DokanyApp.BLL.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public interface IProductService
    {
        Task<ProductDTO> Add(Product product);
        Task Update(Product product);
        Task Remove(int Id);
        IQueryable<ProductDTO> Get();
        ProductDTO FindById(int Id);
    }
}
   
