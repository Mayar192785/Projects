using DNTBreadCrumb.Core;
using Global.DBModels;
using Global.Globalization;
using Global.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Data;
using WTEG.Core;


namespace Global.Controllers
{
    //[Authorize]
    [Area("Accounts")]
    [BreadCrumb(Title = "Roles", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "glyphicon glyphicon-link")]
    [DisplayName("RolesCont")]
    public class ApplicationRoleController : AppBaseController
    {
        #region local vars and init

        private readonly RoleManager<ApplicationRole> roleManager;

        private readonly IStringLocalizer<ApplicationRoleController> _controllerLocalizerizer;

        public ApplicationRoleController(RoleManager<ApplicationRole> roleManager
            , IStringLocalizer<SharedResource> localizer, IStringLocalizer<ApplicationRoleController> aboutLocalizerizer, IStringLocalizerFactory   strextlocFactory,  ILogger<ApplicationRoleController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor) : base(_logger, localizer, strextlocFactory, null, accessor)


        {
            this.roleManager = roleManager;

            _controllerLocalizerizer = aboutLocalizerizer;
        }

        #endregion local vars and init

        #region index

        [BreadCrumb(Title = " Listing", Order = 1)]
        [DisplayName("RolesCont")]
        [HelpDefinition]
        [HttpGet]
        public IActionResult Index()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            List<ApplicationRoleListViewModel> model = new List<ApplicationRoleListViewModel>();
            var roles = roleManager.Roles.Include<ApplicationRole>("Users").ToList();
            model = roles.Select(r => new ApplicationRoleListViewModel
            {
                RoleName = r.Name,
                Id = r.Id,
                Description = r.Description,
                NumberOfUsers = r.Users.Count
            }).ToList();
            return View(model);
        }

        #endregion index

        #region Add roles

        [HttpGet]
        public async Task<IActionResult> AddEditApplicationRole(string id)
        {
            ApplicationRoleViewModel model = new ApplicationRoleViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationRole applicationRole = await roleManager.FindByIdAsync(id);
                if (applicationRole != null)
                {
                    model.Id = applicationRole.Id;
                    model.RoleName = applicationRole.Name;
                    model.Description = applicationRole.Description;
                }
            }
            return PartialView("_AddEditApplicationRole", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditApplicationRole(string id, ApplicationRoleViewModel model)
        {

            //
            try
            {
                //if (ModelState.IsValid)
                {
                    bool isExist = !String.IsNullOrEmpty(id);
                    ApplicationRole applicationRole = isExist ? await roleManager.FindByIdAsync(id) :
                   new ApplicationRole
                   {
                       CreatedDate = DateTime.UtcNow
                   };
                    applicationRole.Id = Guid.NewGuid().ToString();
                    applicationRole.Name = model.RoleName;
                    applicationRole.Description = model.Description;
                    applicationRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    IdentityResult roleRuslt = isExist ? await roleManager.UpdateAsync(applicationRole)
                                                        : await roleManager.CreateAsync(applicationRole);
                    if (roleRuslt.Succeeded)
                    {
                        //return RedirectToAction("Index");
                        return Json(new { success = true, responseText = "Roles Saved" });
                    }
                }
            }
            catch (Exception dex)
            {
                logger.LogError("role ID {0} is was not Saved with Error {1}  ", model.RoleName, dex.Message);
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
            return View(model);
        }

        #endregion Add roles

        #region delete roles

        [HttpGet]
        public async Task<IActionResult> DeleteApplicationRole(string id)
        {
            string name = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationRole applicationRole = await roleManager.FindByIdAsync(id);
                if (applicationRole != null)
                {
                    name = applicationRole.Name;
                }
            }
            return PartialView("_DeleteApplicationRole", name);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteApplicationRole(string id, IFormCollection form)
        {


            try
            {
                if (!String.IsNullOrEmpty(id))
                {
                    ApplicationRole applicationRole = await roleManager.FindByIdAsync(id);
                    if (applicationRole != null)
                    {
                        IdentityResult roleRuslt = roleManager.DeleteAsync(applicationRole).Result;
                        if (roleRuslt.Succeeded)
                        {
                            //return RedirectToAction("Index");
                            logger.LogInformation($"{MethodTable}  {id} is {MethodAction} Scussefully  ");
                            return Json(new { success = true, responseText = "Role Deleted" });
                        }
                    }
                }
            }
            catch (Exception dex)
            {
                logger.LogError("role ID {0} is was not deleted with Error {1}  ", id, dex.Message);
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
            return View();
        }

        #endregion delete roles

        #region menu tree

        [BreadCrumb(Title = "Roles Menu", Order = 1)]
        [DisplayName("RolesCont")]
        [HelpDefinition]
        [HttpGet]
        public IActionResult AddRoleToMenu(string id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["AddMenuPage"]);
            string name = id;
            var model = new RoleToMenuViewModel()
            {
                RoleName = id
            };
            return View(model);
        }

        [HttpGet]
        public JsonResult GetMenuTreeData()
        {
            var tree = new PDSAMenuDatabase(SiteUtils.strConnection, "en-US", null).LoadFlat();

            var nodes = new List<JsTreeModel>();
            foreach (var node in tree)
            {
                nodes.Add(new JsTreeModel()
                {
                    id = node.MenuId.ToString(),
                    parent = (node.ParentMenuId == -1 ? "#" : node.ParentMenuId.ToString()),
                    text = node.MenuTitle,
                    icon = node.Icon,
                    opened = true
                });
            }

            return Json(nodes);
        }

        public ActionResult UpdateRoleMenu([FromBody] string ids)
        {


            try
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '	' };

                string[] words = ids.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

                if (words != null && words.Length > 0)
                {
                    string RoleHead = words[0];
                    foreach (var mid in words.Skip(1))
                    {
                        tblsyMenuRoles ChosenMenu = new tblsyMenuRoles()
                        {
                            MenuID = Int32.Parse(mid),
                            RoleID = RoleHead
                        };

                        int RetID = new syMenuRolesVM()
                        {
                            syMenuRoles = ChosenMenu
                        }.Insert();
                        logger.LogInformation($"{MethodTable}    is {MethodAction} Scussefully  ");
                        //
                        //var fcJobCategory = new fcJobCategoryVM();
                        //                       fcJobCategory.LogonUser = User.Identity.Name;
                        //                        bool done = fcJobCategory.Delete(Convert.ToInt32(id));
                        logger.LogInformation(" syMenuRolesVM ID {0} is Insered Scussefully  ", RetID);
                    }
                    return Json(new { success = true, responseText = "Inserted Scussefully" });
                }
                return Json(new { success = false, responseText = "Nothing Selected" });
            }
            catch (Exception dex)
            {
                logger.LogError("syMenuRolesVM ID {0} is was not Inserted with Error {1}  ", ids, dex.Message);
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
        }

        public ActionResult AddAllMenuRole([FromQuery] string RoleName)
        {


            try
            {
                int RetID = new syMenuRolesVM().AddAllMenu(RoleName);
                //HttpContext.Request.Form["id"]);

                logger.LogInformation(" syMenuRolesVM ID {0} is Insered Scussefully  ", RetID);
                AddPageAlerts(PageAlertType.Info, $" {MethodTable} ID {RetID} is Insered Scussefully  ");
                // return Json(new { success = true, responseText = "Inserted Scussefully" });
                return RedirectToAction("Index");
            }
            catch (Exception dex)
            {
                logger.LogError("syMenuRolesVM ID {0} is was not Inserted with Error {1}  ", RoleName, dex.Message);
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                //return Json(new { success = false, responseText = Models.SiteUtils.FriendlyErrorMessage(dex) });
                AddPageAlerts(PageAlertType.Info, $" syMenuRolesVM ID {RoleName} failed to add menu  ");
            }
            return View();
        }

        #endregion menu tree
 
    }
}