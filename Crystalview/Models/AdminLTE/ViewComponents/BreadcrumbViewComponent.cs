using Global.Models;
using Microsoft.AspNetCore.Mvc;

namespace Global.ViewComponents
{
    public class BreadcrumbViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (ViewBag.Breadcrumb == null)
            {
                ViewBag.Breadcrumb = new List<Message>();
            }

            return View(ViewBag.Breadcrumb as List<Message>);
        }
    }
}
