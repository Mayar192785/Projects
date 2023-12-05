using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Global.Models
{
    public class EditUserViewModel
    {
        public String? Id { get; set; }

        public String? UserName { get; set; }
        public String? FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public String? Email { get; set; }

        public String? Culture { get; set; }
        public List<SelectListItem>? ApplicationRoles { get; set; }

        [Display(Name = "Roles")]
        public List<string>? userRoles { get; set; }
    }
}