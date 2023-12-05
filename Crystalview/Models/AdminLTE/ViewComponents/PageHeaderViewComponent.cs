using Microsoft.AspNetCore.Mvc;

namespace Global.ViewComponents
{
    public class PageHeaderViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Tuple<string, string> message;

            if (ViewBag.PageHeader == null)
            {
                message = Tuple.Create(string.Empty, string.Empty);
            }
            else
            {
                message = ViewBag.PageHeader as Tuple<string, string>;
            }
            return View(message);
        }
    }
}
