using DokanyApp.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DokanyApp.Core.InterfacesRepo
{
    public interface ICategoryRepository
    {
        void Add(Category p);
        void Edit(Category p);
        void Remove(int Id);
        IEnumerable GetCategories();
        Category FindById(int Id);

    }
}
