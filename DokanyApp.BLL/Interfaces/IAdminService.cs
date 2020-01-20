using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanyApp.BLL.Interfaces
{
    public interface IAdminService
    {
        Task Remove(int Id);
        IQueryable GetProducts();
        Task<Product> FindById(int Id);
    }
}
