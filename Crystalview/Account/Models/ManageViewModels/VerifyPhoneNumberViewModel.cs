using System.ComponentModel.DataAnnotations;

namespace Global.Models.ManageViewModels
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        public String? Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public String? PhoneNumber { get; set; }
    }
}