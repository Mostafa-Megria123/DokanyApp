using DokanyApp.com.dokany.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokanyApp.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string username;
        public string UserName
        {
            get { return username; }
            set { username = FirstName + " " + LastName; }
        }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string CreditCardInfo { get; set; }
        // User Status
        public UserStatusENU UserStatus { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
