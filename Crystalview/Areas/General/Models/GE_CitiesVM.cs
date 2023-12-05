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
    /// class created tblGE_Cities 
    /// </summary>
    public class tblGE_Cities
    {
        #region base calss definitions
        [Display(Name = "GE_Cities-CountryCode", Description = "GE_Cities-Country Code.")]
        [Required(ErrorMessage = "CountryCode is required.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 CountryCode { get; set; }

        [Display(Name = "GE_Cities-CityCode", Description = "GE_Cities-City Code.")]
        [Required(ErrorMessage = "CityCode is required.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 CityCode { get; set; }

        [Display(Name = "GE_Cities-CityNameA", Description = "GE_Cities-City Name A.")]
        [LookupColumn(Hidden = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "CityNameA is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String CityNameA { get; set; }

        [Display(Name = "GE_Cities-CityNameE", Description = "GE_Cities-City Name E.")]
        [LookupColumn(Hidden = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "CityNameE is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String CityNameE { get; set; }

        #region foreign key child realtions to get parent names
        #endregion
        #endregion
        #region lookupname
        public string lookupName
        {
            get
            {
                return CityCode.ToString();
                //        return LCNumber + "--" + SupplierIDName;
            }
            set { }
        }
        #endregion
    }
    #endregion
    #region create metModelviewa class 
    public class GE_CitiesVM : BaseVM
    {
        public tblGE_Cities? GE_Cities;
        #region helper fill row
        private static tblGE_Cities ReadSingleRow(IDataRecord reader)
        {
            var dataRecord = new tblGE_Cities
            {
                CountryCode = reader.GetValue<Int16>("CountryCode"),
                CityCode = reader.GetValue<Int16>("CityCode"),
                CityNameA = reader.GetValue<string>("CityNameA"),
                CityNameE = reader.GetValue<string>("CityNameE"),
                #region foreign key child realtions to get parent names
                #endregion


            };

            return dataRecord;
        }
        #endregion

        #region selection helper functions
        public SelectList GetGE_CitiesForLkp(int CityCode)
        {
            var LookupData = GetAll(CityCode)
                .ToEnumerable()
                ;
            return new SelectList(LookupData, "ID", "lookupName");
        }

        public async Task<IEnumerable<SelectListItem>> GetGE_CitiesForLkpAsync(int CityCode)
        {
            List<SelectListItem> LookupData = await GetAll(CityCode)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.CityCode.ToString(),
                        Text = n.lookupName
                    }).ToListAsync();
            return LookupData;
        }
        public async IAsyncEnumerable<tblGE_Cities> GetAll(int CityCode)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspGE_CitiesSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@CityCode", CityCode);
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
                cmd.CommandText = "SELECT IsNull(COUNT(*),1) FROM GE_Cities";
                cmd.CommandType = CommandType.Text;
                Int32 count = (int)await cmd.ExecuteScalarAsync();

                return count;


            }
        }
        public async IAsyncEnumerable<tblGE_Cities> GetPaged(int Page, int CityCode)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspGE_CitiesPagedSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@Page", Page);
                cmd.Parameters.AddWithValue("@RecsPerPage", 20);
                cmd.Parameters.AddWithValue("@CityCode", CityCode);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        yield return ReadSingleRow((IDataRecord)reader);
                    }
                }
            }
        }


        public tblGE_Cities GetEmpty()
        {

            return new tblGE_Cities
            {
                CountryCode = 0,
                CityCode = 0,
                CityNameA = "",
                CityNameE = "",
            };
        }
        public async Task<string> GetNameByID(int? id)
        {

            var ResultOne = await Find(id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.CityCode.ToString();
        }
        public async Task<string> GetNameByID(string id)
        {
            return await GetNameByID(int.Parse(id));
        }

        public async Task<tblGE_Cities> Find(int? id)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspGE_CitiesSelectSingle";
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
                    cmd.CommandText = "uspGE_CitiesEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@CountryCode";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@CityCode", GE_Cities.CityCode);
                    cmd.Parameters.AddWithValue("@CityNameA", GE_Cities.CityNameA);
                    cmd.Parameters.AddWithValue("@CityNameE", GE_Cities.CityNameE);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();

                    GE_Cities.CityCode = (short)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", GE_Cities.CityCode);
                    return GE_Cities.CityCode;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", GE_Cities.CityCode, dex.Message);
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
                    cmd.CommandText = "uspGE_CitiesEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CountryCode", GE_Cities.CountryCode);
                    cmd.Parameters.AddWithValue("@CityCode", GE_Cities.CityCode);
                    cmd.Parameters.AddWithValue("@CityNameA", GE_Cities.CityNameA);
                    cmd.Parameters.AddWithValue("@CityNameE", GE_Cities.CityNameE);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", GE_Cities.CityCode);
                    return GE_Cities.CityCode;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", GE_Cities.CityCode, dex.Message);
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
                    cmd.CommandText = "uspGE_CitiesDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", GE_Cities.CityCode);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    await cmd.ExecuteNonQueryAsync();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {GE_Cities.CityCode} is Deleted Scussefully  ");
                    return true;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {GE_Cities.CityCode} is was not Deleted with Error {dex.Message}  ");
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
                    cmd.CommandText = "uspGE_CitiesDelete";
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
    public class GE_CitiesDatalist : ALookup<tblGE_Cities>
    {



        public GE_CitiesDatalist(Boolean multi = false)
        {

            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "CityCode";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tblGE_Cities> GetModels()
        {
            IEnumerable<tblGE_Cities> listing = (IEnumerable<tblGE_Cities>)new GE_CitiesVM().GetAll(-1).ToEnumerable();
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

