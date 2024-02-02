using System.ComponentModel.DataAnnotations;

namespace RefundWebApplication.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordValidation(true, true, true, true, 6, 1, ErrorMessage = "Password does not meet the required criteria.")]
        public string Password { get; set; }
    }
}
