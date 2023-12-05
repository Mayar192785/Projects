using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Global.Models
{
    public class ConfigurePreferenceInfoViewModel
    {
        [Display(Name = "Default Language")]
        public String? Culture { get; set; }

        [Display(Name = "User Full Name")]
        public String? FullName { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public String? Email { get; set; }

        public List<SelectListItem>? AvailableCultures { get; }
    }
}