using DokanyApp.com.dokany.Models;
using System;
using System.Collections.Generic;

namespace DokanyApp.Models
{
    public partial class Trader
    {
        public Trader()
        {
            CartItem = new HashSet<CartItem>();
        }

        public int TraderId { get; set; }
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

        // User Status
        public UserStatusENU UserStatus { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
