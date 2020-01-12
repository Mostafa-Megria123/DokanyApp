using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DokanyApp.Core.InterfacesRepo;
using DokanyApp.Core.Models;

namespace DokanyApp.Infrastructure.Orders
{
    class OrderReprository : IProductRepository
    {
        //inject DBcontext
        private readonly OrderContext ProductContext;
        public OrderReprository()
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
