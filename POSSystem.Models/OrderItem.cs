using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSSystem.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        
        // Navigation properties
        public Order Order { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
