using System.ComponentModel.DataAnnotations;

namespace MaillotStore.Models.ViewModels
{
    public class InfluencerSignUpModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // We use a dictionary to manage the state of each checkbox
        public Dictionary<string, bool> SocialMedia { get; set; } = new()
        {
            { "Instagram", false },
            { "TikTok", false },
            { "WhatsApp", false },
            { "Twitter", false }
        };

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the Terms and Conditions.")]
        public bool TermsAndConditions { get; set; }
    }
}