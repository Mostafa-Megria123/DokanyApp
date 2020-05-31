using DokanyApp.BLL.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokanyApp.BLL
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public int UserId { get; set; }
        public int ShippingAddressId { get; set; }
        public string Description { get; set; }
        public int CartItemId { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Total { get; set; }
        public int CreditCardId { get; set; }

        public OrderStatusENU OrderingStatus { get; set; }
        public PaymentMethodType PaymentMethod { get; set; }

        public virtual CartItem CartItemI { get; set; }
        public virtual User User { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }
}
