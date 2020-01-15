using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DokanyApp.Core.InterfacesRepo;
using DokanyApp.Core.Models;

namespace DokanyApp.Infrastructure.Products
{
    class ProductReprository : IProductRepository
    {
        //inject DBcontext
        private readonly ProductContext ProductContext;
        public ProductReprository()
        {
            ProductContext = new ProductContext();
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
