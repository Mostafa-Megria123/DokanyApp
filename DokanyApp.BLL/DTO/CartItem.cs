using System;
using System.Collections.Generic;

namespace DokanyApp.Models
{
    public partial class CartItem
    {
        public CartItem()
        {
            Order = new HashSet<Order>();
        }

        public int CartItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Total { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }

        public virtual User Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
