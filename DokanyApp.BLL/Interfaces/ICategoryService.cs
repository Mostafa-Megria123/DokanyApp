using DokanyApp.Models;
using System.Collections;

namespace DokanyApp.Core.InterfacesRepo
{
    public interface ICategoryService
    {
        void Add(Category p);
        void Edit(Category p);
        void Remove(int Id);
        IEnumerable GetCategories();  
        Category FindById(int Id);
    }    
}
