namespace Domain.Models
{
    public class OrderOutput
    {
        public int Id { get; set; }
        public string? ClientName { get; set; }
        public string? ClientEmail { get; set; }
        public bool PaymentStatus { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderItemOutput> OrderItems { get; set; }

        public OrderOutput()
        {
            OrderItems = new List<OrderItemOutput>();
        }
    }
}
