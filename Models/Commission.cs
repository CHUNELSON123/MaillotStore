using System.ComponentModel.DataAnnotations.Schema;

namespace MaillotStore.Models
{
    public class Commission
    {
        public int Id { get; set; }

        public int InfluencerId { get; set; }
        public Influencer Influencer { get; set; }

        public DateTime Date { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        public bool IsPaid { get; set; }
    }
}
