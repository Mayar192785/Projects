using Global.Common.Extensions;
using Global.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Global.ViewComponents
{
    public class MenuMessageViewComponent : ViewComponent
    {
        public MenuMessageViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {
            var messages = GetData();
            return View(messages);
        }

        private List<Message> GetData()
        {
            var messages = new List<Message>();

            messages.Add(new Message
            {
                Id = 1,
                UserID = Global.Common.Extensions.IdentityExtension.GetUserProperty((ClaimsPrincipal)User,CustomClaimTypes.NameIdentifier),
                DisplayName = "Support Team",
                AvatarURL = "/images/user.png",
                ShortDesc = "Why not buy a new awesome theme?",
                TimeSpan = "5 mins",
                URLPath = "#",
            });

            messages.Add(new Message
            {
                Id = 1,
                UserID = Global.Common.Extensions.IdentityExtension.GetUserProperty((ClaimsPrincipal)User, CustomClaimTypes.NameIdentifier),
                DisplayName = "Ken",
                AvatarURL = "/images/user.png",
                ShortDesc = "For approval",
                TimeSpan = "15 mins",
                URLPath = "#",
            });

            return messages;
        }
    }
}