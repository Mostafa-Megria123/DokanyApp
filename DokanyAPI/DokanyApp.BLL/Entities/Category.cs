using System.Collections.Generic;

namespace DokanyApp.BLL
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
