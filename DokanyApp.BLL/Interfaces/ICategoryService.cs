using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public interface ICategoryService
    {
        Task Add(Category categoryName);
        Task Update(Category categoryName);
        Task Remove(int Id);
        IQueryable<Category> Get();
        Task<Category> FindById(int Id);
    }    
}
