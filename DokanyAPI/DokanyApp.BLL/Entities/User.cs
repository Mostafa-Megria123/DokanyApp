using System.Collections.Generic;

namespace DokanyApp.BLL
{
    public partial class User
    {
        public User()
        {
            CartItem = new HashSet<CartItem>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string UserName { get; set; }

        //User Type
        public UserType UserType { get; set; }
        // User Status
        public UserStatusENU UserStatus { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
