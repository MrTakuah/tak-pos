using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSSystem.Models
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<OrderItem> OrderItems {get; set;} = new List<OrderItem>();
    }
}
