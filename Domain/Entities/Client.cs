using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Client")]
    public class Client
    {
        [Key()]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public Client(string? name, string? email)
        {
            Name = name ?? string.Empty;
            Email = email ?? string.Empty;
        }
    }
}
