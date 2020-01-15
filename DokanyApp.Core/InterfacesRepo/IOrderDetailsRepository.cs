using DokanyApp.Core.Models;
using System;
using System.Collections;

namespace DokanyApp.Core.InterfacesRepo
{
    public interface IOrderDetailsRepository
    {
        void Add(OrderDetails p);
        void Edit(OrderDetails p);
        void Remove(int Id);
        IEnumerable GetProducts();
        OrderDetails FindById(int Id);
    }
}
