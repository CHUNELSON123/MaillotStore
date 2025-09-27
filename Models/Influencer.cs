using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaillotStore.Models
{
    public class Influencer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string ReferralCode { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CommissionEarned { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CommissionPaid { get; set; }

        public DateTime JoinedDate { get; set; }

        public ICollection<Commission> Commissions { get; set; }
    }
}
