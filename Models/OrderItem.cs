using System.ComponentModel.DataAnnotations.Schema;

namespace MaillotStore.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Subtotal { get; set; }

        public string PlayerName { get; set; }
        public string PlayerNumber { get; set; }
    }
}
