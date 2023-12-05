using Global.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WTEG.Core;

namespace FinanceCore.Controllers.Admin
{
    //[Authorize]
    [Area("Area")]
    public class HomeController : Controller
    {
        [HelpDefinition]
        public IActionResult Index()
        {
            //AddPageHeader(Configuration.GetSection("AppInfo")["Name"], _controllerLocalizerizer["IndexPage"]);
            SiteUtils.LoggedInUser = User.Identity.Name;
            SiteUtils.ActiveMenu = 1;
            return View();
        }

        [HelpDefinition]
        public IActionResult UserPreferences()
        {
            //AddPageHeader(Configuration.GetSection("AppInfo")["Name"], _controllerLocalizerizer["IndexPage"]);
            SiteUtils.LoggedInUser = User.Identity.Name;
            SiteUtils.ActiveMenu = 15;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}