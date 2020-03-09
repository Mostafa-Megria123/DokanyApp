using System.ComponentModel.DataAnnotations.Schema;

namespace DokanyApp.BLL.Entities
{
    public class ImageProduct
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Products { get; set; }
    }
}
