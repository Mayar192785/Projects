using System.ComponentModel.DataAnnotations;

namespace Global.Models
{
    public class ApplicationRoleViewModel
    {
        public String? Id { get; set; }

        [Display(Name = "Role Name")]
        public String? RoleName { get; set; }

        public String? Description { get; set; }
    }
}