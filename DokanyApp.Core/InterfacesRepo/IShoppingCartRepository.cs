using DokanyApp.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DokanyApp.Core.InterfacesRepo
{
    public interface IShoppingCartRepository
    {

        void Add(ShoppingCart p);
        void Edit(ShoppingCart p);
        void Remove(int Id);
        IEnumerable GetShoppingCarts();
        ShoppingCart FindById(int Id);
    }

}
