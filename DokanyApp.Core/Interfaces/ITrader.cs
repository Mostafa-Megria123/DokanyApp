using System;
using System.Collections.Generic;

namespace DokanyApp.Core.Interfaces
{
    public interface ITrader
    {
        int TraderId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string MobileNumber { get; set; }
       // UserStatusENU UserStatus { get; set; }
        ICollection<ICartItem> CartItem { get; set; }
    }
}
