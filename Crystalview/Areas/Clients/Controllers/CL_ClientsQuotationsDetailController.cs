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
    [BreadCrumb(Title = "CL_ClientsQuotationsDetail", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = false, Order = 0, GlyphIcon = "fas fa-link")]
    [DisplayName("CL_ClientsQuotationsDetailCont")]
    public class CL_ClientsQuotationsDetailController : AppBaseController
    {

        #region loicalizations vars
        private readonly IStringLocalizer<CL_ClientsQuotationsDetailController> _controllerLocalizerizer;


        public CL_ClientsQuotationsDetailController(IStringLocalizer<SharedResource> localizer, IStringLocalizer<CL_ClientsQuotationsDetailController> aboutLocalizerizer, IStringLocalizerFactory strextlocFactory, LocalizationModelContext context
                         , ILogger<CL_ClientsQuotationsDetailController> _logger, Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor accessor
) : base(_logger, localizer, strextlocFactory, context, accessor)
        {
            _controllerLocalizerizer = aboutLocalizerizer;
        }

        #endregion
        #region foriegn keys to use in lookup anjd data list
        #region get data list function for table CL_ClientsQuotationsMaster
        #endregion
        #region get data list function for table CL_ClientsQuotationsMaster
        #endregion
        #endregion
        #region fill in list select2 for/and grid selection
        public JsonResult AllCL_ClientsQuotationsDetail(LookupFilter filter)
        {
            //      string SearchPageTitle = _controllerLocalizerizer["SearchPageTitle"].Value;
            ClearFilter(ref filter);
            return Json(new CL_ClientsQuotationsDetailDatalist { Filter = filter }.GetData());
        }
        [HttpGet]
        public async Task<JsonResult> GetCL_ClientsQuotationsDetailName(string ID)
        {
            return Json(await new CL_ClientsQuotationsDetailVM().GetNameByID(ID));
        }
        [HttpGet]
        public JsonResult getCL_ClientsQuotationsDetailSelect()
        {
            return Json(new CL_ClientsQuotationsDetailVM().GetCL_ClientsQuotationsDetailForLkp(-1));
        }
        public async Task<JsonResult> getCL_ClientsQuotationsDetailList(int ClientQuotationNo)
        {
            return Json(await new CL_ClientsQuotationsDetailVM().GetAll(ClientQuotationNo).ToListAsync());
        }
        public async Task<JsonResult> getCL_ClientsQuotationsDetailFilteredList(string filterColumn, string filterValue)
        {
            if (filterValue != null)
            {
                return Json(await new CL_ClientsQuotationsDetailVM().GetAll(Int32.Parse(filterValue)).ToListAsync());//).Where(o => o.ClientQuotationNo.ToString().Contains(filterValue)).ToListAsync());
            }
            else
                return Json("No Data");
        }
        #endregion
        #region get lookup options list function for table CL_ClientsQuotationsDetail
        public JsonResult getCL_ClientsQuotationsDetailSelectlkp(LookupFilter filter)
        {
            try
            {
                var CL_ClientsQuotationsDetail = new CL_ClientsQuotationsDetailVM().GetCL_ClientsQuotationsDetailForLkp(-1).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = CL_ClientsQuotationsDetail });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion
        #region Index

        // GET: CL_ClientsQuotationsDetail
        [BreadCrumb(Title = "Listing", Order = 1)]
        [DisplayName("CL_ClientsQuotationsDetailCont")]
        [HelpDefinition]
        public async Task<ActionResult> Index()
        //public async Task<ActionResult>  Index(Int32? page, Int32? rows)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            //var CL_ClientsQuotationsDetailLocal= db.CL_ClientsQuotationsDetail;
            return View(await new CL_ClientsQuotationsDetailVM().GetAll(-1).ToListAsync());
            #region manually paging grid
            //var page = Request.Query["CL_ClientsQuotationsDetailgrid-Page"].ToString().ToNullable<int>() ?? 1;
            //          var rows = Request.Query["CL_ClientsQuotationsDetailgrid-Rows"].ToString().ToNullable<int>() ?? 20;
            //           var currentpage = page ?? 1;//== 0 ? 1 : page;;
            //           ViewBag.TotalRows = await new CL_ClientsQuotationsDetailVM().GetCount();
            //           var records = await new CL_ClientsQuotationsDetailVM().GetPaged(currentpage).ToListAsync();
            //           return View(records);
            #endregion
        }
        [BreadCrumb(Title = "  Listing", Order = 1)]
        [DisplayName("CL_ClientsQuotationsDetailCont")]
        [HelpDefinition]
        public async Task<ActionResult> IndexNumber(string txtSearch)
        {
            AddPageHeader(_controllerLocalizerizer["PageTitle"], _controllerLocalizerizer["IndexPage"]);
            if (txtSearch != null)
            {
                //long searchtxt = Int64.Parse(txtSearch);
                return View(await new CL_ClientsQuotationsDetailVM().GetAll(-1)
                    .Where(x => x.ClientQuotationNo == -1)
                    .OrderBy(x => x.BranchCode)
                     .ToListAsync()
                    );
            }
            else
                return View();
        }
        #endregion
        #region Create


        // POST: CL_ClientsQuotationsDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create([Bind("BranchCode,ClientQuotationNo,SerialNo,ClientCode,ItemCode,AltCode,Quantity,Price,Value,ValueddTaxP,ValueaddTaxV,Dedaction,TimeStamp,")] tblCL_ClientsQuotationsDetail CL_ClientsQuotationsDetailed)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    CL_ClientsQuotationsDetailVM toSave = new CL_ClientsQuotationsDetailVM() { CL_ClientsQuotationsDetail = CL_ClientsQuotationsDetailed };
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
                logger.LogError($" {MethodTable}  ID {CL_ClientsQuotationsDetailed.ClientQuotationNo} is was not  {MethodAction}  with Error {dex.Message}  ");
                //ModelState.AddModelError("", "Unable to save changes. " + dex.Message);

                return Json(new { success = false, responseText = dex.Message });
            }
            //return Json(new { success = true, responseText = "end of Page" } );
        }
        #endregion
        #region Edit



        // POST: CL_ClientsQuotationsDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [BreadCrumb(Title = " Update", Order = 1)]
        public async Task<ActionResult> Update([FromBody] List<tblCL_ClientsQuotationsDetail> CL_ClientsQuotationsDetailed)
        {
            try
            {

                CL_ClientsQuotationsDetailVM tbl = new CL_ClientsQuotationsDetailVM();

                // only get unique values to avoid duplication of data from grid array
                foreach (tblCL_ClientsQuotationsDetail element in CL_ClientsQuotationsDetailed.Distinctbylast(p => p.SerialNo))
                {
                    if (element.SerialNo < 0)
                        element.SerialNo = 0;
                    tbl.CL_ClientsQuotationsDetail = element;
                    //if did not save return same erro message here
                    int Result = await tbl.Update();
                    if (Result == -1)
                        throw new System.ArgumentException(tbl.GlobalError, "DBlevel");
                }

                logger.LogInformation($"{MethodTable} Count {CL_ClientsQuotationsDetailed.Count} is {MethodAction} Scussefully  ");

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

        // POST: CL_ClientsQuotationsDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [BreadCrumb(Title = " Delete", Order = 1)]
        public async Task<JsonResult> Delete([FromBody] int id)
        {

            try
            {
                var CL_ClientsQuotationsDetail = new CL_ClientsQuotationsDetailVM();
                CL_ClientsQuotationsDetail.LogonUser = User.Identity.Name;
                bool done = await CL_ClientsQuotationsDetail.Delete(id);

                if (done)
                {


                    logger.LogInformation($"{MethodTable} ID {id} is {MethodAction} Scussefully  ");
                    return Json(new { success = true, responseText = "Deleted Scussefully" });
                }
                else
                {

                    //ModelState.AddModelError("", "Unable to save changes. " + SiteUtils.FriendlyErrorMessage(CL_ClientsQuotationsDetail.GlobalError ));
                    logger.LogInformation($" CL_ClientsQuotationsDetail ID {id} is not  {MethodAction}   {SiteUtils.FriendlyErrorMessage(CL_ClientsQuotationsDetail.GlobalError)}");
                    return Json(new { success = false, responseText = "is not  {MethodAction} {" + SiteUtils.FriendlyErrorMessage(CL_ClientsQuotationsDetail.GlobalError) });
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
                        var CL_ClientsQuotationsDetail = new CL_ClientsQuotationsDetailVM();
                        CL_ClientsQuotationsDetail.LogonUser = User.Identity.Name;
                        bool done = await CL_ClientsQuotationsDetail.Delete(Convert.ToInt32(id));
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
