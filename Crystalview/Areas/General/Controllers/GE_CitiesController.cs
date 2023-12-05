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
    [BreadCrumb(Title = "GE_Cities", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "fas fa-link")]
    [DisplayName("GE_CitiesCont")]
    public class GE_CitiesController : AppBaseController
    {

        #region loicalizations vars
        private readonly IStringLocalizer<GE_CitiesController> _controllerLocalizerizer;


        public GE_CitiesController(IStringLocalizer<SharedResource> localizer, IStringLocalizer<GE_CitiesController> aboutLocalizerizer, IStringLocalizerFactory strextlocFactory, LocalizationModelContext context
                         , ILogger<GE_CitiesController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor
) : base(_logger, localizer, strextlocFactory, context, accessor)
        {
            _controllerLocalizerizer = aboutLocalizerizer;
        }

        #endregion
        #region foriegn keys to use in lookup anjd data list
        #endregion
        #region fill in list select2 for/and grid selection
        public JsonResult AllGE_Cities(LookupFilter filter)
        {
            //      string SearchPageTitle = _controllerLocalizerizer["SearchPageTitle"].Value;
            ClearFilter(ref filter);
            return Json(new GE_CitiesDatalist { Filter = filter }.GetData());
        }
        [HttpGet]
        public async Task<JsonResult> GetGE_CitiesName(string ID)
        {
            return Json(await new GE_CitiesVM().GetNameByID(ID));
        }
        [HttpGet]
        public JsonResult getGE_CitiesSelect()
        {
            return Json(new GE_CitiesVM().GetGE_CitiesForLkp(-1));
        }
        public async Task<JsonResult> getGE_CitiesList(int CityCode)
        {
            return Json(await new GE_CitiesVM().GetAll(CityCode).ToListAsync());
        }
        public async Task<JsonResult> getGE_CitiesFilteredList(string filterColumn, string filterValue)
        {
            if (filterValue != null)
            {
                return Json(await new GE_CitiesVM().GetAll(Int32.Parse(filterValue)).ToListAsync());//).Where(o => o.CityCode.ToString().Contains(filterValue)).ToListAsync());
            }
            else
                return Json("No Data");
        }
        #endregion
        #region get lookup options list function for table GE_Cities
        public JsonResult getGE_CitiesSelectlkp(LookupFilter filter)
        {
            try
            {
                var GE_Cities = new GE_CitiesVM().GetGE_CitiesForLkp(-1).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = GE_Cities });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion
        #region Index

        // GET: GE_Cities
        [BreadCrumb(Title = "Listing", Order = 1)]
        [DisplayName("GE_CitiesCont")]
        [HelpDefinition]
        public async Task<ActionResult> Index()
        //public async Task<ActionResult>  Index(Int32? page, Int32? rows)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            //var GE_CitiesLocal= db.GE_Cities;
            return View(await new GE_CitiesVM().GetAll(-1).ToListAsync());
            #region manually paging grid
            //var page = Request.Query["GE_Citiesgrid-Page"].ToString().ToNullable<int>() ?? 1;
            //          var rows = Request.Query["GE_Citiesgrid-Rows"].ToString().ToNullable<int>() ?? 20;
            //           var currentpage = page ?? 1;//== 0 ? 1 : page;;
            //           ViewBag.TotalRows = await new GE_CitiesVM().GetCount();
            //           var records = await new GE_CitiesVM().GetPaged(currentpage).ToListAsync();
            //           return View(records);
            #endregion
        }
        [BreadCrumb(Title = "  Listing", Order = 1)]
        [DisplayName("GE_CitiesCont")]
        [HelpDefinition]
        public async Task<ActionResult> IndexNumber(string txtSearch)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            if (txtSearch != null)
            {
                //long searchtxt = Int64.Parse(txtSearch);
                return View(await new GE_CitiesVM().GetAll(-1)
                    .Where(x => x.CityCode == -1)
                    .OrderBy(x => x.CountryCode)
                     .ToListAsync()
                    );
            }
            else
                return View();
        }
        #endregion
        #region Create


        // POST: GE_Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create([Bind("CountryCode,CityCode,CityNameA,CityNameE,")] tblGE_Cities GE_Citiesed)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    GE_CitiesVM toSave = new GE_CitiesVM() { GE_Cities = GE_Citiesed };
                    toSave.LogonUser = User.Identity.Name;
                    int? ID = await toSave.Insert();
                    if (ID == -1)
                        throw new System.ArgumentException(toSave.GlobalError, "DBlevel");

                    logger.LogInformation($"{MethodTable} ID {ID} is {MethodAction} Scussefully  ");
                    return Json(new { success = true, responseText = "Created Scussefully" });
                }
                else
                    return Json(new { success = true, responseText = "invalid input" });
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {GE_Citiesed.CityCode} is was not  {MethodAction}  with Error {dex.Message}  ");
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);

                return Json(new { success = false, responseText = dex.Message });
            }
            //return Json(new { success = true, responseText = "end of Page" } );
        }
        #endregion
        #region Edit



        // POST: GE_Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BreadCrumb(Title = " Update", Order = 1)]
        public async Task<ActionResult> Update([FromBody] List<tblGE_Cities> GE_Citiesed)
        {
            try
            {

                GE_CitiesVM tbl = new GE_CitiesVM();

                // only get unique values to avoid duplication of data from grid array
                foreach (tblGE_Cities element in GE_Citiesed.Distinctbylast(p => p.CityCode))
                {
                    if (element.CityCode < 0)
                        element.CityCode = 0;
                    tbl.GE_Cities = element;
                    //if did not save return same erro message here
                    int Result = await tbl.Update();
                    if (Result == -1)
                        throw new System.ArgumentException(tbl.GlobalError, "DBlevel");
                }

                logger.LogInformation($"{MethodTable} Count {GE_Citiesed.Count} is {MethodAction} Scussefully  ");

                return Json(new { success = true });
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  is was not  {MethodAction}  with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  is was not  {MethodAction}  with Error {dex.Message}  ");

                return Json(new { success = false, responseText = dex.Message });
            }
            //return Json(new { success = true, responseText = "end of Page" } );
        }
        #endregion
        #region Delete

        // POST: GE_Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [BreadCrumb(Title = " Delete", Order = 1)]
        public async Task<JsonResult> Delete([FromBody] int id)
        {

            try
            {
                var GE_Cities = new GE_CitiesVM();
                GE_Cities.LogonUser = User.Identity.Name;
                bool done = await GE_Cities.Delete(id);

                if (done)
                {


                    logger.LogInformation($"{MethodTable} ID {id} is {MethodAction} Scussefully  ");
                    return Json(new { success = true, responseText = "Deleted Scussefully" });
                }
                else
                {

                    //ModelState.AddModelError("", "Unable to save changes. " + SiteUtils.FriendlyErrorMessage(GE_Cities.GlobalError ));
                    logger.LogInformation($" GE_Cities ID {id} is not  {MethodAction}   {SiteUtils.FriendlyErrorMessage(GE_Cities.GlobalError)}");
                    return Json(new { success = false, responseText = "is not  {MethodAction} {" + SiteUtils.FriendlyErrorMessage(GE_Cities.GlobalError) });
                }

            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  is was not {MethodAction} with Error {dex.Message}  ");
                // ModelState.AddModelError("", "Unable to save changes. " + dex.Message);

                return Json(new { success = false, responseText = dex.Message });
            }

        }

        [BreadCrumb(Title = "  Delete", Order = 1)]
        public async Task<ActionResult> DeleteSelected([FromBody] List<string> ids)
        {
            try
            {
                if (ids != null && ids.Count > 0)
                {
                    foreach (var id in ids)
                    {
                        var GE_Cities = new GE_CitiesVM();
                        GE_Cities.LogonUser = User.Identity.Name;
                        bool done = await GE_Cities.Delete(Convert.ToInt32(id));
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
