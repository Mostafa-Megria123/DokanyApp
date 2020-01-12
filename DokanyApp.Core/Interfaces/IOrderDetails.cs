using System;

namespace DokanyApp.Core.Interfaces
{
    public interface IOrderDetails
    {
        int OrderDetailsId { get; set; }
        int ProductId { get; set; }
        int Quantity { get; set; }
        decimal UnitCost { get; set; }
        decimal Total { get; set; }
        IProduct OrderDetails1 { get; set; }
        IOrder OrderDetailsNavigation { get; set; }
    }
}
