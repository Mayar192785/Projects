using Global.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WTEG.Core;

namespace FinanceCore.Controllers.General
{
    //[Authorize]
    [Area("General")]
    public class HomeController : Controller
    {
        [HelpDefinition]
        public IActionResult Index()
        {
            //AddPageHeader(Configuration.GetSection("AppInfo")["Name"], _controllerLocalizerizer["IndexPage"]);
            SiteUtils.LoggedInUser = User.Identity.Name;
            SiteUtils.ActiveMenu = 2;
            return View();
        }


    }
}