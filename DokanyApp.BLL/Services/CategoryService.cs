using System;
using System.Collections;
using DokanyApp.Core.InterfacesRepo;
using DokanyApp.Models;

namespace DokanyApp.BLL.Categories
{
    class CategoryService : ICategoryService
    {
        //inject DBcontext
        private readonly CategoryContext CategoryContext;
        public CategoryService()
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
