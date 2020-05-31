namespace DokanyApp.BLL
{
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }

        public virtual Product OrderDetails1 { get; set; }
        public virtual Order OrderDetailsNavigation { get; set; }
    }
}
