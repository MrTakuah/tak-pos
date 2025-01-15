using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSSystem.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public int OrderId { get; set; }

        public string MenuItemId { get; set; }
        public int Quantity {get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice {get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal {get; set; }
        public Order Order {get; set; }
        public MenuItem MenuItem {get; set; }
    }
}
