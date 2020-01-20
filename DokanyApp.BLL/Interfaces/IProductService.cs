using DokanyApp.Models;
using System.Collections;

namespace DokanyApp.Core.InterfacesRepo
{
    public interface IProductService
    {
        void Add(Product p);
        void Edit(Product p);
        void Remove(int Id);
        IEnumerable GetProducts();
        Product FindById(int Id);
    }
}
   
