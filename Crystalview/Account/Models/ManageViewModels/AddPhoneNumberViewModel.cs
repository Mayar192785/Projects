using System.ComponentModel.DataAnnotations;

namespace Global.Models.ManageViewModels
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public String? PhoneNumber { get; set; }
    }
}