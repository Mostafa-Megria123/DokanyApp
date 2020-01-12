using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DokanyApp.Core.Models
{
    public enum OrderStatusENU
    {
        New, Processing, Shipping, Delivered, Cancelled
    }
}
