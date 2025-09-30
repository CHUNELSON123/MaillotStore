using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace MaillotStore.Models.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        public string JerseyType { get; set; } = "HOME";
        public string JerseyYear { get; set; } = "2025/2026";

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative number.")]
        public int StockQuantity { get; set; }

        [Required]
        public string Description { get; set; }

        // This will hold the uploaded file. It is now OPTIONAL.
        public IBrowserFile? ImageFile { get; set; }

        // This will hold the image URL. It is also OPTIONAL.
        public string? ImageUrl { get; set; }

        public bool IsFeatured { get; set; }
    }
}