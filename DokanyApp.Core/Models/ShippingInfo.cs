﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DokanyApp.Core.Models
{
    public partial class ShippingInfo
    {
        public ShippingInfo()
        {
            Order = new HashSet<Order>();
        }

        public int ShippingId { get; set; }
        public string ShippingType { get; set; }
        public string ShippingCost { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
