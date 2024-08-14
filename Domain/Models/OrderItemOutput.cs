using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrderItemOutput
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("idProduto")]
        public int ProductId { get; set; }

        [JsonPropertyName("nomeProduto")]
        public string? ProductName { get; set; }

        [JsonPropertyName("valorUnitario")]
        public double ProductPrice { get; set; }

        [JsonPropertyName("quantidade")]
        public int Quantity { get; set; }

        public OrderItemOutput(int id, int productId, string? productName, double productPrice, int quantity)
        {
            Id = id;
            ProductId = productId;
            ProductName = productName ?? string.Empty;
            ProductPrice = productPrice;
            Quantity = quantity;
        }
    }
}
