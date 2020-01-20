using System;
using System.Collections;
using DokanyApp.Core.InterfacesRepo;
using DokanyApp.Models;

namespace DokanyApp.BLL.Orders
{
    class OrderService : IProductService
    {
        //inject DBcontext
        private readonly OrderContext ProductContext;
        public OrderService()
        {
            ProductContext = new OrderContext();
        }

        public void Add(Product p)
        {
            throw new NotImplementedException();
        }

        public void Edit(Product p)
        {
            throw new NotImplementedException();
        }

        public Product FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetProducts()
        {
            throw new NotImplementedException();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
