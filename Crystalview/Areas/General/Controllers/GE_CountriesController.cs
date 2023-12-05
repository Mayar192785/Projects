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
    [BreadCrumb(Title = "GE_Countries", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "fas fa-link")]
    [DisplayName("GE_CountriesCont")]
    public class GE_CountriesController : AppBaseController
    {

        #region loicalizations vars
        private readonly IStringLocalizer<GE_CountriesController> _controllerLocalizerizer;


        public GE_CountriesController(IStringLocalizer<SharedResource> localizer, IStringLocalizer<GE_CountriesController> aboutLocalizerizer, IStringLocalizerFactory strextlocFactory, LocalizationModelContext context
                         , ILogger<GE_CountriesController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor
) : base(_logger, localizer, strextlocFactory, context, accessor)
        {
            _controllerLocalizerizer = aboutLocalizerizer;
        }

        #endregion
        #region foriegn keys to use in lookup anjd data list
        #endregion
        #region fill in list select2 for/and grid selection
        public JsonResult AllGE_Countries(LookupFilter filter)
        {
            //      string SearchPageTitle = _controllerLocalizerizer["SearchPageTitle"].Value;
            ClearFilter(ref filter);
            return Json(new GE_CountriesDatalist { Filter = filter }.GetData());
        }
        [HttpGet]
        public async Task<JsonResult> GetGE_CountriesName(string ID)
        {
            return Json(await new GE_CountriesVM().GetNameByID(ID));
        }
        [HttpGet]
        public JsonResult getGE_CountriesSelect()
        {
            return Json(new GE_CountriesVM().GetGE_CountriesForLkp());
        }
        public async Task<JsonResult> getGE_CountriesList()
        {
            return Json(await new GE_CountriesVM().GetAll().ToListAsync());
        }
        public async Task<JsonResult> getGE_CountriesFilteredList(string filterColumn, string filterValue)
        {
            if (filterValue != null)
            {
                return Json(await new GE_CountriesVM().GetAll().Where(o => o.CountryNameA.ToString().Contains(filterValue)).ToListAsync());
            }
            else
                return Json("No Data");
        }
        #endregion
        #region get lookup options list function for table GE_Countries
        public JsonResult getGE_CountriesSelectlkp(LookupFilter filter)
        {
            try
            {
                var GE_Countries = new GE_CountriesVM().GetGE_CountriesForLkp().Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = GE_Countries });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion
        #region Index

        // GET: GE_Countries
        [BreadCrumb(Title = "Listing", Order = 1)]
        [DisplayName("GE_CountriesCont")]
        [HelpDefinition]
        public async Task<ActionResult> Index()
        //public async Task<ActionResult>  Index(Int32? page, Int32? rows)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            //var GE_CountriesLocal= db.GE_Countries;
            return View(await new GE_CountriesVM().GetAll().ToListAsync());
            #region manually paging grid
            //var page = Request.Query["GE_Countriesgrid-Page"].ToString().ToNullable<int>() ?? 1;
            //          var rows = Request.Query["GE_Countriesgrid-Rows"].ToString().ToNullable<int>() ?? 20;
            //           var currentpage = page ?? 1;//== 0 ? 1 : page;;
            //           ViewBag.TotalRows = await new GE_CountriesVM().GetCount();
            //           var records = await new GE_CountriesVM().GetPaged(currentpage).ToListAsync();
            //           return View(records);
            #endregion
        }
        [BreadCrumb(Title = "  Listing", Order = 1)]
        [DisplayName("GE_CountriesCont")]
        [HelpDefinition]
        public async Task<ActionResult> IndexNumber(string txtSearch)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            if (txtSearch != null)
            {
                //long searchtxt = Int64.Parse(txtSearch);
                return View(await new GE_CountriesVM().GetAll()
                    .Where(x => x.CountryNameA == txtSearch)
                    .OrderBy(x => x.CountryCode)
                     .ToListAsync()
                    );
            }
            else
                return View();
        }
        #endregion
        #region Details


        // GET: GE_Countries/Details/5
        [BreadCrumb(Title = " Details", Order = 1)]
        [HelpDefinition]
        public async Task<ActionResult> Details(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DetailsPage"]);
            tblGE_Countries GE_Countries = await new GE_CountriesVM().Find(id);
            if (GE_Countries == null)
            {
                return BadRequest();
            }
            return View(GE_Countries);
        }
        #endregion
        #region Create


        // GET: GE_Countries/Create
        [BreadCrumb(Title = " Create", Order = 1)]
        [HelpDefinition]
        public ActionResult Create()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["CreatePage"]);
            return View();
        }

        // POST: GE_Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("CountryCode,CountryNameA,CountryNameE,")] tblGE_Countries GE_Countriesed
)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    GE_CountriesVM toSave = new GE_CountriesVM() { GE_Countries = GE_Countriesed };
                    toSave.LogonUser = User.Identity.Name;
                    int? ID = await toSave.Insert();
                    if (ID == -1)
                        throw new System.ArgumentException(toSave.GlobalError, "DBlevel");

                    logger.LogInformation($"{MethodTable} ID {ID} is {MethodAction} Scussefully  ");
                    return RedirectToAction("Edit", new { id = ID.ToString() });
                }
                else
                {

                    logger.LogInformation(MethodTable + " ID {0} input Error  ", string.Join(",", SiteUtils.GetModelErrros(ModelState)));
                    return View(GE_Countriesed);
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {GE_Countriesed.CountryCode} is was not {MethodAction} with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  ID {GE_Countriesed.CountryCode} is was not {MethodAction} with Error {dex.Message}  ");

            }
            return View(GE_Countriesed);
        }
        #endregion
        #region Edit

        // preapre view model for edit
        public async Task<tblGE_Countries> EditHelper(int id)
        {

            tblGE_Countries GE_Countriesed = await new GE_CountriesVM().Find(id);

            tblGE_Countries GE_CountriesVMed = new tblGE_Countries()
            {
                CountryCode = GE_Countriesed.CountryCode
                     ,
                CountryNameA = GE_Countriesed.CountryNameA
                     ,
                CountryNameE = GE_Countriesed.CountryNameE
                //                 , ShowGrid = true
            }
                ;

            return GE_CountriesVMed;
        }

        // GET: GE_Countries/Edit/5
        [HelpDefinition]
        [BreadCrumb(Title = " Edit", Order = 1)]
        public async Task<ActionResult> Edit(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["EditPage"]);
            tblGE_Countries GE_Countriesed = await new GE_CountriesVM().Find(id);
            if (GE_Countriesed == null)
            {
                return BadRequest();
            }
            return View(EditHelper(id).Result);
        }

        // POST: GE_Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BreadCrumb(Title = "  Edit", Order = 1)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("CountryCode,CountryNameA,CountryNameE,")] tblGE_Countries GE_Countriesed)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    GE_CountriesVM toSave = new GE_CountriesVM() { GE_Countries = GE_Countriesed };
                    toSave.LogonUser = User.Identity.Name;
                    int? ID = await toSave.Update();
                    if (ID == -1)
                        throw new System.ArgumentException(toSave.GlobalError, "DBlevel");


                    logger.LogInformation($"{MethodTable} ID {ID} is {MethodAction} Scussefully  ");

                    return View(EditHelper(GE_Countriesed.CountryCode).Result);
                }
                else
                {

                    logger.LogInformation(MethodTable + " ID { 0}  input Error  ", string.Join(",", SiteUtils.GetModelErrros(ModelState)));
                    return View(GE_Countriesed);
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {GE_Countriesed.CountryCode} is was not  {MethodAction}  with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  ID {GE_Countriesed.CountryCode} is was not  {MethodAction}  with Error {dex.Message}  ");

            }
            return View(EditHelper(GE_Countriesed.CountryCode).Result);
        }
        #endregion
        #region Delete


        // GET: GE_Countries/Delete/5
        [BreadCrumb(Title = " Delete", Order = 1)]
        [HelpDefinition]
        //   public async Task<ActionResult> Delete(int id)
        public async Task<ActionResult> Delete(int id, string saveChangesError = "")
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DeletePage"]);
            tblGE_Countries GE_Countries = await new GE_CountriesVM().Find(id);
            if (GE_Countries == null)
            {
                return BadRequest();
            }
            ViewData["ErrorMessage"] = saveChangesError;
            return PartialView("Delete", GE_Countries.lookupName);
        }

        // POST: GE_Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [BreadCrumb(Title = " Delete", Order = 1)]
        public async Task<JsonResult> Delete(int id)
        {

            try
            {
                var GE_Countries = new GE_CountriesVM();
                GE_Countries.LogonUser = User.Identity.Name;
                bool done = await GE_Countries.Delete(id);

                if (done)
                {


                    logger.LogInformation($"{MethodTable} ID {id} is {MethodAction} Scussefully  ");
                    return Json(new { success = true, responseText = "Deleted Scussefully" });
                }
                else
                {

                    //ModelState.AddModelError("", "Unable to save changes. " + SiteUtils.FriendlyErrorMessage(GE_Countries.GlobalError ));
                    logger.LogInformation($" GE_Countries ID {id} is not  {MethodAction}   {SiteUtils.FriendlyErrorMessage(GE_Countries.GlobalError)}");
                    return Json(new { success = false, responseText = "is not  {MethodAction} {" + SiteUtils.FriendlyErrorMessage(GE_Countries.GlobalError) });
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

                        //  bool done = new GE_CountriesVM().Delete(Convert.ToInt32(id));
                        var GE_Countries = new GE_CountriesVM();
                        GE_Countries.LogonUser = User.Identity.Name;
                        bool done = await GE_Countries.Delete(Convert.ToInt32(id));
                        AddPageAlerts(PageAlertType.Success, $"GE_Countries   is deleted Scussefully  {id}");
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
