using DokanyApp.BLL.Entities;
using System;

namespace DokanyApp.BLL.DTO
{
    public class OrderCreationDto
    {
        public DateTime CreationDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public int ShippingId { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalCost { get; set; }
        public ShippingAddressDto ShippingAddressDto { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }
        public CreditCardDto CreditCardDto { get; set; }
        public CartItemDTO CartItemDTO { get; set; }
    }
}
