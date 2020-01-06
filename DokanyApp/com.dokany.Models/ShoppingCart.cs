using System;
using System.Collections.Generic;

namespace DokanyApp.Models
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItem = new HashSet<CartItem>();
            Order = new HashSet<Order>();
        }

        public int CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Customer Cart { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
