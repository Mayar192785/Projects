using System;
using System.Data;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Global.Globalization;
using Global;
using Global.Models;
using Global.Services;
using System.ComponentModel;
using FinanceCore;
using System.Collections.Generic;
using System.Threading;
using NLog;
using System.Linq;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using NonFactors.Mvc.Lookup;
using WTEG.Core;
using WTEG.TagHelpers;
using Microsoft.Extensions.Localization;
using LogLevel = NLog.LogLevel;

namespace FinanceCore.DBModels
{
    #region create table  class 
    /// <summary>
    /// class created tblCL_ClientsQuotationsDetail 
    /// </summary>
    public class tblCL_ClientsQuotationsDetail
    {
        #region base calss definitions
        // prepare lookup data for the dynamic form part
        public SelectList lsBranchCode => new CL_ClientsQuotationsMasterVM().GetCL_ClientsQuotationsMasterForLkp();
        [ItemsSource(ItemsProperty = nameof(lsBranchCode), ChoicesType = ChoicesTypes.DEFAULT)]
        [Display(Name = "CL_ClientsQuotationsDetail-BranchCode", Description = "CL_ClientsQuotationsDetail-Branch Code.")]
        [Required(ErrorMessage = "BranchCode is required.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 BranchCode { get; set; }

        // prepare lookup data for the dynamic form part
        public SelectList lsClientQuotationNo => new CL_ClientsQuotationsMasterVM().GetCL_ClientsQuotationsMasterForLkp();
        [ItemsSource(ItemsProperty = nameof(lsClientQuotationNo), ChoicesType = ChoicesTypes.DEFAULT)]
        [Display(Name = "CL_ClientsQuotationsDetail-ClientQuotationNo", Description = "CL_ClientsQuotationsDetail-Client Quotation No.")]
        [Required(ErrorMessage = "ClientQuotationNo is required.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ClientQuotationNo { get; set; }

        [Display(Name = "CL_ClientsQuotationsDetail-SerialNo", Description = "CL_ClientsQuotationsDetail-Serial No.")]
        [Required(ErrorMessage = "SerialNo is required.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 SerialNo { get; set; }

        [Display(Name = "CL_ClientsQuotationsDetail-ClientCode", Description = "CL_ClientsQuotationsDetail-Client Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ClientCode { get; set; }

        [Display(Name = "CL_ClientsQuotationsDetail-ItemCode", Description = "CL_ClientsQuotationsDetail-Item Code.")]
        [LookupColumn(Hidden = false)]
        [StringLength(24, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String ItemCode { get; set; }

        [Display(Name = "CL_ClientsQuotationsDetail-AltCode", Description = "CL_ClientsQuotationsDetail-Alt Code.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String AltCode { get; set; }

        [Display(Name = "CL_ClientsQuotationsDetail-Quantity", Description = "CL_ClientsQuotationsDetail-Quantity.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal Quantity { get; set; }

        [Display(Name = "CL_ClientsQuotationsDetail-Price", Description = "CL_ClientsQuotationsDetail-Price.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal Price { get; set; }

        [Display(Name = "CL_ClientsQuotationsDetail-Value", Description = "CL_ClientsQuotationsDetail-Value.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal Value { get; set; }

        [Display(Name = "CL_ClientsQuotationsDetail-ValueddTaxP", Description = "CL_ClientsQuotationsDetail-Valuedd Tax P.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal ValueddTaxP { get; set; }

        [Display(Name = "CL_ClientsQuotationsDetail-ValueaddTaxV", Description = "CL_ClientsQuotationsDetail-Valueadd Tax V.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal ValueaddTaxV { get; set; }

        [Display(Name = "CL_ClientsQuotationsDetail-Dedaction", Description = "CL_ClientsQuotationsDetail-Dedaction.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal Dedaction { get; set; }

        [Display(Name = "CL_ClientsQuotationsDetail-TimeStamp", Description = "CL_ClientsQuotationsDetail-Time Stamp.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.Date, ErrorMessage = "InvalidDate")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? TimeStamp { get; set; }
        // add full date wit hdate and time part to reading 
        public String? FullTimeStamp { get; set; }

        #region foreign key child realtions to get parent names
        [Display(Name = "CL_ClientsQuotationsDetail-BranchCode", Description = "CL_ClientsQuotationsDetail-Branch Code.")]
        [LookupColumn(Hidden = false)]
        public string? BranchCodeName { get; set; }
        [Display(Name = "CL_ClientsQuotationsDetail-ClientQuotationNo", Description = "CL_ClientsQuotationsDetail-Client Quotation No.")]
        [LookupColumn(Hidden = false)]
        public string? ClientQuotationNoName { get; set; }
        #endregion
        #endregion
        #region lookupname
        public string lookupName
        {
            get
            {
                return ClientQuotationNo.ToString();
                //        return LCNumber + "--" + SupplierIDName;
            }
            set { }
        }
        #endregion
    }
    #endregion
    #region create metModelviewa class 
    public class CL_ClientsQuotationsDetailVM : BaseVM
    {
        public tblCL_ClientsQuotationsDetail? CL_ClientsQuotationsDetail;
        #region helper fill row
        private static tblCL_ClientsQuotationsDetail ReadSingleRow(IDataRecord reader)
        {
            var dataRecord = new tblCL_ClientsQuotationsDetail
            {
                BranchCode = reader.GetValue<Int16>("BranchCode"),
                ClientQuotationNo = reader.GetValue<Int32>("ClientQuotationNo"),
                SerialNo = reader.GetValue<Int32>("SerialNo"),
                ClientCode = reader.GetValue<Int32>("ClientCode"),
                ItemCode = reader.GetValue<string>("ItemCode"),
                AltCode = reader.GetValue<string>("AltCode"),
                Quantity = reader.GetValue<decimal>("Quantity"),
                Price = reader.GetValue<decimal>("Price"),
                Value = reader.GetValue<decimal>("Value"),
                ValueddTaxP = reader.GetValue<decimal>("ValueddTaxP"),
                ValueaddTaxV = reader.GetValue<decimal>("ValueaddTaxV"),
                Dedaction = reader.GetValue<decimal>("Dedaction"),
                TimeStamp = DateTime.TryParse(reader.GetValue<string>("TimeStamp"), out DateTime TimeStampdt) ? TimeStampdt : null,
                FullTimeStamp = reader.GetValue<string>("FullTimeStamp"),
                #region foreign key child realtions to get parent names
                BranchCodeName = reader.GetValue<string>("BranchCodeName"),
                ClientQuotationNoName = reader.GetValue<string>("ClientQuotationNoName"),
                #endregion


            };

            return dataRecord;
        }
        #endregion

        #region selection helper functions
        public SelectList GetCL_ClientsQuotationsDetailForLkp(int ClientQuotationNo)
        {
            var LookupData = GetAll(ClientQuotationNo)
                .ToEnumerable()
                ;
            return new SelectList(LookupData, "ID", "lookupName");
        }

        public async Task<IEnumerable<SelectListItem>> GetCL_ClientsQuotationsDetailForLkpAsync(int ClientQuotationNo)
        {
            List<SelectListItem> LookupData = await GetAll(ClientQuotationNo)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.ClientQuotationNo.ToString(),
                        Text = n.lookupName
                    }).ToListAsync();
            return LookupData;
        }
        public async IAsyncEnumerable<tblCL_ClientsQuotationsDetail> GetAll(int ClientQuotationNo)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspCL_ClientsQuotationsDetailSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@ClientQuotationNo", ClientQuotationNo);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        yield return ReadSingleRow((IDataRecord)reader);
                    }
                }
            }
        }


        public async Task<int> GetCount()
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "SELECT IsNull(COUNT(*),1) FROM CL_ClientsQuotationsDetail";
                cmd.CommandType = CommandType.Text;
                Int32 count = (int)await cmd.ExecuteScalarAsync();

                return count;


            }
        }
        public async IAsyncEnumerable<tblCL_ClientsQuotationsDetail> GetPaged(int Page, int ClientQuotationNo)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspCL_ClientsQuotationsDetailPagedSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@Page", Page);
                cmd.Parameters.AddWithValue("@RecsPerPage", 20);
                cmd.Parameters.AddWithValue("@ClientQuotationNo", ClientQuotationNo);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        yield return ReadSingleRow((IDataRecord)reader);
                    }
                }
            }
        }


        public tblCL_ClientsQuotationsDetail GetEmpty()
        {

            return new tblCL_ClientsQuotationsDetail
            {
                BranchCode = 0,
                ClientQuotationNo = 0,
                SerialNo = 0,
                ClientCode = 0,
                ItemCode = "",
                AltCode = "",
                Quantity = 0,
                Price = 0,
                Value = 0,
                ValueddTaxP = 0,
                ValueaddTaxV = 0,
                Dedaction = 0,
                TimeStamp = DateTime.Today,
            };
        }
        public async Task<string> GetNameByID(int? id)
        {

            var ResultOne = await Find(id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.ClientQuotationNo.ToString();
        }
        public async Task<string> GetNameByID(string id)
        {
            return await GetNameByID(int.Parse(id));
        }

        public async Task<tblCL_ClientsQuotationsDetail> Find(int? id)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspCL_ClientsQuotationsDetailSelectSingle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@ID", id);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return ReadSingleRow((IDataRecord)reader);
                    }
                }
                return GetEmpty();
            }

        }
        #endregion

        #region CRUD
        public async Task<int> Insert()
        {

            try
            {
                await using (var conn = new SqlConnection(strConnection))
                await using (var cmd = conn.CreateCommand())
                {
                    await conn.OpenAsync();
                    cmd.CommandText = "uspCL_ClientsQuotationsDetailEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@ID";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@ClientQuotationNo", CL_ClientsQuotationsDetail.ClientQuotationNo);
                    cmd.Parameters.AddWithValue("@SerialNo", CL_ClientsQuotationsDetail.SerialNo);
                    cmd.Parameters.AddWithValue("@ClientCode", CL_ClientsQuotationsDetail.ClientCode);
                    cmd.Parameters.AddWithValue("@ItemCode", CL_ClientsQuotationsDetail.ItemCode);
                    cmd.Parameters.AddWithValue("@AltCode", CL_ClientsQuotationsDetail.AltCode);
                    cmd.Parameters.AddWithValue("@Quantity", CL_ClientsQuotationsDetail.Quantity);
                    cmd.Parameters.AddWithValue("@Price", CL_ClientsQuotationsDetail.Price);
                    cmd.Parameters.AddWithValue("@Value", CL_ClientsQuotationsDetail.Value);
                    cmd.Parameters.AddWithValue("@ValueddTaxP", CL_ClientsQuotationsDetail.ValueddTaxP);
                    cmd.Parameters.AddWithValue("@ValueaddTaxV", CL_ClientsQuotationsDetail.ValueaddTaxV);
                    cmd.Parameters.AddWithValue("@Dedaction", CL_ClientsQuotationsDetail.Dedaction);
                    cmd.Parameters.AddWithValue("@TimeStamp", CL_ClientsQuotationsDetail.TimeStamp);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();

                    CL_ClientsQuotationsDetail.ClientQuotationNo = (int)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", CL_ClientsQuotationsDetail.ClientQuotationNo);
                    return CL_ClientsQuotationsDetail.ClientQuotationNo;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", CL_ClientsQuotationsDetail.ClientQuotationNo, dex.Message);
                GlobalError = dex.Message;
                return -1;

            }
        }

        public async Task<int> Update()
        {

            try
            {
                await using (var conn = new SqlConnection(strConnection))
                await using (var cmd = conn.CreateCommand())
                {
                    await conn.OpenAsync();
                    cmd.CommandText = "uspCL_ClientsQuotationsDetailEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchCode", CL_ClientsQuotationsDetail.BranchCode);
                    cmd.Parameters.AddWithValue("@ClientQuotationNo", CL_ClientsQuotationsDetail.ClientQuotationNo);
                    cmd.Parameters.AddWithValue("@SerialNo", CL_ClientsQuotationsDetail.SerialNo);
                    cmd.Parameters.AddWithValue("@ClientCode", CL_ClientsQuotationsDetail.ClientCode);
                    cmd.Parameters.AddWithValue("@ItemCode", CL_ClientsQuotationsDetail.ItemCode);
                    cmd.Parameters.AddWithValue("@AltCode", CL_ClientsQuotationsDetail.AltCode);
                    cmd.Parameters.AddWithValue("@Quantity", CL_ClientsQuotationsDetail.Quantity);
                    cmd.Parameters.AddWithValue("@Price", CL_ClientsQuotationsDetail.Price);
                    cmd.Parameters.AddWithValue("@Value", CL_ClientsQuotationsDetail.Value);
                    cmd.Parameters.AddWithValue("@ValueddTaxP", CL_ClientsQuotationsDetail.ValueddTaxP);
                    cmd.Parameters.AddWithValue("@ValueaddTaxV", CL_ClientsQuotationsDetail.ValueaddTaxV);
                    cmd.Parameters.AddWithValue("@Dedaction", CL_ClientsQuotationsDetail.Dedaction);
                    cmd.Parameters.AddWithValue("@TimeStamp", CL_ClientsQuotationsDetail.TimeStamp);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", CL_ClientsQuotationsDetail.ClientQuotationNo);
                    return CL_ClientsQuotationsDetail.ClientQuotationNo;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", CL_ClientsQuotationsDetail.ClientQuotationNo, dex.Message);
                GlobalError = dex.Message;
                return -1;

            }
        }

        public async Task<bool> Delete()
        {

            try
            {
                await using (var conn = new SqlConnection(strConnection))
                await using (var cmd = conn.CreateCommand())
                {
                    await conn.OpenAsync();
                    cmd.CommandText = "uspCL_ClientsQuotationsDetailDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", CL_ClientsQuotationsDetail.ClientQuotationNo);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    await cmd.ExecuteNonQueryAsync();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {CL_ClientsQuotationsDetail.ClientQuotationNo} is Deleted Scussefully  ");
                    return true;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {CL_ClientsQuotationsDetail.ClientQuotationNo} is was not Deleted with Error {dex.Message}  ");
                GlobalError = dex.Message;
                return false;

            }
        }
        public async Task<bool> Delete(int id)
        {

            try
            {
                await using (var conn = new SqlConnection(strConnection))
                await using (var cmd = conn.CreateCommand())
                {
                    await conn.OpenAsync();
                    cmd.CommandText = "uspCL_ClientsQuotationsDetailDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);


                    await cmd.ExecuteNonQueryAsync();
                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {id} is Deleted Scussefully  ");
                    return true;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {id} is was not Deleted with Error {dex.Message}  ");
                GlobalError = dex.Message;
                return false;

            }
        }
        #endregion
    }
    #endregion
    #region Searching and listing class datalist amnd autocomplete
    public class CL_ClientsQuotationsDetailDatalist : ALookup<tblCL_ClientsQuotationsDetail>
    {



        public CL_ClientsQuotationsDetailDatalist(Boolean multi = false)
        {

            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "ClientQuotationNo";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tblCL_ClientsQuotationsDetail> GetModels()
        {
            IEnumerable<tblCL_ClientsQuotationsDetail> listing = (IEnumerable<tblCL_ClientsQuotationsDetail>)new CL_ClientsQuotationsDetailVM().GetAll(-1).ToEnumerable();
            //        int i = listing.Count();

            return listing.AsQueryable();
        }
        public override String GetColumnHeader(System.Reflection.PropertyInfo prop)
        {
            return prop.Name;
        }
    }

    #endregion
}

