using System;
using System.Collections.Generic;

namespace DokanyApp.Models
{
    public partial class CartItem
    {
        public int CartItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Total { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int TraderId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual Trader Trader { get; set; }
    }
}
