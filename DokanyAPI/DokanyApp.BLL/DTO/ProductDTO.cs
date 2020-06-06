namespace DokanyApp.BLL
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CreationDate { get; set; }
        public int Quantity { get; set; }
    }
}
