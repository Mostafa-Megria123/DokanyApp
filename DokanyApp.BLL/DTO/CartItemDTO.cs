namespace DokanyApp.BLL
{
    public class CartItemDTO
    {
        public int CartItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Total { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
