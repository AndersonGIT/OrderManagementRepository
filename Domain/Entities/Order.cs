using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public double TotalPrice { get; set; }

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

        public bool Validate()
        {
            if (ClientId <= 0)
                return false;

            if (OrderItems == null)
                return false;
            else
            {
                if (OrderItems.Count > 0)
                {
                    foreach (var orderItem in OrderItems)
                    {
                        if (!orderItem.Validate())
                        {
                            return false;
                        }
                    }

                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
