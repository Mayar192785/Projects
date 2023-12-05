using System.ComponentModel.DataAnnotations;

namespace Global.Models.AccountViewModels
{
    public class VerifyCodeViewModel
    {
        [Required]
        public String? Provider { get; set; }

        [Required]
        public String? Code { get; set; }

        public String? ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}