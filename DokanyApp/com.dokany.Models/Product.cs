using DokanyApp.com.dokany.Models;
using System;
using System.Collections.Generic;

namespace DokanyApp.Models
{
    public partial class Product
    {
        public Product()
        {
            CartItem = new HashSet<CartItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public ProductAppreciateENU ProductAppreciate { get; set; }

        public virtual Category Category { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
