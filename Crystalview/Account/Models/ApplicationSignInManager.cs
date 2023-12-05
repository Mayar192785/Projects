using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Global.Models
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser>
    {
        public ApplicationSignInManager(UserManager<ApplicationUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<ApplicationUser>> logger)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, null, null)
        {
        }

        //public ApplicationSignInManager(UserManager<ApplicationUser> userManager, IAuthenticationManager authenticationManager)
        //    : base(userManager, authenticationManager)
        //{ }

        public override async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool rememberMe, bool shouldLockout)
        {
            var user = await UserManager.FindByNameAsync(userName);

            if (
                user != null &&
               ((user.IsEnabled.HasValue && !user.IsEnabled.Value) || !user.IsEnabled.HasValue))
            {
                return SignInResult.LockedOut;
            }

            return await base.PasswordSignInAsync(userName, password, rememberMe, shouldLockout);
        }

        public override async Task<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user)
        {
            var principal = await base.CreateUserPrincipalAsync(user);

            var identity = principal.Identity as ClaimsIdentity;
            if (identity != null)
            {
                if (!string.IsNullOrEmpty(user.Culture))
                    identity.AddClaim(new Claim("localizationapp:culture", user.Culture));

                if (!string.IsNullOrWhiteSpace(user.FullName))
                {
                    ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                    new Claim("localizationapp:fullname", user.FullName)
                });
                }
            }

            return principal;
        }
    }

    public static class PrincipalExtensions
    {
        public static string GetCulture(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return "en-US";
        }

        public static string GetFullName(this ClaimsPrincipal principal)
        {
            if (principal == null)
                //throw new ArgumentNullException(nameof(principal));
                return "FullName";
            return principal.FindFirstValue("localizationapp:fullname");
        }

        public static string GetEmployeeID(this ClaimsPrincipal principal)
        {
            if (principal == null)
                //throw new ArgumentNullException(nameof(principal));
                return "employeeid";
            return principal.FindFirstValue("localizationapp:employeeid");
        }

        public static string SetCulture(this ClaimsPrincipal principal)
        {
            if (principal == null)
                //throw new ArgumentNullException(nameof(principal));
                return "en-US";
            return principal.FindFirstValue("localizationapp:culture") ?? new AppSiteSettings().LoadFromConfiguration().DefaultCulture;
        }

        public static string SetFullName(this ClaimsPrincipal principal)
        {
            if (principal == null)
                //throw new ArgumentNullException(nameof(principal));
                return "FullName";
            return principal.FindFirstValue("localizationapp:fullname");
        }

        public static string SetEmployeeID(this ClaimsPrincipal principal)
        {
            if (principal == null)
                //throw new ArgumentNullException(nameof(principal));
                return "EmployeeID";
            return principal.FindFirstValue("localizationapp:employeeid");
        }
    }
}