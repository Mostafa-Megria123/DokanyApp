using DokanyApp.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DokanyApp.Core.InterfacesRepo
{
    public interface IOrderRepository
    {
        void Add(Order p);
        void Edit(Order p);
        void Remove(int Id);
        IEnumerable GetOrders();
        Order FindById(int Id);
    }
}
