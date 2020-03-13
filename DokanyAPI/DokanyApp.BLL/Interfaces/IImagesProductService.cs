using DokanyApp.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL.Interfaces
{
    public interface IImagesProductService
    {
        Task<IEnumerable<ImageProductDto>> GetImages(int productId);
    }
}
