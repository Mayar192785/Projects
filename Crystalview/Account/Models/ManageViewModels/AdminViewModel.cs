using System.ComponentModel.DataAnnotations;

namespace Global.Models
{
    public class RoleViewModel
    {
        public String? Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public String? Name { get; set; }
    }
}