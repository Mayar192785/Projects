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
    /// class created tblGE_Currencies 
    /// </summary>
    public class tblGE_Currencies
    {
        #region base calss definitions
        [Display(Name = "GE_Currencies-CurrencyCode", Description = "GE_Currencies-Currency Code.")]
        [Required(ErrorMessage = "CurrencyCode is required.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 CurrencyCode { get; set; }

        [Display(Name = "GE_Currencies-CurrencyNameA", Description = "GE_Currencies-Currency Name A.")]
        [Required(ErrorMessage = "CurrencyNameA is required.")]
        [LookupColumn(Hidden = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String CurrencyNameA { get; set; }

        [Display(Name = "GE_Currencies-CurrencyNameE", Description = "GE_Currencies-Currency Name E.")]
        [LookupColumn(Hidden = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "CurrencyNameE is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String CurrencyNameE { get; set; }

        [Display(Name = "GE_Currencies-Abbreviation", Description = "GE_Currencies-Abbreviation.")]
        [LookupColumn(Hidden = false)]
        [StringLength(5, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String Abbreviation { get; set; }

        [Display(Name = "GE_Currencies-ExctangeRate", Description = "GE_Currencies-Exctange Rate.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal ExctangeRate { get; set; }

        #region foreign key child realtions to get parent names
        #endregion
        #endregion
        #region lookupname
        public string lookupName
        {
            get
            {
                return CurrencyCode.ToString();
                //        return LCNumber + "--" + SupplierIDName;
            }
            set { }
        }
        #endregion
    }
    #endregion
    #region create metModelviewa class 
    public class GE_CurrenciesVM : BaseVM
    {
        public tblGE_Currencies? GE_Currencies;
        #region helper fill row
        private static tblGE_Currencies ReadSingleRow(IDataRecord reader)
        {
            var dataRecord = new tblGE_Currencies
            {
                CurrencyCode = reader.GetValue<Int16>("CurrencyCode"),
                CurrencyNameA = reader.GetValue<string>("CurrencyNameA"),
                CurrencyNameE = reader.GetValue<string>("CurrencyNameE"),
                Abbreviation = reader.GetValue<string>("Abbreviation"),
                ExctangeRate = reader.GetValue<decimal>("ExctangeRate"),
                #region foreign key child realtions to get parent names
                #endregion


            };

            return dataRecord;
        }
        #endregion

        #region selection helper functions
        public SelectList GetGE_CurrenciesForLkp()
        {
            var LookupData = GetAll()
                .ToEnumerable()
                ;
            return new SelectList(LookupData, "ID", "lookupName");
        }

        public async Task<IEnumerable<SelectListItem>> GetGE_CurrenciesForLkpAsync()
        {
            List<SelectListItem> LookupData = await GetAll()
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.CurrencyCode.ToString(),
                        Text = n.lookupName
                    }).ToListAsync();
            return LookupData;
        }
        public async IAsyncEnumerable<tblGE_Currencies> GetAll()
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspGE_CurrenciesSelect";
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
                cmd.CommandText = "SELECT IsNull(COUNT(*),1) FROM GE_Currencies";
                cmd.CommandType = CommandType.Text;
                Int32 count = (int)await cmd.ExecuteScalarAsync();

                return count;


            }
        }
        public async IAsyncEnumerable<tblGE_Currencies> GetPaged(int Page)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspGE_CurrenciesPagedSelect";
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


        public tblGE_Currencies GetEmpty()
        {

            return new tblGE_Currencies
            {
                CurrencyCode = 0,
                CurrencyNameA = "",
                CurrencyNameE = "",
                Abbreviation = "",
                ExctangeRate = 0,
            };
        }
        public async Task<string> GetNameByID(int? id)
        {

            var ResultOne = await Find(id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.CurrencyNameA.ToString();
        }
        public async Task<string> GetNameByID(string id)
        {
            return await GetNameByID(int.Parse(id));
        }

        public async Task<tblGE_Currencies> Find(int? id)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspGE_CurrenciesSelectSingle";
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
                    cmd.CommandText = "uspGE_CurrenciesEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@CurrencyCode";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@CurrencyNameA", GE_Currencies.CurrencyNameA);
                    cmd.Parameters.AddWithValue("@CurrencyNameE", GE_Currencies.CurrencyNameE);
                    cmd.Parameters.AddWithValue("@Abbreviation", GE_Currencies.Abbreviation);
                    cmd.Parameters.AddWithValue("@ExctangeRate", GE_Currencies.ExctangeRate);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();

                    GE_Currencies.CurrencyCode = (short)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", GE_Currencies.CurrencyCode);
                    return GE_Currencies.CurrencyCode;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", GE_Currencies.CurrencyNameA, dex.Message);
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
                    cmd.CommandText = "uspGE_CurrenciesEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CurrencyCode", GE_Currencies.CurrencyCode);
                    cmd.Parameters.AddWithValue("@CurrencyNameA", GE_Currencies.CurrencyNameA);
                    cmd.Parameters.AddWithValue("@CurrencyNameE", GE_Currencies.CurrencyNameE);
                    cmd.Parameters.AddWithValue("@Abbreviation", GE_Currencies.Abbreviation);
                    cmd.Parameters.AddWithValue("@ExctangeRate", GE_Currencies.ExctangeRate);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", GE_Currencies.CurrencyCode);
                    return GE_Currencies.CurrencyCode;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", GE_Currencies.CurrencyNameA, dex.Message);
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
                    cmd.CommandText = "uspGE_CurrenciesDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", GE_Currencies.CurrencyCode);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    await cmd.ExecuteNonQueryAsync();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {GE_Currencies.CurrencyCode} is Deleted Scussefully  ");
                    return true;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {GE_Currencies.CurrencyCode} is was not Deleted with Error {dex.Message}  ");
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
                    cmd.CommandText = "uspGE_CurrenciesDelete";
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
    public class GE_CurrenciesDatalist : ALookup<tblGE_Currencies>
    {



        public GE_CurrenciesDatalist(Boolean multi = false)
        {

            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "CurrencyNameA";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tblGE_Currencies> GetModels()
        {
            IEnumerable<tblGE_Currencies> listing = (IEnumerable<tblGE_Currencies>)new GE_CurrenciesVM().GetAll().ToEnumerable();
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

