using DNTBreadCrumb.Core;
using Global.Controllers;
using Global.Globalization;
using Global.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using NonFactors.Mvc.Lookup;
using System.ComponentModel;
using WTEG.Core;


namespace FinanceCore.Controllers

{
    [Area("Menu")]
    [BreadCrumb(Title = " MenuRoles", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "glyphicon glyphicon-link")]
    [DisplayName("syMenuRolesCont")]
    public class syMenuRolesController : AppBaseController
    {
        //       FleetControl db = new FleetControl();
        //FleetUnitOfWork unitOfWork = new FleetUnitOfWork(new FleetControl());

        #region loicalizations vars

        private readonly IStringLocalizer<syMenuRolesController> _controllerLocalizerizer;

        public syMenuRolesController(IStringLocalizer<SharedResource> localizer, IStringLocalizer<syMenuRolesController> aboutLocalizerizer, IStringLocalizerFactory   strextlocFactory, LocalizationModelContext  context,
                          ILogger<syMenuRolesController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor) : base(_logger, localizer, strextlocFactory, null, accessor)


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

        public JsonResult getsyMenuRolesList(int MenuID)
        {
            return Json(new syMenuRolesVM().GetAll(MenuID).ToList());
        }

        public JsonResult getsyMenuRolesFilteredList(string filterColumn, string filterValue)
        {
            return Json(new syMenuRolesVM().GetAll(Int32.Parse(filterValue)).ToList()); //MenuID.ToString().Contains(filterValue)).ToList());
        }

        #endregion fill in list select2 for/and grid selection

        #region Index

        // GET: syMenuRoles
        [BreadCrumb(Title = " Listing", Order = 1)]
        [DisplayName("syMenuRolesCont")]
        [HelpDefinition]
        public ActionResult Index()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            //var syMenuRolesLocal= db.syMenuRoles.Include(s => s.syMenu);
            return View(new syMenuRolesVM().GetAll());
        }

        #endregion Index

        #region Create

        // POST: syMenuRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create([Bind("ID,MenuID,RoleID,")] syMenuRolesVM syMenuRolesed)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    int? ID = syMenuRolesed.Insert();

                    AddPageAlerts(PageAlertType.Success, $" Created Scussefully  ");
                    //logger.Log(LogLevel.Info, "syMenuRoles ID {0} is Created Scussefully  ", syMenuRolesedsyMenuRoles.ID);
                    logger.LogInformation(MethodTable + " ID {0} is " + MethodAction + " Scussefully  ", syMenuRolesed.syMenuRoles.ID);
                    return Json(new { success = true, responseText = "Created Scussefully" });
                }
                else
                    return Json(new { success = true, responseText = "invalid input" });
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  was not {MethodAction} with Error   {dex.Message} ");
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = Global.Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
            //         //return Json(new { success = true, responseText = "end of Page" });
        }

        #endregion Create

        #region Edit

        // GET: syMenuRoles/Edit/5
        [BreadCrumb(Title = " Edit", Order = 1)]
        [HelpDefinition]
        public ActionResult Edit(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["EditPage"]);
            //          if (id == null)
            //          {
            //              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //          }
            //           syMenuRoles syMenuRoles = db.syMenuRoles.Find(id);
            tblsyMenuRoles syMenuRoles = new syMenuRolesVM().Find(id);
            if (syMenuRoles == null)
            {
                return BadRequest();
            }
            //ViewBag.syMenu = new SelectList(db.syMenu, "ID", "Name");

            return View(syMenuRoles);
        }

        // POST: syMenuRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BreadCrumb(Title = " MenuRoles Update", Order = 1)]
        public ActionResult Update([FromBody] List<tblsyMenuRoles> syMenuRolesed)
        {


            try
            {
                syMenuRolesVM tbl = new syMenuRolesVM();

                // only get unique values to avoid duplication of data from grid array
                foreach (tblsyMenuRoles element in syMenuRolesed.Distinctbylast(p => p.ID))
                {
                    if (element.ID < 0)
                        element.ID = 0;
                    tbl.syMenuRoles = element;
                    tbl.Update();
                }
                logger.LogInformation(MethodTable + " ID {0} is " + MethodAction + " Scussefully  ", syMenuRolesed.Count);

                return Json(new { success = true });
            }
            catch (Exception dex)
            {
                logger.LogError("Unable to save changes. in  syMenuRoles with Message " + dex.Message);
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = Global.Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
            //  //return Json(new { success = true, responseText = "end of Page" });
        }

        #endregion Edit

        #region Delete

        // POST: syMenuRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [BreadCrumb(Title = " Delete", Order = 1)]
        [HelpDefinition]
        public JsonResult Delete([FromBody] int id)
        {


            try
            {
                var syMenuRoles = new syMenuRolesVM();

                syMenuRoles.LogonUser = User.Identity.Name;
                bool done = syMenuRoles.Delete(id);

                if (done)
                {
                    AddPageAlerts(PageAlertType.Success, $"{MethodTable} is {MethodAction} Scussefully  {id}");

                    logger.LogInformation($"{MethodTable}  {id} is {MethodAction} Scussefully  "); return Json(new { success = true, responseText = "Deleted Scussefully" });
                    //return RedirectToAction(nameof(Index));
                }
                else
                {
                    AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(syMenuRoles.GlobalError)));
                    //ModelState.AddModelError("", "Unable to save changes. " +  );
                    logger.LogError($" syMenuRoles ID {id} is not  Deleted   {syMenuRoles.GlobalError}");
                    return Json(new { success = false, responseText = "is not  Deleted " + syMenuRoles.GlobalError });
                    //return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = "is not  Deleted " + syMenuRoles.GlobalError });
                }
            }
            catch (Exception dex)
            {
                logger.LogError("syMenuRoles ID {0} is was not Deleted with Error {1}  ", id, dex.Message);
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = Global.Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
            //  return View();
        }

        #endregion Delete

        [BreadCrumb(Title = " Delete", Order = 1)]
        public ActionResult DeleteSelected([FromBody] List<string> ids)
        {


            try
            {
                if (ids != null && ids.Count > 0)
                {
                    foreach (var id in ids)
                    {
                        var syMenuRoles = new syMenuRolesVM();
                        syMenuRoles.LogonUser = User.Identity.Name;
                        bool done = syMenuRoles.Delete(Convert.ToInt32(id));
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
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = Global.Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
        }
    }
}