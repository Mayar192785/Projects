using Global.DBModels;
using Global.Globalization;
using Global.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using NonFactors.Mvc.Lookup;
using System.Globalization;



namespace Global.Controllers
{
    public class AppBaseController : Controller
    {
        // local vars to be used every where

        public readonly ILogger<AppBaseController> logger;
        public readonly IStringLocalizer<SharedResource> _localizer;

        //public readonly IStringLocalizer<AppBaseController> _controllerLocalizerizer;
        public readonly IStringLocalizerFactory   _stringLocalizerFactory;

        public readonly LocalizationModelContext _context;

        //private readonly ControllerActionDescriptor _actionDescriptorProvider;
        private IActionContextAccessor _accessor;
        public string MethodTable = "GeneralTable";
        public string MethodAction = "generaMethod";

        public string LogonUser;


        public ActionResult Directory(string directory)
        {
            ViewBag.CurrentDirectory = directory;
            ViewBag.CurrentPage = "Starter Page"; // Set the current page title dynamically
            return View();
        }

        public bool IsLoggedIn()
        {
            return LogonUser != null;

            //string xx =  User.
        }

        public AppBaseController(ILogger<AppBaseController> _logger
             , IStringLocalizer<SharedResource> localizer
            , IStringLocalizerFactory   stringLocalizerFactory
             , LocalizationModelContext context
            , IActionContextAccessor accessor
                         )
        {
            _localizer = localizer;
            //_controllerLocalizerizer = aboutLocalizerizer;
            _stringLocalizerFactory = stringLocalizerFactory;
            //_context = context;
            logger = _logger;

            _accessor = accessor;

            string actionName = ((ControllerContext)((ActionContextAccessor)_accessor).ActionContext).ActionDescriptor.ActionName.ToString();
            string controllerName = ((ControllerContext)((ActionContextAccessor)_accessor).ActionContext).ActionDescriptor.ControllerName.ToString();
            MethodTable = controllerName;
            MethodAction = actionName;

            //SiteUtils.LoggedInUser = User.Identity.Name;
            //var user = System.Web.HttpContext.Current.User;

            if (User != null)
            {
                LogonUser = User.Identity.Name ?? "Unknown";
                SiteUtils.LoggedInUser = User.Identity.Name ?? "Unknown";

                #region always call this to enforce localization settings

                string culture = CultureInfo.CurrentCulture.Name;
                SiteUtils.FixAndSetLanguage(culture);

                #endregion always call this to enforce localization settings
            }
            else
            {
                LogonUser = "Anonymus";
                SiteUtils.LoggedInUser = "Anonymus";
            }
        }

        #region standard parts in page

        /// <summary>
        /// admin LTE bread crumb part , is added to all controllers and pages
        /// </summary>
        /// <param name="displayName">name to be shown</param>
        /// <param name="urlPath">URL for the navigation</param>
        internal void AddBreadcrumb(string displayName, string urlPath)
        {
            List<Message> messages;

            if (ViewBag.Breadcrumb == null)
            {
                messages = new List<Message>();
            }
            else
            {
                messages = ViewBag.Breadcrumb as List<Message>;
            }

            messages.Add(new Message { DisplayName = displayName, URLPath = urlPath });
            ViewBag.Breadcrumb = messages;
        }

        /// <summary>
        /// ADMIN LTE page header for all pages
        /// </summary>
        /// <param name="pageHeader">large header part</param>
        /// <param name="pageDescription">small font part after it </param>
        internal void AddPageHeader(string pageHeader = "", string pageDescription = "")
        {
            ViewBag.PageHeader = Tuple.Create(pageHeader, pageDescription);
        }

        #endregion standard parts in page

        #region page alert

        internal enum PageAlertType
        {
            Error,
            Info,
            Warning,
            Success
        }

        internal void AddPageAlerts(PageAlertType pageAlertType, string description)
        {
            List<Message> messages;

            if (ViewBag.PageAlerts == null)
            {
                messages = new List<Message>();
            }
            else
            {
                messages = ViewBag.PageAlerts as List<Message>;
            }

            messages.Add(new Message { Type = pageAlertType.ToString().ToLower(), ShortDesc = description });
            ViewBag.PageAlerts = messages;
        }

        /// <summary>
        /// Notifications
        /// </summary>
        /// <param name="messages"></param>

        internal void AddNotifications(List<Message> messages)
        {
            //List<Message> messages;

            if (messages == null)
            {
                messages = new List<Message>();
            }
            else
            {
                ViewBag.Notifications = messages;
            }

            //messages.Add(new Message { Type = pageAlertType.ToString().ToLower(), ShortDesc = description });
            //ViewBag.Notifications = messages;
        }

        #endregion page alert

        #region lookup filter clear

        /// <summary>
        /// clear filter to avoid errors in reserach
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formAction"></param>
        /// <returns></returns>
        ///

        public void ClearFilter(ref LookupFilter filter)
        {
            if (filter.Ids.Count > 0)
                filter.Ids.Remove(filter.Ids[0]);
            if (filter.Selected.Count > 0)
                filter.Selected.Remove(filter.Selected[0]);
        }

        #endregion lookup filter clear

      

        #region utils functions and short hands

        public string GetMessage(string ResouceID, string ResuceKey)
        {

            return "";
        }
        #endregion
    }
}