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
    [BreadCrumb(Title = "CL_ClientsQuotationsMaster", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "fas fa-link")]
    [DisplayName("CL_ClientsQuotationsMasterCont")]
    public class CL_ClientsQuotationsMasterController : AppBaseController
    {

        #region loicalizations vars
        private readonly IStringLocalizer<CL_ClientsQuotationsMasterController> _controllerLocalizerizer;


        public CL_ClientsQuotationsMasterController(IStringLocalizer<SharedResource> localizer, IStringLocalizer<CL_ClientsQuotationsMasterController> aboutLocalizerizer, IStringLocalizerFactory strextlocFactory, LocalizationModelContext context
                         , ILogger<CL_ClientsQuotationsMasterController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor
) : base(_logger, localizer, strextlocFactory, context, accessor)
        {
            _controllerLocalizerizer = aboutLocalizerizer;
        }

        #endregion
        #region foriegn keys to use in lookup anjd data list
        #region get data list function for table CL_ClientsDefinition
        #endregion
        #region get data list function for table CL_PaymentCondition
        #endregion
        #region get data list function for table GE_Branchs
        #endregion
        #region get data list function for table GE_Currencies
        #endregion
        #endregion
        #region fill in list select2 for/and grid selection
        public JsonResult AllCL_ClientsQuotationsMaster(LookupFilter filter)
        {
            //      string SearchPageTitle = _controllerLocalizerizer["SearchPageTitle"].Value;
            ClearFilter(ref filter);
            return Json(new CL_ClientsQuotationsMasterDatalist { Filter = filter }.GetData());
        }
        [HttpGet]
        public async Task<JsonResult> GetCL_ClientsQuotationsMasterName(string ID)
        {
            return Json(await new CL_ClientsQuotationsMasterVM().GetNameByID(ID));
        }
        [HttpGet]
        public JsonResult getCL_ClientsQuotationsMasterSelect()
        {
            return Json(new CL_ClientsQuotationsMasterVM().GetCL_ClientsQuotationsMasterForLkp());
        }
        public async Task<JsonResult> getCL_ClientsQuotationsMasterList()
        {
            return Json(await new CL_ClientsQuotationsMasterVM().GetAll().ToListAsync());
        }
        public async Task<JsonResult> getCL_ClientsQuotationsMasterFilteredList(string filterColumn, string filterValue)
        {
            if (filterValue != null)
            {
                return Json(await new CL_ClientsQuotationsMasterVM().GetAll().Where(o => o.ClientQuotationNo.ToString().Contains(filterValue)).ToListAsync());
            }
            else
                return Json("No Data");
        }
        #endregion
        #region get lookup options list function for table CL_ClientsQuotationsMaster
        public JsonResult getCL_ClientsQuotationsMasterSelectlkp(LookupFilter filter)
        {
            try
            {
                var CL_ClientsQuotationsMaster = new CL_ClientsQuotationsMasterVM().GetCL_ClientsQuotationsMasterForLkp().Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = CL_ClientsQuotationsMaster });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion
        #region Index

        // GET: CL_ClientsQuotationsMaster
        [BreadCrumb(Title = "Listing", Order = 1)]
        [DisplayName("CL_ClientsQuotationsMasterCont")]
        [HelpDefinition]
        public async Task<ActionResult> Index()
        //public async Task<ActionResult>  Index(Int32? page, Int32? rows)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            //var CL_ClientsQuotationsMasterLocal= db.CL_ClientsQuotationsMaster;
            return View(await new CL_ClientsQuotationsMasterVM().GetAll().ToListAsync());
            #region manually paging grid
            //var page = Request.Query["CL_ClientsQuotationsMastergrid-Page"].ToString().ToNullable<int>() ?? 1;
            //          var rows = Request.Query["CL_ClientsQuotationsMastergrid-Rows"].ToString().ToNullable<int>() ?? 20;
            //           var currentpage = page ?? 1;//== 0 ? 1 : page;;
            //           ViewBag.TotalRows = await new CL_ClientsQuotationsMasterVM().GetCount();
            //           var records = await new CL_ClientsQuotationsMasterVM().GetPaged(currentpage).ToListAsync();
            //           return View(records);
            #endregion
        }
        [BreadCrumb(Title = "  Listing", Order = 1)]
        [DisplayName("CL_ClientsQuotationsMasterCont")]
        [HelpDefinition]
        public async Task<ActionResult> IndexNumber(string txtSearch)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            if (txtSearch != null)
            {
                //long searchtxt = Int64.Parse(txtSearch);
                return View(await new CL_ClientsQuotationsMasterVM().GetAll()
                    .Where(x => x.ClientQuotationNo.ToString() == txtSearch)
                    .OrderBy(x => x.BranchCode)
                     .ToListAsync()
                    );
            }
            else
                return View();
        }
        #endregion
        #region Details


        // GET: CL_ClientsQuotationsMaster/Details/5
        [BreadCrumb(Title = " Details", Order = 1)]
        [HelpDefinition]
        public async Task<ActionResult> Details(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DetailsPage"]);
            tblCL_ClientsQuotationsMaster CL_ClientsQuotationsMaster = await new CL_ClientsQuotationsMasterVM().Find(id);
            if (CL_ClientsQuotationsMaster == null)
            {
                return BadRequest();
            }
            return View(CL_ClientsQuotationsMaster);
        }
        #endregion
        #region Create


        // GET: CL_ClientsQuotationsMaster/Create
        [BreadCrumb(Title = " Create", Order = 1)]
        [HelpDefinition]
        public ActionResult Create()
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["CreatePage"]);
            return View();
        }

        // POST: CL_ClientsQuotationsMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("BranchCode,ClientQuotationNo,RefQuotationNo,SalesRepName,OrderDate,JobName,CityCountry,ClientCode,NewClientName,ResponsMan,PaymentCode,TransportCode,CurrencyCode,Memo,ValidityNo1,ValidityNo2,PaymentNo1,PaymentNo2,StarageArea,Delivery,Prices,QuotationStatus,TotalQuotation,Status,TimeStamp,")] tblCL_ClientsQuotationsMaster CL_ClientsQuotationsMastered
)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    CL_ClientsQuotationsMasterVM toSave = new CL_ClientsQuotationsMasterVM() { CL_ClientsQuotationsMaster = CL_ClientsQuotationsMastered };
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
                    return View(CL_ClientsQuotationsMastered);
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {CL_ClientsQuotationsMastered.ClientQuotationNo} is was not {MethodAction} with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  ID {CL_ClientsQuotationsMastered.ClientQuotationNo} is was not {MethodAction} with Error {dex.Message}  ");

            }
            return View(CL_ClientsQuotationsMastered);
        }
        #endregion
        #region Edit

        // preapre view model for edit
        public async Task<tblCL_ClientsQuotationsMaster> EditHelper(int id)
        {

            tblCL_ClientsQuotationsMaster CL_ClientsQuotationsMastered = await new CL_ClientsQuotationsMasterVM().Find(id);

            #region preapre details for page CL_ClientsQuotationsDetail
            //preapre details 
            //var CL_ClientsQuotationsDetailRecords = new CL_ClientsQuotationsDetailVM().GetAll(id);
            #endregion

            #region preapre details for page CL_ClientsQuotationsDetail
            //preapre details 
            //var CL_ClientsQuotationsDetailRecords = new CL_ClientsQuotationsDetailVM().GetAll(id);
            #endregion

            tblCL_ClientsQuotationsMaster CL_ClientsQuotationsMasterVMed = new tblCL_ClientsQuotationsMaster()
            {
                BranchCode = CL_ClientsQuotationsMastered.BranchCode
                     ,
                ClientQuotationNo = CL_ClientsQuotationsMastered.ClientQuotationNo
                     ,
                RefQuotationNo = CL_ClientsQuotationsMastered.RefQuotationNo
                     ,
                SalesRepName = CL_ClientsQuotationsMastered.SalesRepName
                     ,
                OrderDate = CL_ClientsQuotationsMastered.OrderDate
                     ,
                JobName = CL_ClientsQuotationsMastered.JobName
                     ,
                CityCountry = CL_ClientsQuotationsMastered.CityCountry
                     ,
                ClientCode = CL_ClientsQuotationsMastered.ClientCode
                     ,
                NewClientName = CL_ClientsQuotationsMastered.NewClientName
                     ,
                ResponsMan = CL_ClientsQuotationsMastered.ResponsMan
                     ,
                PaymentCode = CL_ClientsQuotationsMastered.PaymentCode
                     ,
                TransportCode = CL_ClientsQuotationsMastered.TransportCode
                     ,
                CurrencyCode = CL_ClientsQuotationsMastered.CurrencyCode
                     ,
                Memo = CL_ClientsQuotationsMastered.Memo
                     ,
                ValidityNo1 = CL_ClientsQuotationsMastered.ValidityNo1
                     ,
                ValidityNo2 = CL_ClientsQuotationsMastered.ValidityNo2
                     ,
                PaymentNo1 = CL_ClientsQuotationsMastered.PaymentNo1
                     ,
                PaymentNo2 = CL_ClientsQuotationsMastered.PaymentNo2
                     ,
                StarageArea = CL_ClientsQuotationsMastered.StarageArea
                     ,
                Delivery = CL_ClientsQuotationsMastered.Delivery
                     ,
                Prices = CL_ClientsQuotationsMastered.Prices
                     ,
                QuotationStatus = CL_ClientsQuotationsMastered.QuotationStatus
                     ,
                TotalQuotation = CL_ClientsQuotationsMastered.TotalQuotation
                     ,
                Status = CL_ClientsQuotationsMastered.Status
                     ,
                TimeStamp = CL_ClientsQuotationsMastered.TimeStamp
                //                 , ShowGrid = true
                //                 , CL_ClientsQuotationsDetailDetails = CL_ClientsQuotationsDetailRecords.ToList()
                //                 , CL_ClientsQuotationsDetailDetails = CL_ClientsQuotationsDetailRecords.ToList()
            }
                ;

            // fill in the details with emopty row for grid to add and show it 
            //   CL_ClientsQuotationsMasterVMed.CL_ClientsQuotationsDetailDetails.Add(new CL_ClientsQuotationsDetailVM().GetEmpty());

            // fill in the details with emopty row for grid to add and show it 
            //   CL_ClientsQuotationsMasterVMed.CL_ClientsQuotationsDetailDetails.Add(new CL_ClientsQuotationsDetailVM().GetEmpty());

            return CL_ClientsQuotationsMasterVMed;
        }

        // GET: CL_ClientsQuotationsMaster/Edit/5
        [HelpDefinition]
        [BreadCrumb(Title = " Edit", Order = 1)]
        public async Task<ActionResult> Edit(int id)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["EditPage"]);
            tblCL_ClientsQuotationsMaster CL_ClientsQuotationsMastered = await new CL_ClientsQuotationsMasterVM().Find(id);
            if (CL_ClientsQuotationsMastered == null)
            {
                return BadRequest();
            }
            return View(EditHelper(id).Result);
        }

        // POST: CL_ClientsQuotationsMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BreadCrumb(Title = "  Edit", Order = 1)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("BranchCode,ClientQuotationNo,RefQuotationNo,SalesRepName,OrderDate,JobName,CityCountry,ClientCode,NewClientName,ResponsMan,PaymentCode,TransportCode,CurrencyCode,Memo,ValidityNo1,ValidityNo2,PaymentNo1,PaymentNo2,StarageArea,Delivery,Prices,QuotationStatus,TotalQuotation,Status,TimeStamp,")] tblCL_ClientsQuotationsMaster CL_ClientsQuotationsMastered)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    CL_ClientsQuotationsMasterVM toSave = new CL_ClientsQuotationsMasterVM() { CL_ClientsQuotationsMaster = CL_ClientsQuotationsMastered };
                    toSave.LogonUser = User.Identity.Name;
                    int? ID = await toSave.Update();
                    if (ID == -1)
                        throw new System.ArgumentException(toSave.GlobalError, "DBlevel");


                    logger.LogInformation($"{MethodTable} ID {ID} is {MethodAction} Scussefully  ");

                    return View(EditHelper(CL_ClientsQuotationsMastered.ClientQuotationNo).Result);
                }
                else
                {

                    logger.LogInformation(MethodTable + " ID { 0}  input Error  ", string.Join(",", SiteUtils.GetModelErrros(ModelState)));
                    return View(CL_ClientsQuotationsMastered);
                }
            }
            catch (Exception dex)
            {
                logger.LogError($" {MethodTable}  ID {CL_ClientsQuotationsMastered.ClientQuotationNo} is was not  {MethodAction}  with Error {dex.Message}  ");
                //ModelState.AddModelError($" {MethodTable}  ID {CL_ClientsQuotationsMastered.ClientQuotationNo} is was not  {MethodAction}  with Error {dex.Message}  ");

            }
            return View(EditHelper(CL_ClientsQuotationsMastered.ClientQuotationNo).Result);
        }
        #endregion
        #region Delete


        // GET: CL_ClientsQuotationsMaster/Delete/5
        [BreadCrumb(Title = " Delete", Order = 1)]
        [HelpDefinition]
        //   public async Task<ActionResult> Delete(int id)
        public async Task<ActionResult> Delete(int id, string saveChangesError = "")
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["DeletePage"]);
            tblCL_ClientsQuotationsMaster CL_ClientsQuotationsMaster = await new CL_ClientsQuotationsMasterVM().Find(id);
            if (CL_ClientsQuotationsMaster == null)
            {
                return BadRequest();
            }
            ViewData["ErrorMessage"] = saveChangesError;
            return PartialView("Delete", CL_ClientsQuotationsMaster.lookupName);
        }

        // POST: CL_ClientsQuotationsMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [BreadCrumb(Title = " Delete", Order = 1)]
        public async Task<JsonResult> Delete(int id)
        {

            try
            {
                var CL_ClientsQuotationsMaster = new CL_ClientsQuotationsMasterVM();
                CL_ClientsQuotationsMaster.LogonUser = User.Identity.Name;
                bool done = await CL_ClientsQuotationsMaster.Delete(id);

                if (done)
                {


                    logger.LogInformation($"{MethodTable} ID {id} is {MethodAction} Scussefully  ");
                    return Json(new { success = true, responseText = "Deleted Scussefully" });
                }
                else
                {

                    //ModelState.AddModelError("", "Unable to save changes. " + SiteUtils.FriendlyErrorMessage(CL_ClientsQuotationsMaster.GlobalError ));
                    logger.LogInformation($" CL_ClientsQuotationsMaster ID {id} is not  {MethodAction}   {SiteUtils.FriendlyErrorMessage(CL_ClientsQuotationsMaster.GlobalError)}");
                    return Json(new { success = false, responseText = "is not  {MethodAction} {" + SiteUtils.FriendlyErrorMessage(CL_ClientsQuotationsMaster.GlobalError) });
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

                        //  bool done = new CL_ClientsQuotationsMasterVM().Delete(Convert.ToInt32(id));
                        var CL_ClientsQuotationsMaster = new CL_ClientsQuotationsMasterVM();
                        CL_ClientsQuotationsMaster.LogonUser = User.Identity.Name;
                        bool done = await CL_ClientsQuotationsMaster.Delete(Convert.ToInt32(id));
                        AddPageAlerts(PageAlertType.Success, $"CL_ClientsQuotationsMaster   is deleted Scussefully  {id}");
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
