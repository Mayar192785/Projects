using System;
using System.Collections.Generic;
using Microsoft.Data;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using Global.Services;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WTEG.SqlLocalizer.DbStringLocalizer;
using FinanceCore.DBModels;
using FinanceCore.Models;
using Microsoft.Extensions.Logging;
using Global.Controllers;
using Global;
using Global.Models;
using Global.DBModels;
using NonFactors.Mvc.Lookup;
using Global.Globalization;
using DNTBreadCrumb.Core;
using System.ComponentModel;
using WTEG.Core;
using System.Threading.Tasks;

namespace FinanceCore.Controllers
{
    //[Authorize]
    [Area("General")]
    [BreadCrumb(Title = "GE_SubSystems", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "fas fa-link")]
    [DisplayName("GE_SubSystemsCont")]
    public class GE_SubSystemsController : AppBaseController
    {

        #region loicalizations vars
        private readonly IStringLocalizer<GE_SubSystemsController> _controllerLocalizerizer;


        public GE_SubSystemsController(IStringLocalizer<SharedResource> localizer, IStringLocalizer<GE_SubSystemsController> aboutLocalizerizer, IStringLocalizerFactory strextlocFactory, LocalizationModelContext context
                         , ILogger<GE_SubSystemsController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor
) : base(_logger, localizer, strextlocFactory, context, accessor)
        {
            _controllerLocalizerizer = aboutLocalizerizer;
        }

        #endregion
        #region foriegn keys to use in lookup anjd data list
        #endregion
        #region fill in list select2 for/and grid selection
        public JsonResult AllGE_SubSystems(LookupFilter filter)
        {
            //      string SearchPageTitle = _controllerLocalizerizer["SearchPageTitle"].Value;
            ClearFilter(ref filter);
            return Json(new GE_SubSystemsDatalist { Filter = filter }.GetData());
        }
        [HttpGet]
        public async Task<JsonResult> GetGE_SubSystemsName(string ID)
        {
            return Json(await new GE_SubSystemsVM().GetNameByID(ID));
        }
        [HttpGet]
        public JsonResult getGE_SubSystemsSelect()
        {
            return Json(new GE_SubSystemsVM().GetGE_SubSystemsForLkp());
        }
        public async Task<JsonResult> getGE_SubSystemsList()
        {
            return Json(await new GE_SubSystemsVM().GetAll().ToListAsync());
        }
        public async Task<JsonResult> getGE_SubSystemsFilteredList(string filterColumn, string filterValue)
        {
            if (filterValue != null)
            {
                return Json(await new GE_SubSystemsVM().GetAll().Where(o => o.SubSystemName.ToString().Contains(filterValue)).ToListAsync());
            }
            else
                return Json("No Data");
        }
        #endregion
        #region get lookup options list function for table GE_SubSystems
        public JsonResult getGE_SubSystemsSelectlkp(LookupFilter filter)
        {
            try
            {
                var GE_SubSystems = new GE_SubSystemsVM().GetGE_SubSystemsForLkp().Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = GE_SubSystems });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion
        #region Index

        // GET: GE_SubSystems
        [BreadCrumb(Title = "Listing", Order = 1)]
        [DisplayName("GE_SubSystemsCont")]
        [HelpDefinition]
        public async Task<ActionResult> Index()
        //public async Task<ActionResult>  Index(Int32? page, Int32? rows)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            //var GE_SubSystemsLocal= db.GE_SubSystems;
            return View(await new GE_SubSystemsVM().GetAll().ToListAsync());
            #region manually paging grid
            //var page = Request.Query["GE_SubSystemsgrid-Page"].ToString().ToNullable<int>() ?? 1;
            //          var rows = Request.Query["GE_SubSystemsgrid-Rows"].ToString().ToNullable<int>() ?? 20;
            //           var currentpage = page ?? 1;//== 0 ? 1 : page;;
            //           ViewBag.TotalRows = await new GE_SubSystemsVM().GetCount();
            //           var records = await new GE_SubSystemsVM().GetPaged(currentpage).ToListAsync();
            //           return View(records);
            #endregion
        }
        [BreadCrumb(Title = "  Listing", Order = 1)]
        [DisplayName("GE_SubSystemsCont")]
        [HelpDefinition]
        public async Task<ActionResult> IndexNumber(string txtSearch)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            if (txtSearch != null)
            {
                //long searchtxt = Int64.Parse(txtSearch);
                return View(await new GE_SubSystemsVM().GetAll()
                    .Where(x => x.SubSystemName == txtSearch)
                    .OrderBy(x => x.ID)
                     .ToListAsync()
                    );
            }
            else
                return View();
        }
        #endregion
        #region Details


        // GET: GE_SubSystems/Details/5
        [BreadCrumb(Title = " Details", Order = 1)]
        [HelpDefinition]
        public async Task<ActionResult> Details(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DetailsPage"]);
            tblGE_SubSystems GE_SubSystems = await new GE_SubSystemsVM().Find(id);
            if (GE_SubSystems == null)
            {
                return BadRequest();
            }
            return View(GE_SubSystems);
        }
        #endregion
        #region Create


        // GET: GE_SubSystems/Create
        [BreadCrumb(Title = " Create", Order = 1)]
        [HelpDefinition]
        public ActionResult Create()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["CreatePage"]);
            return View();
        }

        // POST: GE_SubSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ID,SubSystemName,SubSystemArabicName,SubSystemShortName,IsActive,")] tblGE_SubSystems GE_SubSystemsed
)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    GE_SubSystemsVM toSave = new GE_SubSystemsVM() { GE_SubSystems = GE_SubSystemsed };
                    toSave.LogonUser = User.Identity.Name;
                    int? ID = await toSave.Insert();
                    if (ID == -1)
                        throw new System.ArgumentException(toSave.GlobalError, "DBlevel");
                    //AddPageAlerts(PageAlertType.Success, String.Format(GetResourceValue("Success", "PageAlerts"), MethodTable, MethodAction, ""));
                    logger.LogInformation($"{MethodTable} ID {ID} is {MethodAction} Scussefully  ");
                    return RedirectToAction("Index");
                }
                else
                {
                    //AddPageAlerts(PageAlertType.Error, String.Format(GetResourceValue("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage("Invalid input")));
                    logger.LogInformation(MethodTable + " ID {0} input Error  ", string.Join(",", SiteUtils.GetModelErrros(ModelState)));
                    return View(GE_SubSystemsed);
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {GE_SubSystemsed.ID} is was not {MethodAction} with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  ID {GE_SubSystemsed.ID} is was not {MethodAction} with Error {dex.Message}  ");
                //AddPageAlerts(PageAlertType.Error, String.Format( GetResourceValue("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
            }
            return View(GE_SubSystemsed);
        }
        #endregion
        #region Edit


        // GET: GE_SubSystems/Edit/5
        [HelpDefinition]
        [BreadCrumb(Title = " Edit", Order = 1)]
        public async Task<ActionResult> Edit(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["EditPage"]);
            tblGE_SubSystems GE_SubSystemsed = await new GE_SubSystemsVM().Find(id);
            if (GE_SubSystemsed == null)
            {
                return BadRequest();
            }
            return View(GE_SubSystemsed);
        }

        // POST: GE_SubSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BreadCrumb(Title = "  Edit", Order = 1)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("ID,SubSystemName,SubSystemArabicName,SubSystemShortName,IsActive,")] tblGE_SubSystems GE_SubSystemsed)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    GE_SubSystemsVM toSave = new GE_SubSystemsVM() { GE_SubSystems = GE_SubSystemsed };
                    toSave.LogonUser = User.Identity.Name;
                    int? ID = await toSave.Update();
                    if (ID == -1)
                        throw new System.ArgumentException(toSave.GlobalError, "DBlevel");

                    // AddPageAlerts(PageAlertType.Success, String.Format(GetResourceValue("Success", "PageAlerts"), MethodTable, MethodAction, ""));
                    logger.LogInformation($"{MethodTable} ID {ID} is {MethodAction} Scussefully  ");

                    return RedirectToAction("Index");
                }
                else
                {
                    // AddPageAlerts(PageAlertType.Error, String.Format(GetResourceValue("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage("Invalid input")));
                    logger.LogInformation(MethodTable + " ID { 0}  input Error  ", string.Join(",", SiteUtils.GetModelErrros(ModelState)));
                    return View(GE_SubSystemsed);
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {GE_SubSystemsed.ID} is was not  {MethodAction}  with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  ID {GE_SubSystemsed.ID} is was not  {MethodAction}  with Error {dex.Message}  ");
                // AddPageAlerts(PageAlertType.Error, String.Format(GetResourceValue("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
            }
            return View(GE_SubSystemsed);
        }
        #endregion
        #region Delete


        // GET: GE_SubSystems/Delete/5
        [BreadCrumb(Title = " Delete", Order = 1)]
        [HelpDefinition]
        //   public async Task<ActionResult> Delete(int id)
        public async Task<ActionResult> Delete(int id, string saveChangesError = "")
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DeletePage"]);
            tblGE_SubSystems GE_SubSystems = await new GE_SubSystemsVM().Find(id);
            if (GE_SubSystems == null)
            {
                return BadRequest();
            }
            ViewData["ErrorMessage"] = saveChangesError;
            return PartialView("Delete", GE_SubSystems.lookupName);
        }

        // POST: GE_SubSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [BreadCrumb(Title = " Delete", Order = 1)]
        public async Task<JsonResult> Delete(int id)
        {

            try
            {
                var GE_SubSystems = new GE_SubSystemsVM();
                GE_SubSystems.LogonUser = User.Identity.Name;
                bool done = await GE_SubSystems.Delete(id);

                if (done)
                {
                    // AddPageAlerts(PageAlertType.Success, String.Format(GetResourceValue("Success", "PageAlerts"), MethodTable, MethodAction, id));

                    logger.LogInformation($"{MethodTable} ID {id} is {MethodAction} Scussefully  ");
                    return Json(new { success = true, responseText = "Deleted Scussefully" });
                }
                else
                {
                    // AddPageAlerts(PageAlertType.Error, String.Format(GetResourceValue("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(GE_SubSystems.GlobalError)));
                    //ModelState.AddModelError("", "Unable to save changes. " + SiteUtils.FriendlyErrorMessage(GE_SubSystems.GlobalError ));
                    logger.LogInformation($" GE_SubSystems ID {id} is not  {MethodAction}   {SiteUtils.FriendlyErrorMessage(GE_SubSystems.GlobalError)}");
                    return Json(new { success = false, responseText = "is not  {MethodAction} {" + SiteUtils.FriendlyErrorMessage(GE_SubSystems.GlobalError) });
                }

            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  is was not {MethodAction} with Error {dex.Message}  ");
                // ModelState.AddModelError("", "Unable to save changes. " + dex.Message);
                // AddPageAlerts(PageAlertType.Error, String.Format(GetResourceValue("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = dex.Message });
            }

        }

        [BreadCrumb(Title = " Delete", Order = 1)]
        public async Task<ActionResult> DeleteSelected(string ids)
        {
            try
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '	' };


                string[] words = ids.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

                if (words != null && words.Length > 0)
                {

                    foreach (var id in words)
                    {

                        //  bool done = new GE_SubSystemsVM().Delete(Convert.ToInt32(id));
                        var GE_SubSystems = new GE_SubSystemsVM();
                        GE_SubSystems.LogonUser = User.Identity.Name;
                        bool done = await GE_SubSystems.Delete(Convert.ToInt32(id));
                        // AddPageAlerts(PageAlertType.Success, $"GE_SubSystems   is deleted Scussefully  {id}");
                        logger.LogInformation($"{MethodTable} ID {id} is {MethodAction} Scussefully  ");
                    }
                    return Json(new { success = true, responseText = "Deleted Scussefully" });

                }
                return Json(new { success = false, responseText = "Nothing Selected" });
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  is was not {MethodAction} with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  is was not {MethodAction} with Error {dex.Message}  ");
                // AddPageAlerts(PageAlertType.Error, String.Format(GetResourceValue("Fail", "PageAlerts"), MethodTable, MethodAction, SiteUtils.FriendlyErrorMessage(dex)));
                return Json(new { success = false, responseText = dex.Message });
            }
        }
        #endregion
    }
}
