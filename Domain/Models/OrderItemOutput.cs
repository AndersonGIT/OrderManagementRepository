using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrderItemOutput
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double ProductPrice { get; set; }
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
