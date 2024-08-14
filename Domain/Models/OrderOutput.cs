using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class OrderOutput
    {
        public int Id { get; set; }

        [JsonPropertyName("nomeCliente")]
        public string? ClientName { get; set; }

        [JsonPropertyName("emailCliente")]
        public string? ClientEmail { get; set; }

        [JsonPropertyName("pago")]
        public bool PaymentStatus { get; set; }

        [JsonPropertyName("valorTotal")]
        public double TotalPrice { get; set; }

        [JsonPropertyName("itensPedido")]
        public List<OrderItemOutput> OrderItems { get; set; }

        public OrderOutput()
        {
            OrderItems = new List<OrderItemOutput>();
        }
    }
}
