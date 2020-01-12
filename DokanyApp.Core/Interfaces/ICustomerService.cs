using System;

namespace DokanyApp.Core.Interfaces
{
    public interface ICustomerService
    {
          int CustomerServiceId { get; set; }
          string FirstName { get; set; }
          string LastName { get; set; }
          string FullName { get; set; }
          string Email { get; set; }
          string MobileNumber { get; set; }
    }
}
