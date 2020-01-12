using DokanyApp.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace DokanyApp.Core.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public int CustomerId { get; set; }
        public int OrderStatus { get; set; }
        public int ShippingId { get; set; }
        public string Description { get; set; }
        public int ShoppingCartIid { get; set; }
        public OrderStatusENU OrderingStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ShippingInfo Shipping { get; set; }
        public virtual ShoppingCart ShoppingCartI { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
    }
}
