using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Key()]
        public int Id { get; set; }
        public int OrderId {  get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public OrderItem(int orderId, int productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
