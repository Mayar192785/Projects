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
    [BreadCrumb(Title = " MenuNames", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "glyphicon glyphicon-link")]
    [DisplayName("syMenuNamesCont")]
    public class syMenuNamesController : AppBaseController
    {
        //       FleetControl db = new FleetControl();
        //FleetUnitOfWork unitOfWork = new FleetUnitOfWork(new FleetControl());

        #region loicalizations vars

        private readonly IStringLocalizer<syMenuNamesController> _controllerLocalizerizer;

        public syMenuNamesController(IStringLocalizer<SharedResource> localizer, IStringLocalizer<syMenuNamesController> aboutLocalizerizer, IStringLocalizerFactory   strextlocFactory, LocalizationModelContext  context,
                          ILogger<syMenuNamesController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor) : base(_logger, localizer, strextlocFactory, null, accessor)


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

        public JsonResult getsyMenuNamesList(int MenuID)
        {
            return Json(new syMenuNamesVM().GetAll(MenuID).ToList());
        }

        public JsonResult getsyMenuNamesFilteredList(string filterColumn, string filterValue)
        {
            return Json(new syMenuNamesVM().GetAll(Int32.Parse(filterValue)).ToList()); //MenuID.ToString().Contains(filterValue)).ToList());
        }

        #endregion fill in list select2 for/and grid selection

        #region Index

        // GET: syMenuNames
        [BreadCrumb(Title = " Listing", Order = 1)]
        [DisplayName("syMenuNamesCont")]
        [HelpDefinition]
        public ActionResult Index()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            //var syMenuNamesLocal= db.syMenuNames.Include(s => s.syMenu);
            return View(new syMenuNamesVM().GetAll());
        }

        #endregion Index

        #region Create

        // POST: syMenuNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create([Bind("ID,MenuID,Name,LanguageID,Description,")] tblsyMenuNames syMenuNamesed)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    syMenuNamesVM toSave = new syMenuNamesVM() { syMenuNames = syMenuNamesed };
                    toSave.LogonUser = User.Identity.Name;
                    int? ID = toSave.Insert();

                    AddPageAlerts(PageAlertType.Success, $" Created Scussefully  ");
                    //logger.Log(LogLevel.Info, "syMenuNames ID {0} is Created Scussefully  ", syMenuNamesedsyMenuNames.ID);
                    logger.LogInformation(MethodTable + " ID {0} is " + MethodAction + " Scussefully  ", syMenuNamesed.ID);
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
                return Json(new { success = false, responseText = Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
            //         //return Json(new { success = true, responseText = "end of Page" });
        }

        #endregion Create

        #region Edit

        // GET: syMenuNames/Edit/5
        [BreadCrumb(Title = " Edit", Order = 1)]
        [HelpDefinition]
        public ActionResult Edit(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["EditPage"]);

            tblsyMenuNames syMenuNames = new syMenuNamesVM().Find(id);
            if (syMenuNames == null)
            {
                return BadRequest();
            }

            return View(syMenuNames);
        }

        // POST: syMenuNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BreadCrumb(Title = " MenuNames Update", Order = 1)]
        public ActionResult Update([FromBody] List<tblsyMenuNames> syMenuNamesed)
        {


            try
            {
                syMenuNamesVM tbl = new syMenuNamesVM();

                // only get unique values to avoid duplication of data from grid array
                foreach (tblsyMenuNames element in syMenuNamesed.Distinctbylast(p => p.ID))
                {
                    if (element.ID < 0)
                        element.ID = 0;
                    tbl.syMenuNames = element;
                    int Result = tbl.Update();
                    if (Result == -1)
                        throw new System.ArgumentException(tbl.GlobalError, "DBlevel");
                }
                logger.LogInformation(MethodTable + " ID {0} is " + MethodAction + " Scussefully  ", syMenuNamesed.Count);

                return Json(new { success = true });
            }
            catch (Exception dex)
            {
                logger.LogError("Unable to save changes. in  syMenuNames with Message " + dex.Message);
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, Global.Models.SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
            //  //return Json(new { success = true, responseText = "end of Page" });
        }

        #endregion Edit

        #region Delete

        // POST: syMenuNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [BreadCrumb(Title = " Delete", Order = 1)]
        [HelpDefinition]
        public JsonResult Delete([FromBody] int id)
        {


            try
            {
                var syMenuNames = new syMenuNamesVM();

                syMenuNames.LogonUser = User.Identity.Name;
                bool done = syMenuNames.Delete(id);

                if (done)
                {
                    AddPageAlerts(PageAlertType.Success, $"{MethodTable} is {MethodAction} Scussefully  {id}");

                    logger.LogInformation($"{MethodTable}  {id} is {MethodAction} Scussefully  "); return Json(new { success = true, responseText = "Deleted Scussefully" });
                    //return RedirectToAction(nameof(Index));
                }
                else
                {
                    AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(syMenuNames.GlobalError)));
                    //ModelState.AddModelError("", "Unable to save changes. " + syMenuNames.GlobalError);
                    logger.LogError($" syMenuNames ID {id} is not  Deleted   {syMenuNames.GlobalError}");
                    return Json(new { success = false, responseText = "is not  Deleted " + syMenuNames.GlobalError });
                    //return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = "is not  Deleted " + syMenuNames.GlobalError });
                }
            }
            catch (Exception dex)
            {
                logger.LogError("syMenuNames ID {0} is was not Deleted with Error {1}  ", id, dex.Message);
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                AddPageAlerts(PageAlertType.Error, String.Format(GetMessage("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = Models.SiteUtils.FriendlyErrorMessage(dex) });
            }
            //return View();
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
                        var syMenuNames = new syMenuNamesVM();
                        syMenuNames.LogonUser = User.Identity.Name;
                        bool done = syMenuNames.Delete(Convert.ToInt32(id));
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