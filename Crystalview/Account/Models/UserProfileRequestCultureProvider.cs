using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace Global.Models
{
    public class UserProfileRequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        //{
        //    throw new NotImplementedException();
        //}

        //public override Task<RequestCulture> DetermineRequestCulture(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            if (!httpContext.User.Identity.IsAuthenticated)
                return Task.FromResult((ProviderCultureResult)null);

            string userCulture = null;
            string userUICulture = null;

            string cultureClaim = Global.Models.ApplicationClaimsPrincipalFactory.GetCulture(httpContext.User);
            if (!string.IsNullOrWhiteSpace(cultureClaim))
            {
                userCulture = cultureClaim;
                userUICulture = cultureClaim;
            }

            if (userCulture == null && userUICulture == null)
            {
                // No values specified for either so no match
                return Task.FromResult((ProviderCultureResult)null);
            }

            if (userCulture != null && userUICulture == null)
            {
                // Value for culture but not for UI culture so default to culture value for both
                userUICulture = userCulture;
            }

            var requestCulture = new ProviderCultureResult(userCulture);

            return Task.FromResult(requestCulture);
        }
    }
}