using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key()]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }

        public Product(string? name, double price)
        {
            Name = name ?? string.Empty;
            Price = price;
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(Name) || Price <= 0) return false;

            return true;
        }

    }
}
