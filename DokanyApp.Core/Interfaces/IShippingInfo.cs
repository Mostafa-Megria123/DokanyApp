using System;
using System.Collections.Generic;

namespace DokanyApp.Core.Interfaces
{
    public interface IShippingInfo
    {


        int ShippingId { get; set; }
        string ShippingType { get; set; }
        string ShippingCost { get; set; }
        string Description { get; set; }
        ICollection<IOrder> Order { get; set; }
    }
}
