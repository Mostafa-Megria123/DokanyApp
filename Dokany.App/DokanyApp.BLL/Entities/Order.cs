using DokanyApp.BLL.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokanyApp.BLL
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public int CustomerId { get; set; }
        public int ShippingId { get; set; }
        public string Description { get; set; }
        public int CartItemIId { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Total { get; set; }
        [ForeignKey(nameof(CreditCard))]
        public int CreditCardId { get; set; }

        public OrderStatusENU OrderingStatus { get; set; }
        public PaymentMethodType PaymentMethod { get; set; }

        public virtual CartItem CartItemI { get; set; }
        public virtual User Customer { get; set; }
        public virtual ShippingInfo Shipping { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }
}
