using System;
using System.Collections.Generic;
using System.Text;

namespace DokanyApp.BLL.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string UserName { get; set; } // Be Careful of NullPointerException
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string CustomerStatus { get; set; }

        public UserType UserType
        {
            get { return UserType; }
            set { UserType = UserType.Customer; }
        }
    }
}
