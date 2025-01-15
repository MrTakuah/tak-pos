using System;
using System.Collections.Generic;

namespace POSSystem.Models
{
    public class Order{
        public Guid Id { get; set; }
        public DateTime OrderDate {get; set;}
        public decimal TotalAmount {get; set; }
        public string Status {get; set; }
        public string? Notes {get; set; }
        public ICollection<OrderItem> OrderItems {get; set; } = new List<OrderItem>();
    }
}
