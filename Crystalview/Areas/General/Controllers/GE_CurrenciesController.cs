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
    [BreadCrumb(Title = "GE_Currencies", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "fas fa-link")]
    [DisplayName("GE_CurrenciesCont")]
    public class GE_CurrenciesController : AppBaseController
    {

        #region loicalizations vars
        private readonly IStringLocalizer<GE_CurrenciesController> _controllerLocalizerizer;


        public GE_CurrenciesController(IStringLocalizer<SharedResource> localizer, IStringLocalizer<GE_CurrenciesController> aboutLocalizerizer, IStringLocalizerFactory strextlocFactory, LocalizationModelContext context
                         , ILogger<GE_CurrenciesController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor
) : base(_logger, localizer, strextlocFactory, context, accessor)
        {
            _controllerLocalizerizer = aboutLocalizerizer;
        }

        #endregion
        #region foriegn keys to use in lookup anjd data list
        #endregion
        #region fill in list select2 for/and grid selection
        public JsonResult AllGE_Currencies(LookupFilter filter)
        {
            //      string SearchPageTitle = _controllerLocalizerizer["SearchPageTitle"].Value;
            ClearFilter(ref filter);
            return Json(new GE_CurrenciesDatalist { Filter = filter }.GetData());
        }
        [HttpGet]
        public async Task<JsonResult> GetGE_CurrenciesName(string ID)
        {
            return Json(await new GE_CurrenciesVM().GetNameByID(ID));
        }
        [HttpGet]
        public JsonResult getGE_CurrenciesSelect()
        {
            return Json(new GE_CurrenciesVM().GetGE_CurrenciesForLkp());
        }
        public async Task<JsonResult> getGE_CurrenciesList()
        {
            return Json(await new GE_CurrenciesVM().GetAll().ToListAsync());
        }
        public async Task<JsonResult> getGE_CurrenciesFilteredList(string filterColumn, string filterValue)
        {
            if (filterValue != null)
            {
                return Json(await new GE_CurrenciesVM().GetAll().Where(o => o.CurrencyNameA.ToString().Contains(filterValue)).ToListAsync());
            }
            else
                return Json("No Data");
        }
        #endregion
        #region get lookup options list function for table GE_Currencies
        public JsonResult getGE_CurrenciesSelectlkp(LookupFilter filter)
        {
            try
            {
                var GE_Currencies = new GE_CurrenciesVM().GetGE_CurrenciesForLkp().Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = GE_Currencies });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion
        #region Index

        // GET: GE_Currencies
        [BreadCrumb(Title = "Listing", Order = 1)]
        [DisplayName("GE_CurrenciesCont")]
        [HelpDefinition]
        public async Task<ActionResult> Index()
        //public async Task<ActionResult>  Index(Int32? page, Int32? rows)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            //var GE_CurrenciesLocal= db.GE_Currencies;
            return View(await new GE_CurrenciesVM().GetAll().ToListAsync());
            #region manually paging grid
            //var page = Request.Query["GE_Currenciesgrid-Page"].ToString().ToNullable<int>() ?? 1;
            //          var rows = Request.Query["GE_Currenciesgrid-Rows"].ToString().ToNullable<int>() ?? 20;
            //           var currentpage = page ?? 1;//== 0 ? 1 : page;;
            //           ViewBag.TotalRows = await new GE_CurrenciesVM().GetCount();
            //           var records = await new GE_CurrenciesVM().GetPaged(currentpage).ToListAsync();
            //           return View(records);
            #endregion
        }
        [BreadCrumb(Title = "  Listing", Order = 1)]
        [DisplayName("GE_CurrenciesCont")]
        [HelpDefinition]
        public async Task<ActionResult> IndexNumber(string txtSearch)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            if (txtSearch != null)
            {
                //long searchtxt = Int64.Parse(txtSearch);
                return View(await new GE_CurrenciesVM().GetAll()
                    .Where(x => x.CurrencyNameA == txtSearch)
                    .OrderBy(x => x.CurrencyCode)
                     .ToListAsync()
                    );
            }
            else
                return View();
        }
        #endregion
        #region Details


        // GET: GE_Currencies/Details/5
        [BreadCrumb(Title = " Details", Order = 1)]
        [HelpDefinition]
        public async Task<ActionResult> Details(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DetailsPage"]);
            tblGE_Currencies GE_Currencies = await new GE_CurrenciesVM().Find(id);
            if (GE_Currencies == null)
            {
                return BadRequest();
            }
            return View(GE_Currencies);
        }
        #endregion
        #region Create


        // GET: GE_Currencies/Create
        [BreadCrumb(Title = " Create", Order = 1)]
        [HelpDefinition]
        public ActionResult Create()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["CreatePage"]);
            return View();
        }

        // POST: GE_Currencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("CurrencyCode,CurrencyNameA,CurrencyNameE,Abbreviation,ExctangeRate,")] tblGE_Currencies GE_Currenciesed
)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    GE_CurrenciesVM toSave = new GE_CurrenciesVM() { GE_Currencies = GE_Currenciesed };
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
                    return View(GE_Currenciesed);
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {GE_Currenciesed.CurrencyCode} is was not {MethodAction} with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  ID {GE_Currenciesed.CurrencyCode} is was not {MethodAction} with Error {dex.Message}  ");

            }
            return View(GE_Currenciesed);
        }
        #endregion
        #region Edit


        // GET: GE_Currencies/Edit/5
        [HelpDefinition]
        [BreadCrumb(Title = " Edit", Order = 1)]
        public async Task<ActionResult> Edit(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["EditPage"]);
            tblGE_Currencies GE_Currenciesed = await new GE_CurrenciesVM().Find(id);
            if (GE_Currenciesed == null)
            {
                return BadRequest();
            }
            return View(GE_Currenciesed);
        }

        // POST: GE_Currencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BreadCrumb(Title = "  Edit", Order = 1)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("CurrencyCode,CurrencyNameA,CurrencyNameE,Abbreviation,ExctangeRate,")] tblGE_Currencies GE_Currenciesed)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    GE_CurrenciesVM toSave = new GE_CurrenciesVM() { GE_Currencies = GE_Currenciesed };
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
                    return View(GE_Currenciesed);
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {GE_Currenciesed.CurrencyCode} is was not  {MethodAction}  with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  ID {GE_Currenciesed.CurrencyCode} is was not  {MethodAction}  with Error {dex.Message}  ");

            }
            return View(GE_Currenciesed);
        }
        #endregion
        #region Delete


        // GET: GE_Currencies/Delete/5
        [BreadCrumb(Title = " Delete", Order = 1)]
        [HelpDefinition]
        //   public async Task<ActionResult> Delete(int id)
        public async Task<ActionResult> Delete(int id, string saveChangesError = "")
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DeletePage"]);
            tblGE_Currencies GE_Currencies = await new GE_CurrenciesVM().Find(id);
            if (GE_Currencies == null)
            {
                return BadRequest();
            }
            ViewData["ErrorMessage"] = saveChangesError;
            return PartialView("Delete", GE_Currencies.lookupName);
        }

        // POST: GE_Currencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [BreadCrumb(Title = " Delete", Order = 1)]
        public async Task<JsonResult> Delete(int id)
        {

            try
            {
                var GE_Currencies = new GE_CurrenciesVM();
                GE_Currencies.LogonUser = User.Identity.Name;
                bool done = await GE_Currencies.Delete(id);

                if (done)
                {


                    logger.LogInformation($"{MethodTable} ID {id} is {MethodAction} Scussefully  ");
                    return Json(new { success = true, responseText = "Deleted Scussefully" });
                }
                else
                {

                    //ModelState.AddModelError("", "Unable to save changes. " + SiteUtils.FriendlyErrorMessage(GE_Currencies.GlobalError ));
                    logger.LogInformation($" GE_Currencies ID {id} is not  {MethodAction}   {SiteUtils.FriendlyErrorMessage(GE_Currencies.GlobalError)}");
                    return Json(new { success = false, responseText = "is not  {MethodAction} {" + SiteUtils.FriendlyErrorMessage(GE_Currencies.GlobalError) });
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

                        //  bool done = new GE_CurrenciesVM().Delete(Convert.ToInt32(id));
                        var GE_Currencies = new GE_CurrenciesVM();
                        GE_Currencies.LogonUser = User.Identity.Name;
                        bool done = await GE_Currencies.Delete(Convert.ToInt32(id));
                        AddPageAlerts(PageAlertType.Success, $"GE_Currencies   is deleted Scussefully  {id}");
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
