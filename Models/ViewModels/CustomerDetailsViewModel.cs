using System.ComponentModel.DataAnnotations;

namespace MaillotStore.Models.ViewModels
{
    public class CustomerDetailsViewModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your delivery address.")]
        public string Address { get; set; }

        public string Message { get; set; }
    }
}