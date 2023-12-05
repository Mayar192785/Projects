using Global.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WTEG.Core;

namespace FinanceCore.Controllers.Menu
{
    [Area("Menu")]
    public class HomeController : Controller
    {
        [HelpDefinition]
        public IActionResult Index()
        {
            //AddPageHeader(Configuration.GetSection("AppInfo")["Name"], _controllerLocalizerizer["IndexPage"]);
            SiteUtils.LoggedInUser = User.Identity.Name;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}