using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> Get();
        Task<CategoryDTO> FindById(int Id);
        Task Remove(int Id);
        Task<int> Add(Category order);
        Task Update(Category order);
    }
}
