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
    [BreadCrumb(Title = "GE_Branchs", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "fas fa-link")]
    [DisplayName("GE_BranchsCont")]
    public class GE_BranchsController : AppBaseController
    {

        #region loicalizations vars
        private readonly IStringLocalizer<GE_BranchsController> _controllerLocalizerizer;


        public GE_BranchsController(IStringLocalizer<SharedResource> localizer, IStringLocalizer<GE_BranchsController> aboutLocalizerizer, IStringLocalizerFactory strextlocFactory, LocalizationModelContext context
                         , ILogger<GE_BranchsController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor
) : base(_logger, localizer, strextlocFactory, context, accessor)
        {
            _controllerLocalizerizer = aboutLocalizerizer;
        }

        #endregion
        #region foriegn keys to use in lookup anjd data list
        #endregion
        #region fill in list select2 for/and grid selection
        public JsonResult AllGE_Branchs(LookupFilter filter)
        {
            //      string SearchPageTitle = _controllerLocalizerizer["SearchPageTitle"].Value;
            ClearFilter(ref filter);
            return Json(new GE_BranchsDatalist { Filter = filter }.GetData());
        }
        [HttpGet]
        public async Task<JsonResult> GetGE_BranchsName(string ID)
        {
            return Json(await new GE_BranchsVM().GetNameByID(ID));
        }
        [HttpGet]
        public JsonResult getGE_BranchsSelect()
        {
            return Json(new GE_BranchsVM().GetGE_BranchsForLkp());
        }
        public async Task<JsonResult> getGE_BranchsList()
        {
            return Json(await new GE_BranchsVM().GetAll().ToListAsync());
        }
        public async Task<JsonResult> getGE_BranchsFilteredList(string filterColumn, string filterValue)
        {
            if (filterValue != null)
            {
                return Json(await new GE_BranchsVM().GetAll().Where(o => o.BranchNameA.ToString().Contains(filterValue)).ToListAsync());
            }
            else
                return Json("No Data");
        }
        #endregion
        #region get lookup options list function for table GE_Branchs
        public JsonResult getGE_BranchsSelectlkp(LookupFilter filter)
        {
            try
            {
                var GE_Branchs = new GE_BranchsVM().GetGE_BranchsForLkp().Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = GE_Branchs });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion
        #region Index

        // GET: GE_Branchs
        [BreadCrumb(Title = "Listing", Order = 1)]
        [DisplayName("GE_BranchsCont")]
        [HelpDefinition]
        public async Task<ActionResult> Index()
        //public async Task<ActionResult>  Index(Int32? page, Int32? rows)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            //var GE_BranchsLocal= db.GE_Branchs;
            return View(await new GE_BranchsVM().GetAll().ToListAsync());
            #region manually paging grid
            //var page = Request.Query["GE_Branchsgrid-Page"].ToString().ToNullable<int>() ?? 1;
            //          var rows = Request.Query["GE_Branchsgrid-Rows"].ToString().ToNullable<int>() ?? 20;
            //           var currentpage = page ?? 1;//== 0 ? 1 : page;;
            //           ViewBag.TotalRows = await new GE_BranchsVM().GetCount();
            //           var records = await new GE_BranchsVM().GetPaged(currentpage).ToListAsync();
            //           return View(records);
            #endregion
        }
        [BreadCrumb(Title = "  Listing", Order = 1)]
        [DisplayName("GE_BranchsCont")]
        [HelpDefinition]
        public async Task<ActionResult> IndexNumber(string txtSearch)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            if (txtSearch != null)
            {
                //long searchtxt = Int64.Parse(txtSearch);
                return View(await new GE_BranchsVM().GetAll()
                    .Where(x => x.BranchNameA == txtSearch)
                    .OrderBy(x => x.BranchCode)
                     .ToListAsync()
                    );
            }
            else
                return View();
        }
        #endregion
        #region Details


        // GET: GE_Branchs/Details/5
        [BreadCrumb(Title = " Details", Order = 1)]
        [HelpDefinition]
        public async Task<ActionResult> Details(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DetailsPage"]);
            tblGE_Branchs GE_Branchs = await new GE_BranchsVM().Find(id);
            if (GE_Branchs == null)
            {
                return BadRequest();
            }
            return View(GE_Branchs);
        }
        #endregion
        #region Create


        // GET: GE_Branchs/Create
        [BreadCrumb(Title = " Create", Order = 1)]
        [HelpDefinition]
        public ActionResult Create()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["CreatePage"]);
            return View();
        }

        // POST: GE_Branchs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("BranchCode,BranchNameA,BranchNameE,CountryCode,CityCode,AddressA,AddressE,Tel1,Tel2,Tel3,Fax,")] tblGE_Branchs GE_Branchsed
)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    GE_BranchsVM toSave = new GE_BranchsVM() { GE_Branchs = GE_Branchsed };
                    toSave.LogonUser = User.Identity.Name;
                    int? ID = await toSave.Insert();
                    if (ID == -1)
                        throw new System.ArgumentException(toSave.GlobalError, "DBlevel");

                    logger.LogInformation($"{MethodTable} ID {ID} is {MethodAction} Scussefully  ");
                    return RedirectToAction("Index");
                }
                else
                {

                    logger.LogInformation(MethodTable + " ID {0} input Error  ", string.Join(",", SiteUtils.GetModelErrros(ModelState)));
                    return View(GE_Branchsed);
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {GE_Branchsed.BranchCode} is was not {MethodAction} with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  ID {GE_Branchsed.BranchCode} is was not {MethodAction} with Error {dex.Message}  ");

            }
            return View(GE_Branchsed);
        }
        #endregion
        #region Edit


        // GET: GE_Branchs/Edit/5
        [HelpDefinition]
        [BreadCrumb(Title = " Edit", Order = 1)]
        public async Task<ActionResult> Edit(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["EditPage"]);
            tblGE_Branchs GE_Branchsed = await new GE_BranchsVM().Find(id);
            if (GE_Branchsed == null)
            {
                return BadRequest();
            }
            return View(GE_Branchsed);
        }

        // POST: GE_Branchs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BreadCrumb(Title = "  Edit", Order = 1)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("BranchCode,BranchNameA,BranchNameE,CountryCode,CityCode,AddressA,AddressE,Tel1,Tel2,Tel3,Fax,")] tblGE_Branchs GE_Branchsed)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    GE_BranchsVM toSave = new GE_BranchsVM() { GE_Branchs = GE_Branchsed };
                    toSave.LogonUser = User.Identity.Name;
                    int? ID = await toSave.Update();
                    if (ID == -1)
                        throw new System.ArgumentException(toSave.GlobalError, "DBlevel");


                    logger.LogInformation($"{MethodTable} ID {ID} is {MethodAction} Scussefully  ");

                    return RedirectToAction("Index");
                }
                else
                {

                    logger.LogInformation(MethodTable + " ID { 0}  input Error  ", string.Join(",", SiteUtils.GetModelErrros(ModelState)));
                    return View(GE_Branchsed);
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {GE_Branchsed.BranchCode} is was not  {MethodAction}  with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  ID {GE_Branchsed.BranchCode} is was not  {MethodAction}  with Error {dex.Message}  ");

            }
            return View(GE_Branchsed);
        }
        #endregion
        #region Delete


        // GET: GE_Branchs/Delete/5
        [BreadCrumb(Title = " Delete", Order = 1)]
        [HelpDefinition]
        //   public async Task<ActionResult> Delete(int id)
        public async Task<ActionResult> Delete(int id, string saveChangesError = "")
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DeletePage"]);
            tblGE_Branchs GE_Branchs = await new GE_BranchsVM().Find(id);
            if (GE_Branchs == null)
            {
                return BadRequest();
            }
            ViewData["ErrorMessage"] = saveChangesError;
            return PartialView("Delete", GE_Branchs.lookupName);
        }

        // POST: GE_Branchs/Delete/5
        [HttpPost, ActionName("Delete")]
        [BreadCrumb(Title = " Delete", Order = 1)]
        public async Task<JsonResult> Delete(int id)
        {

            try
            {
                var GE_Branchs = new GE_BranchsVM();
                GE_Branchs.LogonUser = User.Identity.Name;
                bool done = await GE_Branchs.Delete(id);

                if (done)
                {


                    logger.LogInformation($"{MethodTable} ID {id} is {MethodAction} Scussefully  ");
                    return Json(new { success = true, responseText = "Deleted Scussefully" });
                }
                else
                {

                    //ModelState.AddModelError("", "Unable to save changes. " + SiteUtils.FriendlyErrorMessage(GE_Branchs.GlobalError ));
                    logger.LogInformation($" GE_Branchs ID {id} is not  {MethodAction}   {SiteUtils.FriendlyErrorMessage(GE_Branchs.GlobalError)}");
                    return Json(new { success = false, responseText = "is not  {MethodAction} {" + SiteUtils.FriendlyErrorMessage(GE_Branchs.GlobalError) });
                }

            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  is was not {MethodAction} with Error {dex.Message}  ");
                // ModelState.AddModelError("", "Unable to save changes. " + dex.Message);

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

                        //  bool done = new GE_BranchsVM().Delete(Convert.ToInt32(id));
                        var GE_Branchs = new GE_BranchsVM();
                        GE_Branchs.LogonUser = User.Identity.Name;
                        bool done = await GE_Branchs.Delete(Convert.ToInt32(id));
                        AddPageAlerts(PageAlertType.Success, $"GE_Branchs   is deleted Scussefully  {id}");
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

                return Json(new { success = false, responseText = dex.Message });
            }
        }
        #endregion
    }
}
