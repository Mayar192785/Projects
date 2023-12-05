using System.ComponentModel.DataAnnotations;

namespace Global.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public String? Email { get; set; }
    }
}