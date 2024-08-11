using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool PaymentStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
            CreationDate = DateTime.Now;
        }

        public Order(int clientId, bool paymentStatus, List<OrderItem> orderItems)
        {
            ClientId = clientId;
            CreationDate = DateTime.Now;
            PaymentStatus = paymentStatus;
            OrderItems = orderItems;
        }
    }
}
