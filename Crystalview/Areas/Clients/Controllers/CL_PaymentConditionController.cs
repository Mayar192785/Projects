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
    [Area("Clients")]
    [BreadCrumb(Title = "CL_PaymentCondition", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "fas fa-link")]
    [DisplayName("CL_PaymentConditionCont")]
    public class CL_PaymentConditionController : AppBaseController
    {

        #region loicalizations vars
        private readonly IStringLocalizer<CL_PaymentConditionController> _controllerLocalizerizer;


        public CL_PaymentConditionController(IStringLocalizer<SharedResource> localizer, IStringLocalizer<CL_PaymentConditionController> aboutLocalizerizer, IStringLocalizerFactory strextlocFactory, LocalizationModelContext context
                         , ILogger<CL_PaymentConditionController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor
) : base(_logger, localizer, strextlocFactory, context, accessor)
        {
            _controllerLocalizerizer = aboutLocalizerizer;
        }

        #endregion
        #region foriegn keys to use in lookup anjd data list
        #endregion
        #region fill in list select2 for/and grid selection
        public JsonResult AllCL_PaymentCondition(LookupFilter filter)
        {
            //      string SearchPageTitle = _controllerLocalizerizer["SearchPageTitle"].Value;
            ClearFilter(ref filter);
            return Json(new CL_PaymentConditionDatalist { Filter = filter }.GetData());
        }
        [HttpGet]
        public async Task<JsonResult> GetCL_PaymentConditionName(string ID)
        {
            return Json(await new CL_PaymentConditionVM().GetNameByID(ID));
        }
        [HttpGet]
        public JsonResult getCL_PaymentConditionSelect()
        {
            return Json(new CL_PaymentConditionVM().GetCL_PaymentConditionForLkp());
        }
        public async Task<JsonResult> getCL_PaymentConditionList()
        {
            return Json(await new CL_PaymentConditionVM().GetAll().ToListAsync());
        }
        public async Task<JsonResult> getCL_PaymentConditionFilteredList(string filterColumn, string filterValue)
        {
            if (filterValue != null)
            {
                return Json(await new CL_PaymentConditionVM().GetAll().Where(o => o.PaymentNameA.ToString().Contains(filterValue)).ToListAsync());
            }
            else
                return Json("No Data");
        }
        #endregion
        #region get lookup options list function for table CL_PaymentCondition
        public JsonResult getCL_PaymentConditionSelectlkp(LookupFilter filter)
        {
            try
            {
                var CL_PaymentCondition = new CL_PaymentConditionVM().GetCL_PaymentConditionForLkp().Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = CL_PaymentCondition });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion
        #region Index

        // GET: CL_PaymentCondition
        [BreadCrumb(Title = "Listing", Order = 1)]
        [DisplayName("CL_PaymentConditionCont")]
        [HelpDefinition]
        public async Task<ActionResult> Index()
        //public async Task<ActionResult>  Index(Int32? page, Int32? rows)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            //var CL_PaymentConditionLocal= db.CL_PaymentCondition;
            return View(await new CL_PaymentConditionVM().GetAll().ToListAsync());
            #region manually paging grid
            //var page = Request.Query["CL_PaymentConditiongrid-Page"].ToString().ToNullable<int>() ?? 1;
            //          var rows = Request.Query["CL_PaymentConditiongrid-Rows"].ToString().ToNullable<int>() ?? 20;
            //           var currentpage = page ?? 1;//== 0 ? 1 : page;;
            //           ViewBag.TotalRows = await new CL_PaymentConditionVM().GetCount();
            //           var records = await new CL_PaymentConditionVM().GetPaged(currentpage).ToListAsync();
            //           return View(records);
            #endregion
        }
        [BreadCrumb(Title = "  Listing", Order = 1)]
        [DisplayName("CL_PaymentConditionCont")]
        [HelpDefinition]
        public async Task<ActionResult> IndexNumber(string txtSearch)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            if (txtSearch != null)
            {
                //long searchtxt = Int64.Parse(txtSearch);
                return View(await new CL_PaymentConditionVM().GetAll()
                    .Where(x => x.PaymentNameA == txtSearch)
                    .OrderBy(x => x.PaymentCode)
                     .ToListAsync()
                    );
            }
            else
                return View();
        }
        #endregion
        #region Details


        // GET: CL_PaymentCondition/Details/5
        [BreadCrumb(Title = " Details", Order = 1)]
        [HelpDefinition]
        public async Task<ActionResult> Details(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DetailsPage"]);
            tblCL_PaymentCondition CL_PaymentCondition = await new CL_PaymentConditionVM().Find(id);
            if (CL_PaymentCondition == null)
            {
                return BadRequest();
            }
            return View(CL_PaymentCondition);
        }
        #endregion
        #region Create


        // GET: CL_PaymentCondition/Create
        [BreadCrumb(Title = " Create", Order = 1)]
        [HelpDefinition]
        public ActionResult Create()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["CreatePage"]);
            return View();
        }

        // POST: CL_PaymentCondition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("PaymentCode,PaymentNameA,PaymentNameE,DealWBank,AccountName,BankName,BranchNo,AccountNo,SwiftCode,IBAN,Status,TimeStamp,")] tblCL_PaymentCondition CL_PaymentConditioned
)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    CL_PaymentConditionVM toSave = new CL_PaymentConditionVM() { CL_PaymentCondition = CL_PaymentConditioned };
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
                    return View(CL_PaymentConditioned);
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {CL_PaymentConditioned.PaymentCode} is was not {MethodAction} with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  ID {CL_PaymentConditioned.ID} is was not {MethodAction} with Error {dex.Message}  ");

            }
            return View(CL_PaymentConditioned);
        }
        #endregion
        #region Edit


        // GET: CL_PaymentCondition/Edit/5
        [HelpDefinition]
        [BreadCrumb(Title = " Edit", Order = 1)]
        public async Task<ActionResult> Edit(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["EditPage"]);
            tblCL_PaymentCondition CL_PaymentConditioned = await new CL_PaymentConditionVM().Find(id);
            if (CL_PaymentConditioned == null)
            {
                return BadRequest();
            }
            return View(CL_PaymentConditioned);
        }

        // POST: CL_PaymentCondition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BreadCrumb(Title = "  Edit", Order = 1)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("PaymentCode,PaymentNameA,PaymentNameE,DealWBank,AccountName,BankName,BranchNo,AccountNo,SwiftCode,IBAN,Status,TimeStamp,")] tblCL_PaymentCondition CL_PaymentConditioned)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    CL_PaymentConditionVM toSave = new CL_PaymentConditionVM() { CL_PaymentCondition = CL_PaymentConditioned };
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
                    return View(CL_PaymentConditioned);
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {CL_PaymentConditioned.PaymentCode} is was not  {MethodAction}  with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  ID {CL_PaymentConditioned.ID} is was not  {MethodAction}  with Error {dex.Message}  ");

            }
            return View(CL_PaymentConditioned);
        }
        #endregion
        #region Delete


        // GET: CL_PaymentCondition/Delete/5
        [BreadCrumb(Title = " Delete", Order = 1)]
        [HelpDefinition]
        //   public async Task<ActionResult> Delete(int id)
        public async Task<ActionResult> Delete(int id, string saveChangesError = "")
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DeletePage"]);
            tblCL_PaymentCondition CL_PaymentCondition = await new CL_PaymentConditionVM().Find(id);
            if (CL_PaymentCondition == null)
            {
                return BadRequest();
            }
            ViewData["ErrorMessage"] = saveChangesError;
            return PartialView("Delete", CL_PaymentCondition.lookupName);
        }

        // POST: CL_PaymentCondition/Delete/5
        [HttpPost, ActionName("Delete")]
        [BreadCrumb(Title = " Delete", Order = 1)]
        public async Task<JsonResult> Delete(int id)
        {

            try
            {
                var CL_PaymentCondition = new CL_PaymentConditionVM();
                CL_PaymentCondition.LogonUser = User.Identity.Name;
                bool done = await CL_PaymentCondition.Delete(id);

                if (done)
                {


                    logger.LogInformation($"{MethodTable} ID {id} is {MethodAction} Scussefully  ");
                    return Json(new { success = true, responseText = "Deleted Scussefully" });
                }
                else
                {

                    //ModelState.AddModelError("", "Unable to save changes. " + SiteUtils.FriendlyErrorMessage(CL_PaymentCondition.GlobalError ));
                    logger.LogInformation($" CL_PaymentCondition ID {id} is not  {MethodAction}   {SiteUtils.FriendlyErrorMessage(CL_PaymentCondition.GlobalError)}");
                    return Json(new { success = false, responseText = "is not  {MethodAction} {" + SiteUtils.FriendlyErrorMessage(CL_PaymentCondition.GlobalError) });
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

                        //  bool done = new CL_PaymentConditionVM().Delete(Convert.ToInt32(id));
                        var CL_PaymentCondition = new CL_PaymentConditionVM();
                        CL_PaymentCondition.LogonUser = User.Identity.Name;
                        bool done = await CL_PaymentCondition.Delete(Convert.ToInt32(id));
                        AddPageAlerts(PageAlertType.Success, $"CL_PaymentCondition   is deleted Scussefully  {id}");
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
