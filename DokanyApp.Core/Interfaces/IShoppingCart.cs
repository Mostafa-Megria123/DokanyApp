using System;
using System.Collections.Generic;

namespace DokanyApp.Core.Interfaces
{
    public interface IShoppingCart
    {

        int CartId { get; set; }
        int Quantity { get; set; }
        DateTime DateAdded { get; set; }
        ICustomer Cart { get; set; }
        ICollection<ICartItem> CartItem { get; set; }
        ICollection<IOrder> Order { get; set; }
    }
}
