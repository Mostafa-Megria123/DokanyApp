using DokanyApp.com.dokany.Models;
using System;
using System.Collections.Generic;

namespace DokanyApp.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public int CustomerId { get; set; }
        public int ShippingId { get; set; }
        public string Description { get; set; }
        public int CartItemIid { get; set; }
        public OrderStatusENU OrderingStatus { get; set; }

        public virtual CartItem CartItemI { get; set; }
        public virtual User Customer { get; set; }
        public virtual ShippingInfo Shipping { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
    }
}
