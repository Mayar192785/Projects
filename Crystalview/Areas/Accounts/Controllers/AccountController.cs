using DNTBreadCrumb.Core;
using FinanceCore.Controllers;
using Global.Globalization;
using Global.Models;
using Global.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
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
    [BreadCrumb(Title = "Manage Accounts", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "glyphicon glyphicon-link")]
    [DisplayName("Manage AccountCont")]
    public class AccountController : AppBaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly IStringLocalizer<AccountController> _controllerLocalizerizer;

        public AccountController(SignInManager<ApplicationUser> signInManager
            , IStringLocalizer<SharedResource> localizer, IStringLocalizer<AccountController> aboutLocalizerizer, IStringLocalizerFactory   strextlocFactory, 
                          ILogger<AccountController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor) : base(_logger, localizer, strextlocFactory, null, accessor)
        {
            this.signInManager = signInManager;

            _controllerLocalizerizer = aboutLocalizerizer;
        }

        [HelpDefinition]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["LoginPage"]);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        ////[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    logger.LogInformation("user login {0}  ", model.UserName);
                    // do culture part

                    #region chnage culture after login

                    var loggeduser = await signInManager.UserManager.FindByNameAsync(model.UserName);
                    SiteUtils.LoggedInUser = loggeduser.UserName;
                    var culture = loggeduser.Culture ?? new AppSiteSettings().LoadFromConfiguration().DefaultCulture;
                    SiteUtils.SetLanguage(Response, culture);
                    logger.LogInformation($"chnaged culture to {culture}");

                    #endregion chnage culture after login

                    return RedirectToLocal(returnUrl ?? "/Home/MainPage");
                    //return RedirectToLocal(returnUrl ?? "/Home/ChooseCompany");
                }
                else
                if (result.IsLockedOut)
                {
                    logger.LogWarning("User account locked out.");
                    return RedirectToAction(nameof(Lockout));
                }
                else
                {
                    logger.LogError("Invalid login {0}  ", model.UserName);
                    //ModelState.AddModelError(string.Empty, $"Invalid login attempt.{model.UserName}");
                    AddPageAlerts(PageAlertType.Error, $"Invalid login attempt {model.UserName}");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpPost]
        ////[ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToLocal("Login");
            //RedirectToAction("Index", "Home");
        }

        [HelpDefinition]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [HelpDefinition]
        public IActionResult Lockout()
        {
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                // return RedirectToAction(nameof(HomeController.Index), "Home");
                return RedirectToAction(nameof(HomeController.Index), "home", new { area = "" });
            }
        }

        #region not used standard part

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            //var user = await signInManager.FindByIdAsync(userId);
            //if (user == null)
            //{
            //    throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            //}
            //var result = await _userManager.ConfirmEmailAsync(user, code);
            //return View(result.Succeeded ? "ConfirmEmail" : "Error");
            return View("Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string? code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        #endregion not used standard part
    }
}