using Microsoft.AspNetCore.Mvc;

namespace Global.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
