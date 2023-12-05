using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Global.Models
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() : base()
        {
        }

        [Display(Name = "Description")]
        public String? Description { get; set; }

        [Display(Name = "CreationDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "AllowedIPAdress")]
        public String? IPAddress { get; set; }

        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole<string>> Users { get; } = new List<IdentityUserRole<string>>();

        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<IdentityRoleClaim<string>> Claims { get; } = new List<IdentityRoleClaim<string>>();
    }
}