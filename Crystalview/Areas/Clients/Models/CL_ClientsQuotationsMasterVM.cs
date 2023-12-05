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
    /// class created tblCL_ClientsQuotationsMaster 
    /// </summary>
    public class tblCL_ClientsQuotationsMaster
    {
        #region base calss definitions
        // prepare lookup data for the dynamic form part
        public SelectList lsBranchCode => new GE_BranchsVM().GetGE_BranchsForLkp();
        [ItemsSource(ItemsProperty = nameof(lsBranchCode), ChoicesType = ChoicesTypes.DEFAULT)]
        [Display(Name = "CL_ClientsQuotationsMaster-BranchCode", Description = "CL_ClientsQuotationsMaster-Branch Code.")]
        [Required(ErrorMessage = "BranchCode is required.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 BranchCode { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-ClientQuotationNo", Description = "CL_ClientsQuotationsMaster-Client Quotation No.")]
        [Required(ErrorMessage = "ClientQuotationNo is required.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ClientQuotationNo { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-RefQuotationNo", Description = "CL_ClientsQuotationsMaster-Ref Quotation No.")]
        [LookupColumn(Hidden = false)]
        [StringLength(24, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String RefQuotationNo { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-SalesRepName", Description = "CL_ClientsQuotationsMaster-Sales Rep Name.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "SalesRepName is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String SalesRepName { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-OrderDate", Description = "CL_ClientsQuotationsMaster-Order Date.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.Date, ErrorMessage = "InvalidDate")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? OrderDate { get; set; }
        // add full date wit hdate and time part to reading 
        public String? FullOrderDate { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-JobName", Description = "CL_ClientsQuotationsMaster-Job Name.")]
        [LookupColumn(Hidden = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "JobName is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String JobName { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-CityCountry", Description = "CL_ClientsQuotationsMaster-City Country.")]
        [LookupColumn(Hidden = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String CityCountry { get; set; }

        // prepare lookup data for the dynamic form part
        public SelectList lsClientCode => new CL_ClientsDefinitionVM().GetCL_ClientsDefinitionForLkp();
        [ItemsSource(ItemsProperty = nameof(lsClientCode), ChoicesType = ChoicesTypes.DEFAULT)]
        [Display(Name = "CL_ClientsQuotationsMaster-ClientCode", Description = "CL_ClientsQuotationsMaster-Client Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ClientCode { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-NewClientName", Description = "CL_ClientsQuotationsMaster-New Client Name.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "NewClientName is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String NewClientName { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-ResponsMan", Description = "CL_ClientsQuotationsMaster-Respons Man.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String ResponsMan { get; set; }

        // prepare lookup data for the dynamic form part
        public SelectList lsPaymentCode => new CL_PaymentConditionVM().GetCL_PaymentConditionForLkp();
        [ItemsSource(ItemsProperty = nameof(lsPaymentCode), ChoicesType = ChoicesTypes.DEFAULT)]
        [Display(Name = "CL_ClientsQuotationsMaster-PaymentCode", Description = "CL_ClientsQuotationsMaster-Payment Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 PaymentCode { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-TransportCode", Description = "CL_ClientsQuotationsMaster-Transport Code.")]
        [LookupColumn(Hidden = false)]
        [StringLength(1, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String TransportCode { get; set; }

        // prepare lookup data for the dynamic form part
        public SelectList lsCurrencyCode => new GE_CurrenciesVM().GetGE_CurrenciesForLkp();
        [ItemsSource(ItemsProperty = nameof(lsCurrencyCode), ChoicesType = ChoicesTypes.DEFAULT)]
        [Display(Name = "CL_ClientsQuotationsMaster-CurrencyCode", Description = "CL_ClientsQuotationsMaster-Currency Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 CurrencyCode { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-Memo", Description = "CL_ClientsQuotationsMaster-Memo.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String Memo { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-ValidityNo1", Description = "CL_ClientsQuotationsMaster-Validity No1.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String ValidityNo1 { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-ValidityNo2", Description = "CL_ClientsQuotationsMaster-Validity No2.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String ValidityNo2 { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-PaymentNo1", Description = "CL_ClientsQuotationsMaster-Payment No1.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String PaymentNo1 { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-PaymentNo2", Description = "CL_ClientsQuotationsMaster-Payment No2.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String PaymentNo2 { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-StarageArea", Description = "CL_ClientsQuotationsMaster-Starage Area.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String StarageArea { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-Delivery", Description = "CL_ClientsQuotationsMaster-Delivery.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String Delivery { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-Prices", Description = "CL_ClientsQuotationsMaster-Prices.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String Prices { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-QuotationStatus", Description = "CL_ClientsQuotationsMaster-Quotation Status.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 QuotationStatus { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-TotalQuotation", Description = "CL_ClientsQuotationsMaster-Total Quotation.")]
        [Required(ErrorMessage = "TotalQuotation is required.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal TotalQuotation { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-Status", Description = "CL_ClientsQuotationsMaster-Status.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 Status { get; set; }

        [Display(Name = "CL_ClientsQuotationsMaster-TimeStamp", Description = "CL_ClientsQuotationsMaster-Time Stamp.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.Date, ErrorMessage = "InvalidDate")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? TimeStamp { get; set; }
        // add full date wit hdate and time part to reading 
        public String? FullTimeStamp { get; set; }


        #region extra master details part to be used 
        public Boolean? ShowGrid { get; set; }
        public List<tblCL_ClientsQuotationsDetail>? CL_ClientsQuotationsDetailDetails { get; set; }
        #endregion
        #region foreign key child realtions to get parent names
        [Display(Name = "CL_ClientsQuotationsMaster-ClientCode", Description = "CL_ClientsQuotationsMaster-Client Code.")]
        [LookupColumn(Hidden = false)]
        public string? ClientCodeName { get; set; }
        [Display(Name = "CL_ClientsQuotationsMaster-PaymentCode", Description = "CL_ClientsQuotationsMaster-Payment Code.")]
        [LookupColumn(Hidden = false)]
        public string? PaymentCodeName { get; set; }
        [Display(Name = "CL_ClientsQuotationsMaster-BranchCode", Description = "CL_ClientsQuotationsMaster-Branch Code.")]
        [LookupColumn(Hidden = false)]
        public string? BranchCodeName { get; set; }
        [Display(Name = "CL_ClientsQuotationsMaster-CurrencyCode", Description = "CL_ClientsQuotationsMaster-Currency Code.")]
        [LookupColumn(Hidden = false)]
        public string? CurrencyCodeName { get; set; }
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
    public class CL_ClientsQuotationsMasterVM : BaseVM
    {
        public tblCL_ClientsQuotationsMaster? CL_ClientsQuotationsMaster;
        #region helper fill row
        private static tblCL_ClientsQuotationsMaster ReadSingleRow(IDataRecord reader)
        {
            var dataRecord = new tblCL_ClientsQuotationsMaster
            {
                BranchCode = reader.GetValue<Int16>("BranchCode"),
                ClientQuotationNo = reader.GetValue<Int32>("ClientQuotationNo"),
                RefQuotationNo = reader.GetValue<string>("RefQuotationNo"),
                SalesRepName = reader.GetValue<string>("SalesRepName"),
                OrderDate = DateTime.TryParse(reader.GetValue<string>("OrderDate"), out DateTime OrderDatedt) ? OrderDatedt : null,
                FullOrderDate = reader.GetValue<string>("FullOrderDate"),
                JobName = reader.GetValue<string>("JobName"),
                CityCountry = reader.GetValue<string>("CityCountry"),
                ClientCode = reader.GetValue<Int32>("ClientCode"),
                NewClientName = reader.GetValue<string>("NewClientName"),
                ResponsMan = reader.GetValue<string>("ResponsMan"),
                PaymentCode = reader.GetValue<Int16>("PaymentCode"),
                TransportCode = reader.GetValue<string>("TransportCode"),
                CurrencyCode = reader.GetValue<Int16>("CurrencyCode"),
                Memo = reader.GetValue<string>("Memo"),
                ValidityNo1 = reader.GetValue<string>("ValidityNo1"),
                ValidityNo2 = reader.GetValue<string>("ValidityNo2"),
                PaymentNo1 = reader.GetValue<string>("PaymentNo1"),
                PaymentNo2 = reader.GetValue<string>("PaymentNo2"),
                StarageArea = reader.GetValue<string>("StarageArea"),
                Delivery = reader.GetValue<string>("Delivery"),
                Prices = reader.GetValue<string>("Prices"),
                QuotationStatus = reader.GetValue<Int16>("QuotationStatus"),
                TotalQuotation = reader.GetValue<decimal>("TotalQuotation"),
                Status = reader.GetValue<Int16>("Status"),
                TimeStamp = DateTime.TryParse(reader.GetValue<string>("TimeStamp"), out DateTime TimeStampdt) ? TimeStampdt : null,
                FullTimeStamp = reader.GetValue<string>("FullTimeStamp"),
                #region foreign key child realtions to get parent names
                ClientCodeName = reader.GetValue<string>("ClientCodeName"),
                PaymentCodeName = reader.GetValue<string>("PaymentCodeName"),
                BranchCodeName = reader.GetValue<string>("BranchCodeName"),
                CurrencyCodeName = reader.GetValue<string>("CurrencyCodeName"),
                #endregion


            };

            return dataRecord;
        }
        #endregion

        #region selection helper functions
        public SelectList GetCL_ClientsQuotationsMasterForLkp()
        {
            var LookupData = GetAll()
                .ToEnumerable()
                ;
            return new SelectList(LookupData, "ID", "lookupName");
        }

        public async Task<IEnumerable<SelectListItem>> GetCL_ClientsQuotationsMasterForLkpAsync()
        {
            List<SelectListItem> LookupData = await GetAll()
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.ClientQuotationNo.ToString(),
                        Text = n.lookupName
                    }).ToListAsync();
            return LookupData;
        }
        public async IAsyncEnumerable<tblCL_ClientsQuotationsMaster> GetAll()
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspCL_ClientsQuotationsMasterSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
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
                cmd.CommandText = "SELECT IsNull(COUNT(*),1) FROM CL_ClientsQuotationsMaster";
                cmd.CommandType = CommandType.Text;
                Int32 count = (int)await cmd.ExecuteScalarAsync();

                return count;


            }
        }
        public async IAsyncEnumerable<tblCL_ClientsQuotationsMaster> GetPaged(int Page)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspCL_ClientsQuotationsMasterPagedSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@Page", Page);
                cmd.Parameters.AddWithValue("@RecsPerPage", 20);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        yield return ReadSingleRow((IDataRecord)reader);
                    }
                }
            }
        }


        public tblCL_ClientsQuotationsMaster GetEmpty()
        {

            return new tblCL_ClientsQuotationsMaster
            {
                BranchCode = 0,
                ClientQuotationNo = 0,
                RefQuotationNo = "",
                SalesRepName = "",
                OrderDate = DateTime.Today,
                JobName = "",
                CityCountry = "",
                ClientCode = 0,
                NewClientName = "",
                ResponsMan = "",
                PaymentCode = 0,
                TransportCode = "",
                CurrencyCode = 0,
                Memo = "",
                ValidityNo1 = "",
                ValidityNo2 = "",
                PaymentNo1 = "",
                PaymentNo2 = "",
                StarageArea = "",
                Delivery = "",
                Prices = "",
                QuotationStatus = 0,
                TotalQuotation = 0,
                Status = 0,
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

        public async Task<tblCL_ClientsQuotationsMaster> Find(int? id)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspCL_ClientsQuotationsMasterSelectSingle";
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
                    cmd.CommandText = "uspCL_ClientsQuotationsMasterEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@ID";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@ClientQuotationNo", CL_ClientsQuotationsMaster.ClientQuotationNo);
                    cmd.Parameters.AddWithValue("@RefQuotationNo", CL_ClientsQuotationsMaster.RefQuotationNo);
                    cmd.Parameters.AddWithValue("@SalesRepName", CL_ClientsQuotationsMaster.SalesRepName);
                    cmd.Parameters.AddWithValue("@OrderDate", CL_ClientsQuotationsMaster.OrderDate);
                    cmd.Parameters.AddWithValue("@JobName", CL_ClientsQuotationsMaster.JobName);
                    cmd.Parameters.AddWithValue("@CityCountry", CL_ClientsQuotationsMaster.CityCountry);
                    cmd.Parameters.AddWithValue("@ClientCode", CL_ClientsQuotationsMaster.ClientCode);
                    cmd.Parameters.AddWithValue("@NewClientName", CL_ClientsQuotationsMaster.NewClientName);
                    cmd.Parameters.AddWithValue("@ResponsMan", CL_ClientsQuotationsMaster.ResponsMan);
                    cmd.Parameters.AddWithValue("@PaymentCode", CL_ClientsQuotationsMaster.PaymentCode);
                    cmd.Parameters.AddWithValue("@TransportCode", CL_ClientsQuotationsMaster.TransportCode);
                    cmd.Parameters.AddWithValue("@CurrencyCode", CL_ClientsQuotationsMaster.CurrencyCode);
                    cmd.Parameters.AddWithValue("@Memo", CL_ClientsQuotationsMaster.Memo);
                    cmd.Parameters.AddWithValue("@ValidityNo1", CL_ClientsQuotationsMaster.ValidityNo1);
                    cmd.Parameters.AddWithValue("@ValidityNo2", CL_ClientsQuotationsMaster.ValidityNo2);
                    cmd.Parameters.AddWithValue("@PaymentNo1", CL_ClientsQuotationsMaster.PaymentNo1);
                    cmd.Parameters.AddWithValue("@PaymentNo2", CL_ClientsQuotationsMaster.PaymentNo2);
                    cmd.Parameters.AddWithValue("@StarageArea", CL_ClientsQuotationsMaster.StarageArea);
                    cmd.Parameters.AddWithValue("@Delivery", CL_ClientsQuotationsMaster.Delivery);
                    cmd.Parameters.AddWithValue("@Prices", CL_ClientsQuotationsMaster.Prices);
                    cmd.Parameters.AddWithValue("@QuotationStatus", CL_ClientsQuotationsMaster.QuotationStatus);
                    cmd.Parameters.AddWithValue("@TotalQuotation", CL_ClientsQuotationsMaster.TotalQuotation);
                    cmd.Parameters.AddWithValue("@Status", CL_ClientsQuotationsMaster.Status);
                    cmd.Parameters.AddWithValue("@TimeStamp", CL_ClientsQuotationsMaster.TimeStamp);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();

                    CL_ClientsQuotationsMaster.ClientQuotationNo = (int)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", CL_ClientsQuotationsMaster.ClientQuotationNo);
                    return CL_ClientsQuotationsMaster.ClientQuotationNo;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", CL_ClientsQuotationsMaster.ClientQuotationNo, dex.Message);
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
                    cmd.CommandText = "uspCL_ClientsQuotationsMasterEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchCode", CL_ClientsQuotationsMaster.BranchCode);
                    cmd.Parameters.AddWithValue("@ClientQuotationNo", CL_ClientsQuotationsMaster.ClientQuotationNo);
                    cmd.Parameters.AddWithValue("@RefQuotationNo", CL_ClientsQuotationsMaster.RefQuotationNo);
                    cmd.Parameters.AddWithValue("@SalesRepName", CL_ClientsQuotationsMaster.SalesRepName);
                    cmd.Parameters.AddWithValue("@OrderDate", CL_ClientsQuotationsMaster.OrderDate);
                    cmd.Parameters.AddWithValue("@JobName", CL_ClientsQuotationsMaster.JobName);
                    cmd.Parameters.AddWithValue("@CityCountry", CL_ClientsQuotationsMaster.CityCountry);
                    cmd.Parameters.AddWithValue("@ClientCode", CL_ClientsQuotationsMaster.ClientCode);
                    cmd.Parameters.AddWithValue("@NewClientName", CL_ClientsQuotationsMaster.NewClientName);
                    cmd.Parameters.AddWithValue("@ResponsMan", CL_ClientsQuotationsMaster.ResponsMan);
                    cmd.Parameters.AddWithValue("@PaymentCode", CL_ClientsQuotationsMaster.PaymentCode);
                    cmd.Parameters.AddWithValue("@TransportCode", CL_ClientsQuotationsMaster.TransportCode);
                    cmd.Parameters.AddWithValue("@CurrencyCode", CL_ClientsQuotationsMaster.CurrencyCode);
                    cmd.Parameters.AddWithValue("@Memo", CL_ClientsQuotationsMaster.Memo);
                    cmd.Parameters.AddWithValue("@ValidityNo1", CL_ClientsQuotationsMaster.ValidityNo1);
                    cmd.Parameters.AddWithValue("@ValidityNo2", CL_ClientsQuotationsMaster.ValidityNo2);
                    cmd.Parameters.AddWithValue("@PaymentNo1", CL_ClientsQuotationsMaster.PaymentNo1);
                    cmd.Parameters.AddWithValue("@PaymentNo2", CL_ClientsQuotationsMaster.PaymentNo2);
                    cmd.Parameters.AddWithValue("@StarageArea", CL_ClientsQuotationsMaster.StarageArea);
                    cmd.Parameters.AddWithValue("@Delivery", CL_ClientsQuotationsMaster.Delivery);
                    cmd.Parameters.AddWithValue("@Prices", CL_ClientsQuotationsMaster.Prices);
                    cmd.Parameters.AddWithValue("@QuotationStatus", CL_ClientsQuotationsMaster.QuotationStatus);
                    cmd.Parameters.AddWithValue("@TotalQuotation", CL_ClientsQuotationsMaster.TotalQuotation);
                    cmd.Parameters.AddWithValue("@Status", CL_ClientsQuotationsMaster.Status);
                    cmd.Parameters.AddWithValue("@TimeStamp", CL_ClientsQuotationsMaster.TimeStamp);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", CL_ClientsQuotationsMaster.ClientQuotationNo);
                    return CL_ClientsQuotationsMaster.ClientQuotationNo;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", CL_ClientsQuotationsMaster.ClientQuotationNo, dex.Message);
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
                    cmd.CommandText = "uspCL_ClientsQuotationsMasterDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", CL_ClientsQuotationsMaster.ClientQuotationNo);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    await cmd.ExecuteNonQueryAsync();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {CL_ClientsQuotationsMaster.ClientQuotationNo} is Deleted Scussefully  ");
                    return true;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {CL_ClientsQuotationsMaster.ClientQuotationNo} is was not Deleted with Error {dex.Message}  ");
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
                    cmd.CommandText = "uspCL_ClientsQuotationsMasterDelete";
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
    public class CL_ClientsQuotationsMasterDatalist : ALookup<tblCL_ClientsQuotationsMaster>
    {



        public CL_ClientsQuotationsMasterDatalist(Boolean multi = false)
        {

            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "ClientQuotationNo";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tblCL_ClientsQuotationsMaster> GetModels()
        {
            IEnumerable<tblCL_ClientsQuotationsMaster> listing = (IEnumerable<tblCL_ClientsQuotationsMaster>)new CL_ClientsQuotationsMasterVM().GetAll().ToEnumerable();
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

