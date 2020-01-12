using System;
using DokanyApp.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DokanyApp.Core.Models
{
    public partial class CartItem : ICartItem
    {
        public int CartItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Total { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int TraderId { get; set; }

        public virtual IProduct Product { get; set; }
        public virtual IShoppingCart ShoppingCart { get; set; }
        public virtual ITrader Trader { get; set; }
    }
}
