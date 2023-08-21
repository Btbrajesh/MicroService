namespace OrderWebApi.Entities
{
    public class OrderDetail : BaseEntity
    {
        
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
