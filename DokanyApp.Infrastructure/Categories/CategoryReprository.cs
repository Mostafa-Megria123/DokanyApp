using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DokanyApp.Core.InterfacesRepo;
using DokanyApp.Core.Models;

namespace DokanyApp.Infrastructure.Categories
{
    class CategoryReprository : ICategoryRepository
    {
        //inject DBcontext
        private readonly CategoryContext CategoryContext;
        public CategoryReprository()
        {
            CategoryContext = new CategoryContext();
        }

        public void Add(Category p)
        {
            throw new NotImplementedException();
        }

        public void Edit(Category p)
        {
            throw new NotImplementedException();
        }

        public Category FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetCategories()
        {
            throw new NotImplementedException();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
