using DNTBreadCrumb.Core;
using Global.Globalization;
using Global.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using NonFactors.Mvc.Lookup;
using System.ComponentModel;
using WTEG.Core;


namespace Global.Controllers
{
    [Area("Menu")]
    [BreadCrumb(Title = " Menu", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "glyphicon glyphicon-link")]
    [DisplayName("syMenuCont")]
    public class syMenuController : AppBaseController
    {
        //       FleetControl db = new FleetControl();
        //FleetUnitOfWork unitOfWork = new FleetUnitOfWork(new FleetControl());

        #region loicalizations vars

        private readonly IStringLocalizer<syMenuController> _controllerLocalizerizer;

        public syMenuController(IStringLocalizer<SharedResource> localizer, IStringLocalizer<syMenuController> aboutLocalizerizer, IStringLocalizerFactory   strextlocFactory, 
                          ILogger<syMenuController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor) : base(_logger, localizer, strextlocFactory, null, accessor)


        {
            _controllerLocalizerizer = aboutLocalizerizer;
        }

        #endregion loicalizations vars

        #region foriegn keys to use in lookup anjd data list

        #region get data list function for table syMenu

        public JsonResult AllsyMenu(LookupFilter filter)
        {
            ClearFilter(ref filter);
            return Json(new syMenuDatalist { Filter = filter }.GetData());
        }

        [HttpPost]
        public JsonResult GetsyMenuName(string ID)
        {
            return Json(new syMenuVM().GetNameByID(ID));
        }

        [HttpGet]
        public JsonResult getsyMenuSelect()
        {
            return Json(new syMenuVM().GetsyMenuForLkp());
        }

        #endregion get data list function for table syMenu

        #endregion foriegn keys to use in lookup anjd data list

        #region fill in list select2 for/and grid selection

        public JsonResult getsyMenuList()
        {
            return Json(new syMenuVM().GetAll().ToList());
        }

        public JsonResult getsyMenuFilteredList(string filterColumn, string filterValue)
        {
            return Json(new syMenuVM().GetAll().Where(o => o.ParentID.ToString().Contains(filterValue)).ToList());
        }

        #endregion fill in list select2 for/and grid selection

        #region Index

        // GET: syMenu
        [BreadCrumb(Title = " Listing", Order = 1)]
        [DisplayName("syMenuCont")]
        [HelpDefinition]
        public ActionResult Index()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            //var syMenuLocal= db.syMenu.Include(s => s.syMenu);
            return View(new syMenuVM().GetAll());
        }

        [BreadCrumb(Title = " Menu Listing tree", Order = 1)]
        [DisplayName("syMenuCont")]
        [HelpDefinition]
        public ActionResult IndexTree()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            //var syMenuLocal= db.syMenu.Include(s => s.syMenu);
            return View(new syMenuVM().GetAll());
        }

        [HttpGet]
        public JsonResult MenuTree()
        {
            var tree = new PDSAMenuDatabase(SiteUtils.strConnection, "en-US", null).LoadFlat();

            var nodes = new List<JsTreeModel>();
            foreach (var node in tree)
            {
                nodes.Add(new JsTreeModel()
                {
                    id = node.MenuId.ToString(),
                    parent = (node.ParentMenuId == -1 ? "#" : node.ParentMenuId.ToString()),
                    text = node.MenuTitle,
                    icon = node.Icon,
                    opened = true
                });
            }

            return Json(nodes);
        }

        #endregion Index

        #region Details

        // GET: syMenu/Details/5
        [BreadCrumb(Title = " Details", Order = 1)]
        [HelpDefinition]
        public ActionResult Details(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DetailsPage"]);
            syMenuVM syMenu = new syMenuVM().Find(id);
            if (syMenu == null)
            {
                return BadRequest();
            }
            return View(syMenu);
        }

        #endregion Details

        #region Create

        // GET: syMenu/Create
        [BreadCrumb(Title = " Create", Order = 1)]
        [HelpDefinition]
        public ActionResult Create()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["CreatePage"]);
            //ViewBag.syMenu = new SelectList(db.syMenu, "ID", "Name");

            return View();
        }

        // POST: syMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //////[ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,ParentID,Url,Description,OrderID,IsEnabled,Target,ParentTab,ActionName,ControllerName,IconName,")] syMenuVM syMenued)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    int? ID = syMenued.Insert();

                    AddPageAlerts(PageAlertType.Success, $" Created Scussefully  ");
                    //logger.Log(LogLevel.Info, "syMenu ID {0} is Created Scussefully  ", syMenuedsyMenu.ID);
                    logger.LogInformation(MethodTable + " ID {0} is " + MethodAction + " Scussefully  ", syMenued.ID);
                    return RedirectToAction("Edit", new { id = ID.ToString() });
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  was not {MethodAction} with Error   {dex.Message} ");
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
            }
            //ViewBag.syMenu = new SelectList(db.syMenu, "ID", "Name");

            return View(syMenued);
        }

        #endregion Create

        #region Edit

        // preapre view model for edit
        public syMenuVM EditHelper(int id)
        {
            syMenuVM syMenued = new syMenuVM().Find(id);
            //if (syMenued == null)
            //{
            //    return HttpNotFound();
            //}

            #region preapre details for page

            //preapre details
            var syMenuRecords = new syMenuVM();

            #endregion preapre details for page

            #region preapre details for page

            //preapre details
            var syMenuRolesRecords = new syMenuRolesVM().GetAll(id);

            #endregion preapre details for page

            #region preapre details for page

            //preapre details
            var syMenuNamesRecords = new syMenuNamesVM().GetAll(id);

            #endregion preapre details for page

            syMenuVM syMenuVMed = new syMenuVM()
            {
                ID = syMenued.ID
                     ,
                ParentID = syMenued.ParentID
                     ,
                Url = syMenued.Url
                     ,
                Description = syMenued.Description
                     ,
                OrderID = syMenued.OrderID
                     ,
                IsEnabled = syMenued.IsEnabled
                     ,
                Target = syMenued.Target
                     ,
                ParentTab = syMenued.ParentTab
                     ,
                ActionName = syMenued.ActionName
                     ,
                ControllerName = syMenued.ControllerName
                     ,
                IconName = syMenued.IconName
                  ,
                ShowGrid = true
                  //                 , syMenuDetails = syMenuRecords
                  ,
                syMenuRolesDetails = syMenuRolesRecords.ToList()
                  ,
                syMenuNamesDetails = syMenuNamesRecords.ToList()
            }
                ;

            return syMenuVMed;
        }

        // GET: syMenu/Edit/5
        [BreadCrumb(Title = " Edit", Order = 1)]
        [HelpDefinition]
        public ActionResult Edit(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["EditPage"]);

            syMenuVM syMenu = new syMenuVM().Find(id);
            if (syMenu == null)
            {
                return BadRequest();
            }
            //ViewBag.syMenu = new SelectList(db.syMenu, "ID", "Name");

            return View(EditHelper(id));
        }

        // POST: syMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BreadCrumb(Title = " Edit", Order = 1)]
        ////[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("ID,ParentID,Url,Description,OrderID,IsEnabled,Target,ParentTab,ActionName,ControllerName,IconName,")] syMenuVM syMenued)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    syMenued.Update();
                };

                logger.LogInformation(MethodTable + " ID {0} is " + MethodAction + " Scussefully  ", syMenued.ID);

                return RedirectToAction("Edit", syMenued.ID);
            }
            //           }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  was not {MethodAction} with Error   {dex.Message} ");
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
            }
            //ViewBag.syMenu = new SelectList(db.syMenu, "ID", "Name");

            return View(EditHelper(syMenued.ID));
        }

        #endregion Edit

        #region Delete

        // GET: syMenu/Delete/5
        [BreadCrumb(Title = " Delete", Order = 1)]
        public ActionResult Delete(int id, string saveChangesError = "")
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DeletePage"]);

            syMenuVM syMenu = new syMenuVM().Find(id);
            if (syMenu == null)
            {
                return BadRequest();
            }
            ViewData["ErrorMessage"] = saveChangesError;
            return PartialView("Delete", syMenu.Description);
        }

        // POST: syMenu/Delete/5
        [HttpPost, ActionName("Delete")]
        [BreadCrumb(Title = " Delete", Order = 1)]
        ////[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {


            try
            {
                var syMenu = new syMenuVM();

                syMenu.LogonUser = User.Identity.Name;
                bool done = syMenu.Delete(id);

                if (done)
                {
                    AddPageAlerts(PageAlertType.Success, $"{MethodTable} is {MethodAction} Scussefully  {id}");

                    logger.LogInformation($"{MethodTable}  {id} is {MethodAction} Scussefully  ");
                    return Json(new { success = true, responseText = "Deleted Scussefully" });
                    //return RedirectToAction(nameof(Index));
                }
                else
                {
                    AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(syMenu.GlobalError)));
                    //ModelState.AddModelError("", "Unable to save changes. " +  );
                    logger.LogError($" syMenu ID {id} is not  Deleted   {syMenu.GlobalError}");
                    return Json(new { success = false, responseText = "is not  Deleted " + syMenu.GlobalError });
                    //return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = "is not  Deleted " + syMenu.GlobalError });
                }
            }
            catch (Exception dex)
            {
                logger.LogError("syMenu ID {0} is was not Deleted with Error {1}  ", id, dex.Message);
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, Global.Models.SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = "is not  Deleted " + dex.Message });
            }
        }

        #endregion Delete

        [BreadCrumb(Title = " Delete", Order = 1)]
        public ActionResult DeleteSelected(string ids)
        {


            try
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '	' };

                string[] words = ids.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

                if (words != null && words.Length > 0)
                {
                    foreach (var id in words)
                    {
                        var syMenu = new syMenuVM();
                        syMenu.LogonUser = User.Identity.Name;
                        bool done = syMenu.Delete(Convert.ToInt32(id));
                        logger.LogInformation($"{MethodTable} ID {id} is {MethodAction} Scussefully  ");
                    }
                    return Json(new { success = true, responseText = "Deleted Scussefully" });
                }
                return Json(new { success = false, responseText = "Nothing Selected" });
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  is was not {MethodAction} with Error   {SiteUtils.FriendlyErrorMessage(dex)} ");
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, Global.Models.SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
        }
    }
}