using System.Collections.Generic;

namespace DokanyApp.BLL
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
        public string ImagePath { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
