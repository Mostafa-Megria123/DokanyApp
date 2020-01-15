using System;
using System.Collections.Generic;

namespace DokanyApp.Core.Interfaces
{
    public interface IProduct
    {
        int ProductId { get; set; }
        string ProductName { get; set; }
        string BrandName { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        string ImageUrl { get; set; }
        int CategoryId { get; set; }
       // ProductAppreciateENU ProductAppreciate { get; set; }
        ICategory Category { get; set; }
        IOrderDetails OrderDetails { get; set; }
        ICollection<ICartItem> CartItem { get; set; }
    }
}
