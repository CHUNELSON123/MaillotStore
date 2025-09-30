using System.ComponentModel.DataAnnotations;

namespace MaillotStore.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your email or phone number.")]
        public string EmailOrPhone { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}