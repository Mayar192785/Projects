using Global.Common;
using Global.Models;
using Microsoft.AspNetCore.Mvc;
using WTEG.Core;
using WTEG.Core.Tools;

namespace Global.ViewComponents
{
    public class MenubarViewComponent : ViewComponent
    {
        public MenubarViewComponent()
        {
        }

        public List<SidebarMenu> GetChildren(List<PDSAMenuItem>? FullMenu, PDSAMenuItem pitem)
        {
            var sidebars = new List<SidebarMenu>();

            var level2 = FullMenu.Where(m => m.ParentMenuId == pitem.MenuId).ToList();
            if (level2.Count > 0)//parent
            {
                sidebars.Add(ModuleHelper.AddTree(pitem.MenuId, pitem.MenuTitle, pitem.Icon));//header
                var sublvl2 = new List<SidebarMenu>();


                foreach (var subItem2 in level2)
                {
                    var counter = new Tuple<int, int, int>(subItem2.DisplayOrder, 0, 0);
                    sublvl2.AddRange(GetChildren(FullMenu, subItem2));
                    //ModuleHelper.AddItem(subItem2.MenuTitle, subItem2.MenuAction, subItem2.Icon, counter));

                }
                sidebars.Last().TreeChild = sublvl2;

            }
            else
            {
                var counter = new Tuple<int, int, int>(pitem.DisplayOrder, 0, 0);
                sidebars.Add(ModuleHelper.AddItem(pitem.MenuId, pitem.MenuTitle, pitem.MenuAction, pitem.Icon, counter));
            }

            return sidebars;
        }

        public List<SidebarMenu> fillIn(List<PDSAMenuItem>? FullMenu, PDSAMenuItem pitem)
        {
            var sidebars = new List<SidebarMenu>();

            var level2 = FullMenu.Where(m => m.ParentMenuId == pitem.MenuId).ToList();
            if (level2.Count > 0)//parent
            {
                sidebars.Add(ModuleHelper.AddTree(pitem.MenuId, pitem.MenuTitle));//header
                var sublvl2 = new List<SidebarMenu>();


                foreach (var subItem2 in level2)
                {
                    var counter = new Tuple<int, int, int>(subItem2.DisplayOrder, 0, 0);
                    sublvl2.Add(ModuleHelper.AddItem(subItem2.MenuId, subItem2.MenuTitle, subItem2.MenuAction, subItem2.Icon, counter));
                    fillIn(FullMenu, subItem2);
                }
                sidebars.Last().TreeChild = sublvl2;

            }
            else
            {
                var counter = new Tuple<int, int, int>(pitem.DisplayOrder, 0, 0);
                sidebars.Add(ModuleHelper.AddItem(pitem.MenuId, pitem.MenuTitle, pitem.MenuAction, pitem.Icon, counter));
            }

            return sidebars;
        }
        public IViewComponentResult Invoke(string filter)
        {
            //you can do the access rights checking here by using session, user, and/or filter parameter
            var sidebars = new List<SidebarMenu>();

            //if (((ClaimsPrincipal)User).GetUserProperty("AccessProfile").Contains("VES_008, Payroll"))
            //{
            //}

            //sidebars.Add(ModuleHelper.AddHeader("MAIN NAVIGATION"));


            PDSAMenuItemManager mgr;
            // should get use culture here not static
            PDSAMenuDatabase injector =
            new PDSAMenuDatabase(SiteUtils.GeneralConnection
            , CultureHelper.GetCurrentCulture()
            , User.Identity.Name ?? "Admin"
            );

            mgr = new PDSAMenuItemManager(injector);


            mgr.Load();
            //mgr.LoadFlat(); //NO USER check or roles ,flamenu

            List<PDSAMenuItem> myMenu = mgr.Menus;//.Take(1000).ToList();
            var plist = myMenu.Where(m => m.ParentMenuId == -1).ToList(); // This will list main menu items on which we'll apply loop to display them.
            if (plist != null && plist.Count > 0) //we have menu
            {
                foreach (var pitem in plist) // 
                {

                    sidebars.AddRange(GetChildren(myMenu, pitem));
                }
            }

            return View(sidebars);
        }
    }
}
