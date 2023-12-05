using Global.Controllers;
using Global.Globalization;
using Global.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using WTEG.Core;
using WTEG.Core.Tools;

namespace FinanceCore.Controllers

{
    public class HomeController : AppBaseController
    {
        #region loicalizations vars

        private readonly IStringLocalizer<HomeController> _controllerLocalizerizer;

        public HomeController(
            IStringLocalizer<SharedResource> localizer, 
            IStringLocalizer<HomeController> aboutLocalizerizer, 
            IStringLocalizerFactory   strextlocFactory, 
            
           ILogger<HomeController> _logger, 
            Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor) 
            : base(_logger, localizer, strextlocFactory, null, accessor)

        {
            _controllerLocalizerizer = aboutLocalizerizer;
        }

        #endregion loicalizations vars

        [HelpDefinition]
        public IActionResult Index()
        {
            ////AddPageHeader(Configuration.GetSection("AppInfo")["Name"], _controllerLocalizerizer["IndexPage"]);
            SiteUtils.LoggedInUser = User.Identity.Name;

            //var DataPart = new rlReservationInstallmentVM().GetAll()
            //      .Where(x => x.DueDate.HasValue)
            //      .Where(x => x.DueDate.Value.Month == DateTime.Now.Month && x.DueDate.Value.Year == DateTime.Now.Year)
            //.Where(x => !x.IsPaid)
            //;
            //int Counter = DataPart.Count();
            //Message message = new Message();
            //message.URLPath = "/RealState/rlReservationInstallment/IndexFullMonth";
            //message.FontAwesomeIcon = "";
            //message.ShortDesc = Counter.ToString() + " Monthly Installement Dues ";

            //List<Message> messages = new List<Message>();
            //messages.Add(message);

            //AddNotifications(messages);

            var culture = Global.Models.ApplicationClaimsPrincipalFactory.GetCulture(User);
            CultureHelper.SetUserLocale("ar-EG", "ar-EG");

            return View();
        }

        public IActionResult Index1()
        {
            ////AddPageHeader(Configuration.GetSection("AppInfo")["Name"], _controllerLocalizerizer["IndexPage"]);
            SiteUtils.LoggedInUser = User.Identity.Name;

            //var DataPart = new rlReservationInstallmentVM().GetAll()
            //      .Where(x => x.DueDate.HasValue)
            //      .Where(x => x.DueDate.Value.Month == DateTime.Now.Month && x.DueDate.Value.Year == DateTime.Now.Year)
            //.Where(x => !x.IsPaid)
            //;
            //int Counter = DataPart.Count();
            //Message message = new Message();
            //message.URLPath = "/RealState/rlReservationInstallment/IndexFullMonth";
            //message.FontAwesomeIcon = "";
            //message.ShortDesc = Counter.ToString() + " Monthly Installement Dues ";

            //List<Message> messages = new List<Message>();
            //messages.Add(message);

            //AddNotifications(messages);

            var culture = Global.Models.ApplicationClaimsPrincipalFactory.GetCulture(User); ;
            CultureHelper.SetUserLocale(culture, culture);

            return View();
        }

        public IActionResult Index2()
        {
            //AddPageHeader(Configuration.GetSection("AppInfo")["Name"], _controllerLocalizerizer["IndexPage"]);
            SiteUtils.LoggedInUser = User.Identity.Name;
            var culture = Global.Models.ApplicationClaimsPrincipalFactory.GetCulture(User); ;
            CultureHelper.SetUserLocale(culture, culture);
            return View();
        }

        public IActionResult MainPage()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

		public IActionResult UserPreferences()
		{
			return View();
		}

		public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            var exception = HttpContext.Features
            .Get<IExceptionHandlerFeature>();

            ViewData["statusCode"] = HttpContext.Response.StatusCode;
            ViewData["message"] = exception.Error.Message;
            ViewData["stackTrace"] = exception.Error.StackTrace;

            return View();
        }

        public IActionResult ChangeLanguage()
        {
            //AddPageHeader(Configuration.GetSection("AppInfo")["Name"], _controllerLocalizerizer["IndexPage"]);
            //SiteUtils.LoggedInUser = User.Identity.Name;
            //var culture = User.GetCulture();
            //CultureHelper.SetUserLocale(culture, culture);
            return View();
        }

        [HttpPost]
        public IActionResult ChangeLanguage(IFormCollection formData)
        {
            //AddPageHeader(Configuration.GetSection("AppInfo")["Name"], _controllerLocalizerizer["IndexPage"]);
            SiteUtils.LoggedInUser = User.Identity.Name;
            var culture = Global.Models.ApplicationClaimsPrincipalFactory.GetCulture(User); ;
            // CultureHelper.SetUserLocale(culture, culture);
            return View();
        }
    }
}