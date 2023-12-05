using Microsoft.AspNetCore.Mvc.Rendering;

namespace Global.Models.AccountViewModels
{
    public class SendCodeViewModel
    {
        public String? SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }

        public String? ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}