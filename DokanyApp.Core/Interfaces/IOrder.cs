using System;
using System.Collections.Generic;

namespace DokanyApp.Core.Interfaces
{
    public interface IOrder
    {
        int OrderId { get; set; }
        DateTime CreationDate { get; set; }
        DateTime ShippingDate { get; set; }
        int CustomerId { get; set; }
        int OrderStatus { get; set; }
        int ShippingId { get; set; }
        string Description { get; set; }
        int ShoppingCartIid { get; set; }
       // OrderStatusENU OrderingStatus { get; set; }
        ICustomer Customer { get; set; }
        IShippingInfo Shipping { get; set; }
        IShoppingCart ShoppingCartI { get; set; }
        IOrderDetails OrderDetails { get; set; }
    }
}
