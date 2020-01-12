using DokanyApp.Core.Models;
using System;
using System.Collections;

namespace DokanyApp.Core.InterfacesRepo
{
    public interface ICartItemRepository
    {
        void Add(Product p);
        void Edit(Product p);
        void Remove(int Id);
        IEnumerable GetProducts();
        Product FindById(int Id);

    }
}
