using System;

namespace DokanyApp.BLL
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public int CustomerId { get; set; }
        public int ShippingId { get; set; }
        public string Description { get; set; }
        public int CartItemId { get; set; }
    }
}
