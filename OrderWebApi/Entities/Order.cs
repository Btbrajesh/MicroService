namespace OrderWebApi.Entities
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
       public DateTime OrderOn { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
