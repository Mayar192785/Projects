using Microsoft.AspNetCore.Mvc.Rendering;

namespace Global.Models.ManageViewModels
{
    public class ConfigureTwoFactorViewModel
    {
        public String? SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}