﻿

namespace DokanyApp.BLL.DTO
{
    public class ShippingAddressDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
