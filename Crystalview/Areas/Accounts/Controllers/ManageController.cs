using DNTBreadCrumb.Core;
using Global.Globalization;
using Global.Models;
using Global.Models.ManageViewModels;
using Global.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using WTEG.Core;


namespace Global.Controllers
{
    //[Authorize]
    [Area("Accounts")]
    //[Authorize]
    [BreadCrumb(Title = "Manage Security", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "glyphicon glyphicon-link")]
    [DisplayName("Manage SecurityCont")]
    public class ManageController : AppBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //  readonly string _externalCookieScheme;
       // private readonly IEmailSender _emailSender;

        private readonly IStringLocalizer<ManageController> _controllerLocalizerizer;

        public ManageController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager
          // IEmailSender emailSender

            , IStringLocalizer<SharedResource> localizer
            , IStringLocalizer<ManageController> aboutLocalizerizer
            , IStringLocalizerFactory   strextlocFactory
            , 
             ILogger<ManageController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor) : base(_logger, localizer, strextlocFactory, null, accessor)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailSender = emailSender;

            _controllerLocalizerizer = aboutLocalizerizer;
        }

        //
        // GET: /Manage/Index
        [BreadCrumb(Title = " Listing", Order = 1)]
        [DisplayName("Manage SecurityCont")]
        [HttpGet]
        [HelpDefinition]
        public async Task<IActionResult> Index(ManageMessageId? message = null)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);

            ViewData["StatusMessage"] =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var model = new IndexViewModel
            {
                HasPassword = await _userManager.HasPasswordAsync(user),
                PhoneNumber = await _userManager.GetPhoneNumberAsync(user),
                TwoFactor = await _userManager.GetTwoFactorEnabledAsync(user),
                Logins = await _userManager.GetLoginsAsync(user),
                BrowserRemembered = await _signInManager.IsTwoFactorClientRememberedAsync(user),
                AuthenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user)
            };
            return View(model);
        }

        #region change password

        //
        // GET: /Manage/ChangePassword
        [BreadCrumb(Title = "Manage Security Change Password", Order = 1)]
        [DisplayName("Manage SecurityCont")]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["ChangePassordPage"]);
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        ////[ValidateAntiForgeryToken]
        [HelpDefinition]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    logger.LogInformation("User changed their password successfully.");
                    return RedirectToAction(nameof(Index), new { Message = ManageMessageId.ChangePasswordSuccess });
                }
                AddErrors(result);
                return View(model);
            }
            return RedirectToAction(nameof(Index), new { Message = ManageMessageId.Error });
        }

        #endregion change password

        #region set password

        //
        // GET: /Manage/SetPassword
        [BreadCrumb(Title = "Manage Security Set Password", Order = 1)]
        [DisplayName("Manage SecurityCont")]
        [HttpGet]
        public IActionResult SetPassword()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["SetPasswordPage"]);
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        ////[ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await _userManager.AddPasswordAsync(user, model.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(Index), new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
                return View(model);
            }
            return RedirectToAction(nameof(Index), new { Message = ManageMessageId.Error });
        }

        #endregion set password

        #region configure preference

        [BreadCrumb(Title = "Manage Security User Preference", Order = 1)]
        [DisplayName("Manage SecurityCont")]
        [HttpGet]
        [HelpDefinition]
        public async Task<IActionResult> ConfigurePreferenceInfo()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["ProfilePage"]);
            //var user = await _userManager.FindByIdAsync(User.GetUserId());
            var user = await GetCurrentUserAsync();
            var viewModel = new ConfigurePreferenceInfoViewModel
            {
                Culture = user.Culture,
                FullName = user.FullName,
                Email = user.Email
            };

            return View(viewModel);
        }

        [HttpPost]
        [HelpDefinition]
        public async Task<IActionResult> ConfigurePreferenceInfo(ConfigurePreferenceInfoViewModel viewModel)
        {
            var user = await GetCurrentUserAsync();
            user.Culture = viewModel.Culture;
            user.FullName = viewModel.FullName;
            user.Email = viewModel.Email;

            await _userManager.UpdateAsync(user);

            ///One problem however is that CustomSignInManager.CreateUserPrincipalAsync()
            ///only going to be called when the user signs in.
            ///So once the user is signed in and they update the settings,
            ///the claims will not be updated. For now the only way I have figured
            ///out to do this is to call SignInManager.SignInAsync() again

            await _signInManager.SignInAsync(user, true); // Force the CreateUserPrincipalAsync method on our CustomSignInManager to be called again

            SiteUtils.SetLanguage(Response, user.Culture ?? new AppSiteSettings().LoadFromConfiguration().DefaultCulture);

            return RedirectToAction("Index");
        }

        #endregion configure preference

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                //ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            AddLoginSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        #endregion Helpers
    }
}