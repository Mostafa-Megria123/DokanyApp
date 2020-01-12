using System;
using System.Collections.Generic;
using DokanyApp.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DokanyApp.Core.Models
{
    public partial class CustomerService
    {
        public int CustomerServiceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = FirstName + " " + LastName; }
        }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
    }
}
