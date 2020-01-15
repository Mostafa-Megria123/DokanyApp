using DokanyApp.Core.Models;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.Core.InterfacesRepo
{
    public interface IProductRepository
    {
        void Add(Product p);
        void Edit(Product p);
        void Remove(int Id);
        IEnumerable GetProducts();
        Product FindById(int Id);
    }
}
   
