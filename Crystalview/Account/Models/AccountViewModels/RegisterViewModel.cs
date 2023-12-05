using System.ComponentModel.DataAnnotations;

namespace Global.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public String? UserName { get; set; }

        [Display(Name = "User Full Name")]
        public String? FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public String? Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public String? ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Default Language")]
        public String? Culture { get; set; }
    }
}