using Global.Models;
using Microsoft.AspNetCore.Mvc;

namespace Global.ViewComponents
{
    public class MenuNotificationViewComponent : ViewComponent
    {
        public MenuNotificationViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {
            if (ViewBag.Notifications == null)
            {
                ViewBag.Notifications = new List<Message>();
            }

            return View(ViewBag.Notifications as List<Message>);
        }

        private List<Message> GetData()
        {
            var messages = new List<Message>();
            messages.Add(new Message
            {
                Id = 1,
                FontAwesomeIcon = "fa fa-users text-aqua",
                ShortDesc = "5 new members joined today",
                URLPath = "#",
            });

            return messages;
        }
    }
}