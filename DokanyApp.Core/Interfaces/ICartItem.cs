using System;
namespace DokanyApp.Core.Interfaces
{
    public interface ICartItem
    {
        int CartItemId { get; set; }
        string Name { get; set; }
        int Quantity { get; set; }
        decimal UnitCost { get; set; }
        decimal Total { get; set; }
        int ShoppingCartId { get; set; }
        int ProductId { get; set; }
        int TraderId { get; set; }
        IProduct Product { get; set; }
        IShoppingCart ShoppingCart { get; set; }
        ITrader Trader { get; set; }
    }
}
