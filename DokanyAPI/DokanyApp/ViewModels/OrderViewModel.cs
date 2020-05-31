
using DokanyApp.BLL;
using DokanyApp.BLL.DTO;
using DokanyApp.BLL.Entities;

namespace DokanyApp.ViewModels
{
    public class OrderViewModel
    {
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
