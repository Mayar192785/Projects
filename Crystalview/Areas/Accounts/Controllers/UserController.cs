using DNTBreadCrumb.Core;
using Global.Globalization;
using Global.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Security.Claims;
using WTEG.Core;


namespace Global.Controllers
{
    //[Authorize]
    [Area("Accounts")]
    [BreadCrumb(Title = "Manage Users", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "glyphicon glyphicon-link")]
    [DisplayName("Manage UsersCont")]
    public class UserController : AppBaseController
    {
        #region define

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        private readonly IStringLocalizer<UserController> _controllerLocalizerizer;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            IStringLocalizer<SharedResource> localizer, IStringLocalizer<UserController> aboutLocalizerizer, IStringLocalizerFactory   strextlocFactory, 
                          ILogger<UserController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor) : base(_logger, localizer, strextlocFactory, null, accessor)

        {
            this.userManager = userManager;
            this.roleManager = roleManager;

            _controllerLocalizerizer = aboutLocalizerizer;
        }

        #endregion define

        #region index

        [BreadCrumb(Title = " Listing", Order = 1)]
        [DisplayName("Manage UsersCont")]
        [HttpGet]
        [HelpDefinition]
        public IActionResult Index()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            List<UserListViewModel> model = new List<UserListViewModel>();
            model = userManager.Users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                UserName = u.UserName
            }).ToList();
            return View(model);
        }

        [BreadCrumb(Title = " Listing", Order = 1)]
        [DisplayName("Manage Admin")]
        [HttpGet]
        [HelpDefinition]
        public IActionResult IndexAdmin()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexAdminPage"]);
            List<UserListViewModel> model = new List<UserListViewModel>();
            model = userManager.Users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                UserName = u.UserName
            }).ToList();
            return View(model);
        }

        [BreadCrumb(Title = " Listing", Order = 1)]
        [DisplayName("Manage Warehouse")]
        [HttpGet]
        [HelpDefinition]
        public IActionResult IndexWarehouse()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexWarehousePage"]);
            List<UserListViewModel> model = new List<UserListViewModel>();
            model = userManager.Users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                UserName = u.UserName
            }).ToList();
            return View(model);
        }

        [BreadCrumb(Title = " Listing", Order = 1)]
        [DisplayName("Manage Safe")]
        [HttpGet]
        [HelpDefinition]
        public IActionResult IndexSafe()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexSafePage"]);
            List<UserListViewModel> model = new List<UserListViewModel>();
            model = userManager.Users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                UserName = u.UserName
            }).ToList();
            return View(model);
        }

        #endregion index

        #region add user

        [HttpGet]
        public IActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();
            model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            }).ToList();
            return PartialView("_AddUser", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserViewModel model)
        {

            // 
            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        FullName = model.FullName,
                        UserName = model.UserName,
                        Email = model.Email,
                        Culture = model.Culture,
                        IsEnabled = true
                    };
                    IdentityResult result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        IdentityResult roledefault = await userManager.AddToRoleAsync(user, new AppSiteSettings().LoadFromConfiguration().UserRoleName);
                        foreach (var role in model.userRoles)
                        {
                            ApplicationRole applicationRole = await roleManager.FindByIdAsync(role);
                            if (applicationRole != null)
                            {
                                IdentityResult roleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                            }
                        }

                        #region calims add part

                        // add the claims to keep data in claim part
                        await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.GivenName, user.FullName));
                        //get the first name out of full anme
                        var Nickname = !String.IsNullOrWhiteSpace(user.FullName) && user.FullName.IndexOf(" ") > 0
                            ? user.FullName.Substring(0, user.FullName.IndexOf(" "))
                            : user.FullName;
                        await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.NickName, Nickname));
                        await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.Culture, user.Culture));
                        await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.AvatarURL, user.AvatarURL ?? "~"));
                        await userManager.AddClaimAsync(user, new Claim("IsEnabled", "true"));

                        #endregion calims add part

                        return Json(new { success = true, responseText = "user Created" });
                    }
                    else
                        return Json(new { success = false, responseText = result.ToString() });
                }
            }
            catch (Exception dex)
            {
                logger.LogError("User ID {0} is was not Saved with Error {1}  ", model.UserName, dex.Message);
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
            return PartialView("_AddUser", model);
        }

        #endregion add user

        #region edit user

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            EditUserViewModel model = new EditUserViewModel();
            model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            }).ToList();

            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    model.UserName = user.UserName;
                    model.FullName = user.FullName;
                    model.Email = user.Email;
                    model.Culture = user.Culture;
                    model.userRoles = userManager.GetRolesAsync(user).Result.ToList();// roleManager.Roles.Single(r => r.Name == userManager.GetRolesAsync(user).Result.Single()).Id;

                    #region calims add part

                    // add the claims to keep data in claim part
                    await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.GivenName, user.FullName));
                    //get the first name out of full anme
                    var Nickname = !String.IsNullOrWhiteSpace(user.FullName) && user.FullName.IndexOf(" ") > 0
                        ? user.FullName.Substring(0, user.FullName.IndexOf(" "))
                        : user.FullName;
                    await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.NickName, Nickname));
                    await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.Culture, (user.Culture ?? new AppSiteSettings().LoadFromConfiguration().DefaultCulture)));
                    await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.AvatarURL, (user.AvatarURL ?? "user.png")));

                    #endregion calims add part
                }
            }
            return PartialView("_EditUser", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, EditUserViewModel model)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = await userManager.FindByIdAsync(id);
                    if (user != null)
                    {
                        model.FullName = user.FullName;
                        model.Email = user.Email;
                        model.Culture = user.Culture;
                        model.UserName = user.UserName;
                        List<string> existingRoles = userManager.GetRolesAsync(user).Result.ToList();
                        //List<string> existingRolesId = roleManager.Roles.Single(r => r.Name == existingRole).Id;
                        IdentityResult result = await userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            foreach (var existingRole in existingRoles)
                            {
                                if (model.userRoles.Exists(x => x == existingRole))
                                {
                                    IdentityResult roleResult = await userManager.RemoveFromRoleAsync(user, existingRole);
                                }
                            }
                            foreach (var newRole in model.userRoles)
                            //if (roleResult.Succeeded)
                            {
                                ApplicationRole applicationRole = await roleManager.FindByIdAsync(newRole.ToString());
                                if (applicationRole != null)
                                {
                                    IdentityResult newRoleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                                    //if (newRoleResult.Succeeded)
                                    //{
                                    //    return RedirectToAction("Index");
                                    //}
                                }
                            }
                        }
                    }
                    return Json(new { success = true, responseText = "user Updated" });
                }

                return Json(new { success = false, responseText = "Invalid input" });
            }
            catch (Exception dex)
            {
                logger.LogError("user ID {0} is was not updated with Error {1}  ", model.FullName, dex.Message);
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
            //return PartialView("_EditUser", model);
        }

        #endregion edit user

        #region delete user

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            string name = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    name = applicationUser.FullName;
                }
            }
            return PartialView("_DeleteUser", name);
        }

        [HttpPost, ActionName("DeleteUser")]
        public async Task<IActionResult> DeleteUserConfirm(string id, IFormCollection form)
        {
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    IdentityResult result = await userManager.DeleteAsync(applicationUser);
                    if (result.Succeeded)
                    {
                        //return RedirectToAction("Index");

                        #region calims add part

                        // remove the claims to keep data in claim part
                        //await userManager.RemoveClaimAsync(applicationUser, CustomClaimTypes.GivenName));
                        ////get the first name out of full anme

                        //await userManager.AddClaimAsync(applicationUser, new Claim(CustomClaimTypes.NickName, Nickname));
                        //await userManager.AddClaimAsync(applicationUser, new Claim(CustomClaimTypes.Culture, user.Culture));
                        //await userManager.AddClaimAsync(applicationUser, new Claim(CustomClaimTypes.AvatarURL, user.AvatarURL));

                        #endregion calims add part

                        return Json(new { success = true, responseText = "user deleted" });
                    }
                }
            }
            return View();
        }

        #endregion delete user

        #region disable user

        [HttpGet]
        public async Task<IActionResult> DisableUser(string id)
        {
            string name = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    name = applicationUser.FullName;
                }
            }
            return PartialView("_DisableUser", name);
        }

        [HttpPost, ActionName("DisableUser")]
        public async Task<IActionResult> DisableUserConfirm(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)

                    applicationUser.IsEnabled = false;
                IdentityResult result = await userManager.UpdateAsync(applicationUser);
                if (result.Succeeded)
                {
                    //return RedirectToAction("Index");

                    #region calims add part

                    // remove the claims to keep data in claim part
                    //await userManager.RemoveClaimAsync(applicationUser, CustomClaimTypes.GivenName));
                    ////get the first name out of full anme

                    //await userManager.AddClaimAsync(applicationUser, new Claim(CustomClaimTypes.NickName, Nickname));
                    //await userManager.AddClaimAsync(applicationUser, new Claim(CustomClaimTypes.Culture, user.Culture));
                    //await userManager.AddClaimAsync(applicationUser, new Claim(CustomClaimTypes.AvatarURL, user.AvatarURL));

                    #endregion calims add part

                    return Json(new { success = true, responseText = "user Disabled" });
                }
            }

            return View();
        }

        #endregion disable user

        #region enable user

        [HttpGet]
        public async Task<IActionResult> EnableUser(string id)
        {
            string name = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    name = applicationUser.FullName;
                }
            }
            return PartialView("_EnableUser", name);
        }

        [HttpPost, ActionName("EnableUser")]
        public async Task<IActionResult> EnableUserConfirm(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    applicationUser.IsEnabled = true;
                    IdentityResult result = await userManager.UpdateAsync(applicationUser);
                    //await userManager.SetLockoutEndDateAsync(applicationUser, new DateTimeOffset(DateTime.UtcNow));
                    var lockresult = userManager.SetLockoutEndDateAsync(applicationUser, null);

                    if (result.Succeeded && lockresult.Result.Succeeded)
                    {
                        //return RedirectToAction("Index");

                        #region calims add part

                        // remove the claims to keep data in claim part
                        //await userManager.RemoveClaimAsync(applicationUser, CustomClaimTypes.GivenName));
                        ////get the first name out of full anme

                        //await userManager.AddClaimAsync(applicationUser, new Claim(CustomClaimTypes.NickName, Nickname));
                        //await userManager.AddClaimAsync(applicationUser, new Claim(CustomClaimTypes.Culture, user.Culture));
                        //await userManager.AddClaimAsync(applicationUser, new Claim(CustomClaimTypes.AvatarURL, user.AvatarURL));

                        #endregion calims add part

                        return Json(new { success = true, responseText = "user Enabled" });
                    }
                }
            }
            return View();
        }

        #endregion enable user

 

        #region Password reset user

        [HttpGet]
        public async Task<IActionResult> PasswordRestUser(string id)
        {
            string name = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    name = applicationUser.FullName;
                }
            }
            return PartialView("_PasswordResetUser", name);
        }

        [HttpPost]
        public async Task<IActionResult> PasswordRestUser(string id, IFormCollection form)
        {
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    var token = userManager.GeneratePasswordResetTokenAsync(applicationUser).Result;
                    IdentityResult result = await userManager.ResetPasswordAsync(applicationUser, token, "User@123");
                    if (result.Succeeded)
                    {
                        return Json(new { success = true, responseText = "user Password reset" });
                    }
                }
            }
            return View();
        }

        #endregion Password reset user
    }
}