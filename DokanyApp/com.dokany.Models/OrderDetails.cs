using System;
using System.Collections.Generic;

namespace DokanyApp.Models
{
    public partial class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Total { get; set; }

        public virtual Product OrderDetails1 { get; set; }
        public virtual Order OrderDetailsNavigation { get; set; }
    }
}
