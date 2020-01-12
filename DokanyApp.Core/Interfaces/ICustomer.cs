using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DokanyApp.Core.Interfaces
{
    public interface ICustomer
    {

        int CustomerId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string MobileNumber { get; set; }
        //UserStatusENU UserStatus { get; set; }
        IShoppingCart ShoppingCart { get; set; }
        ICollection<IOrder> Order { get; set; }
    }
}
