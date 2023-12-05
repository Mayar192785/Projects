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
    /// class created tblCL_PaymentCondition 
    /// </summary>
    public class tblCL_PaymentCondition
    {
        #region base calss definitions
        [Display(Name = "CL_PaymentCondition-PaymentCode", Description = "CL_PaymentCondition-Payment Code.")]
        [Required(ErrorMessage = "PaymentCode is required.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 PaymentCode { get; set; }

        [Display(Name = "CL_PaymentCondition-PaymentNameA", Description = "CL_PaymentCondition-Payment Name A.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "PaymentNameA is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String PaymentNameA { get; set; }

        [Display(Name = "CL_PaymentCondition-PaymentNameE", Description = "CL_PaymentCondition-Payment Name E.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "PaymentNameE is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String PaymentNameE { get; set; }

        [Display(Name = "CL_PaymentCondition-DealWBank", Description = "CL_PaymentCondition-Deal WBank.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 DealWBank { get; set; }

        [Display(Name = "CL_PaymentCondition-AccountName", Description = "CL_PaymentCondition-Account Name.")]
        [LookupColumn(Hidden = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "AccountName is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String AccountName { get; set; }

        [Display(Name = "CL_PaymentCondition-BankName", Description = "CL_PaymentCondition-Bank Name.")]
        [LookupColumn(Hidden = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "BankName is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String BankName { get; set; }

        [Display(Name = "CL_PaymentCondition-BranchNo", Description = "CL_PaymentCondition-Branch No.")]
        [LookupColumn(Hidden = false)]
        [StringLength(10, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String BranchNo { get; set; }

        [Display(Name = "CL_PaymentCondition-AccountNo", Description = "CL_PaymentCondition-Account No.")]
        [LookupColumn(Hidden = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String AccountNo { get; set; }

        [Display(Name = "CL_PaymentCondition-SwiftCode", Description = "CL_PaymentCondition-Swift Code.")]
        [LookupColumn(Hidden = false)]
        [StringLength(10, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String SwiftCode { get; set; }

        [Display(Name = "CL_PaymentCondition-IBAN", Description = "CL_PaymentCondition-I BA N.")]
        [LookupColumn(Hidden = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String IBAN { get; set; }

        [Display(Name = "CL_PaymentCondition-Status", Description = "CL_PaymentCondition-Status.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 Status { get; set; }

        [Display(Name = "CL_PaymentCondition-TimeStamp", Description = "CL_PaymentCondition-Time Stamp.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.Date, ErrorMessage = "InvalidDate")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? TimeStamp { get; set; }
        // add full date wit hdate and time part to reading 
        public String? FullTimeStamp { get; set; }

        #region foreign key child realtions to get parent names
        #endregion
        #endregion
        #region lookupname
        public string lookupName
        {
            get
            {
                return PaymentCode.ToString();
                //        return LCNumber + "--" + SupplierIDName;
            }
            set { }
        }
        #endregion
    }
    #endregion
    #region create metModelviewa class 
    public class CL_PaymentConditionVM : BaseVM
    {
        public tblCL_PaymentCondition? CL_PaymentCondition;
        #region helper fill row
        private static tblCL_PaymentCondition ReadSingleRow(IDataRecord reader)
        {
            var dataRecord = new tblCL_PaymentCondition
            {
                PaymentCode = reader.GetValue<Int16>("PaymentCode"),
                PaymentNameA = reader.GetValue<string>("PaymentNameA"),
                PaymentNameE = reader.GetValue<string>("PaymentNameE"),
                DealWBank = reader.GetValue<Int16>("DealWBank"),
                AccountName = reader.GetValue<string>("AccountName"),
                BankName = reader.GetValue<string>("BankName"),
                BranchNo = reader.GetValue<string>("BranchNo"),
                AccountNo = reader.GetValue<string>("AccountNo"),
                SwiftCode = reader.GetValue<string>("SwiftCode"),
                IBAN = reader.GetValue<string>("IBAN"),
                Status = reader.GetValue<Int16>("Status"),
                TimeStamp = DateTime.TryParse(reader.GetValue<string>("TimeStamp"), out DateTime TimeStampdt) ? TimeStampdt : null,
                FullTimeStamp = reader.GetValue<string>("FullTimeStamp"),
                #region foreign key child realtions to get parent names
                #endregion


            };

            return dataRecord;
        }
        #endregion

        #region selection helper functions
        public SelectList GetCL_PaymentConditionForLkp()
        {
            var LookupData = GetAll()
                .ToEnumerable()
                ;
            return new SelectList(LookupData, "ID", "lookupName");
        }

        public async Task<IEnumerable<SelectListItem>> GetCL_PaymentConditionForLkpAsync()
        {
            List<SelectListItem> LookupData = await GetAll()
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.PaymentCode.ToString(),
                        Text = n.lookupName
                    }).ToListAsync();
            return LookupData;
        }
        public async IAsyncEnumerable<tblCL_PaymentCondition> GetAll()
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspCL_PaymentConditionSelect";
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
                cmd.CommandText = "SELECT IsNull(COUNT(*),1) FROM CL_PaymentCondition";
                cmd.CommandType = CommandType.Text;
                Int32 count = (int)await cmd.ExecuteScalarAsync();

                return count;


            }
        }
        public async IAsyncEnumerable<tblCL_PaymentCondition> GetPaged(int Page)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspCL_PaymentConditionPagedSelect";
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


        public tblCL_PaymentCondition GetEmpty()
        {

            return new tblCL_PaymentCondition
            {
                PaymentCode = 0,
                PaymentNameA = "",
                PaymentNameE = "",
                DealWBank = 0,
                AccountName = "",
                BankName = "",
                BranchNo = "",
                AccountNo = "",
                SwiftCode = "",
                IBAN = "",
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
            return ResultOne.PaymentNameA.ToString();
        }
        public async Task<string> GetNameByID(string id)
        {
            return await GetNameByID(int.Parse(id));
        }

        public async Task<tblCL_PaymentCondition> Find(int? id)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspCL_PaymentConditionSelectSingle";
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
                    cmd.CommandText = "uspCL_PaymentConditionEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@ID";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@PaymentNameA", CL_PaymentCondition.PaymentNameA);
                    cmd.Parameters.AddWithValue("@PaymentNameE", CL_PaymentCondition.PaymentNameE);
                    cmd.Parameters.AddWithValue("@DealWBank", CL_PaymentCondition.DealWBank);
                    cmd.Parameters.AddWithValue("@AccountName", CL_PaymentCondition.AccountName);
                    cmd.Parameters.AddWithValue("@BankName", CL_PaymentCondition.BankName);
                    cmd.Parameters.AddWithValue("@BranchNo", CL_PaymentCondition.BranchNo);
                    cmd.Parameters.AddWithValue("@AccountNo", CL_PaymentCondition.AccountNo);
                    cmd.Parameters.AddWithValue("@SwiftCode", CL_PaymentCondition.SwiftCode);
                    cmd.Parameters.AddWithValue("@IBAN", CL_PaymentCondition.IBAN);
                    cmd.Parameters.AddWithValue("@Status", CL_PaymentCondition.Status);
                    cmd.Parameters.AddWithValue("@TimeStamp", CL_PaymentCondition.TimeStamp);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();

                    CL_PaymentCondition.PaymentCode = (short)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", CL_PaymentCondition.PaymentCode);
                    return CL_PaymentCondition.PaymentCode;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", CL_PaymentCondition.PaymentNameA, dex.Message);
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
                    cmd.CommandText = "uspCL_PaymentConditionEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PaymentCode", CL_PaymentCondition.PaymentCode);
                    cmd.Parameters.AddWithValue("@PaymentNameA", CL_PaymentCondition.PaymentNameA);
                    cmd.Parameters.AddWithValue("@PaymentNameE", CL_PaymentCondition.PaymentNameE);
                    cmd.Parameters.AddWithValue("@DealWBank", CL_PaymentCondition.DealWBank);
                    cmd.Parameters.AddWithValue("@AccountName", CL_PaymentCondition.AccountName);
                    cmd.Parameters.AddWithValue("@BankName", CL_PaymentCondition.BankName);
                    cmd.Parameters.AddWithValue("@BranchNo", CL_PaymentCondition.BranchNo);
                    cmd.Parameters.AddWithValue("@AccountNo", CL_PaymentCondition.AccountNo);
                    cmd.Parameters.AddWithValue("@SwiftCode", CL_PaymentCondition.SwiftCode);
                    cmd.Parameters.AddWithValue("@IBAN", CL_PaymentCondition.IBAN);
                    cmd.Parameters.AddWithValue("@Status", CL_PaymentCondition.Status);
                    cmd.Parameters.AddWithValue("@TimeStamp", CL_PaymentCondition.TimeStamp);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", CL_PaymentCondition.PaymentCode);
                    return CL_PaymentCondition.PaymentCode;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", CL_PaymentCondition.PaymentNameA, dex.Message);
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
                    cmd.CommandText = "uspCL_PaymentConditionDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", CL_PaymentCondition.PaymentCode);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    await cmd.ExecuteNonQueryAsync();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {CL_PaymentCondition.PaymentCode} is Deleted Scussefully  ");
                    return true;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {CL_PaymentCondition.PaymentCode} is was not Deleted with Error {dex.Message}  ");
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
                    cmd.CommandText = "uspCL_PaymentConditionDelete";
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
    public class CL_PaymentConditionDatalist : ALookup<tblCL_PaymentCondition>
    {



        public CL_PaymentConditionDatalist(Boolean multi = false)
        {

            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "PaymentNameA";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tblCL_PaymentCondition> GetModels()
        {
            IEnumerable<tblCL_PaymentCondition> listing = (IEnumerable<tblCL_PaymentCondition>)new CL_PaymentConditionVM().GetAll().ToEnumerable();
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

