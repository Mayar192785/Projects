using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Global.Models
{
    public class UserViewModel
    {
        public String? Id { get; set; }
        public String? UserName { get; set; }

        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Too Short minumum is 8 char")]
        public String? Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public String? ConfirmPassword { get; set; }

        public String? FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public String? Email { get; set; }

        public String? Culture { get; set; }

        public List<SelectListItem>? ApplicationRoles { get; set; }

        [Display(Name = "Roles")]
        public List<string>? userRoles { get; set; }
    }
}