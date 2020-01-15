using System;
using System.Collections.Generic;
using DokanyApp.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DokanyApp.Core.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
