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
    /// class created tblGE_Branchs 
    /// </summary>
    public class tblGE_Branchs
    {
        #region base calss definitions
        [Display(Name = "GE_Branchs-BranchCode", Description = "GE_Branchs-Branch Code.")]
        [Required(ErrorMessage = "BranchCode is required.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 BranchCode { get; set; }

        [Display(Name = "GE_Branchs-BranchNameA", Description = "GE_Branchs-Branch Name A.")]
        [Required(ErrorMessage = "BranchNameA is required.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String BranchNameA { get; set; }

        [Display(Name = "GE_Branchs-BranchNameE", Description = "GE_Branchs-Branch Name E.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "BranchNameE is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String BranchNameE { get; set; }

        [Display(Name = "GE_Branchs-CountryCode", Description = "GE_Branchs-Country Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 CountryCode { get; set; }

        [Display(Name = "GE_Branchs-CityCode", Description = "GE_Branchs-City Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 CityCode { get; set; }

        [Display(Name = "GE_Branchs-AddressA", Description = "GE_Branchs-Address A.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String AddressA { get; set; }

        [Display(Name = "GE_Branchs-AddressE", Description = "GE_Branchs-Address E.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String AddressE { get; set; }

        [Display(Name = "GE_Branchs-Tel1", Description = "GE_Branchs-Tel1.")]
        [LookupColumn(Hidden = false)]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String Tel1 { get; set; }

        [Display(Name = "GE_Branchs-Tel2", Description = "GE_Branchs-Tel2.")]
        [LookupColumn(Hidden = false)]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String Tel2 { get; set; }

        [Display(Name = "GE_Branchs-Tel3", Description = "GE_Branchs-Tel3.")]
        [LookupColumn(Hidden = false)]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String Tel3 { get; set; }

        [Display(Name = "GE_Branchs-Fax", Description = "GE_Branchs-Fax.")]
        [LookupColumn(Hidden = false)]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "InvalidPhone")]
        public String Fax { get; set; }

        #region foreign key child realtions to get parent names
        #endregion
        #endregion
        #region lookupname
        public string lookupName
        {
            get
            {
                return BranchCode.ToString();
                //        return LCNumber + "--" + SupplierIDName;
            }
            set { }
        }
        #endregion
    }
    #endregion
    #region create metModelviewa class 
    public class GE_BranchsVM : BaseVM
    {
        public tblGE_Branchs? GE_Branchs;
        #region helper fill row
        private static tblGE_Branchs ReadSingleRow(IDataRecord reader)
        {
            var dataRecord = new tblGE_Branchs
            {
                BranchCode = reader.GetValue<Int16>("BranchCode"),
                BranchNameA = reader.GetValue<string>("BranchNameA"),
                BranchNameE = reader.GetValue<string>("BranchNameE"),
                CountryCode = reader.GetValue<Int16>("CountryCode"),
                CityCode = reader.GetValue<Int32>("CityCode"),
                AddressA = reader.GetValue<string>("AddressA"),
                AddressE = reader.GetValue<string>("AddressE"),
                Tel1 = reader.GetValue<string>("Tel1"),
                Tel2 = reader.GetValue<string>("Tel2"),
                Tel3 = reader.GetValue<string>("Tel3"),
                Fax = reader.GetValue<string>("Fax"),
                #region foreign key child realtions to get parent names
                #endregion


            };

            return dataRecord;
        }
        #endregion

        #region selection helper functions
        public SelectList GetGE_BranchsForLkp()
        {
            var LookupData = GetAll()
                .ToEnumerable()
                ;
            return new SelectList(LookupData, "ID", "lookupName");
        }

        public async Task<IEnumerable<SelectListItem>> GetGE_BranchsForLkpAsync()
        {
            List<SelectListItem> LookupData = await GetAll()
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.BranchCode.ToString(),
                        Text = n.lookupName
                    }).ToListAsync();
            return LookupData;
        }
        public async IAsyncEnumerable<tblGE_Branchs> GetAll()
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspGE_BranchsSelect";
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
                cmd.CommandText = "SELECT IsNull(COUNT(*),1) FROM GE_Branchs";
                cmd.CommandType = CommandType.Text;
                Int32 count = (int)await cmd.ExecuteScalarAsync();

                return count;


            }
        }
        public async IAsyncEnumerable<tblGE_Branchs> GetPaged(int Page)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspGE_BranchsPagedSelect";
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


        public tblGE_Branchs GetEmpty()
        {

            return new tblGE_Branchs
            {
                BranchCode = 0,
                BranchNameA = "",
                BranchNameE = "",
                CountryCode = 0,
                CityCode = 0,
                AddressA = "",
                AddressE = "",
                Tel1 = "",
                Tel2 = "",
                Tel3 = "",
                Fax = "",
            };
        }
        public async Task<string> GetNameByID(int? id)
        {

            var ResultOne = await Find(id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.BranchNameA.ToString();
        }
        public async Task<string> GetNameByID(string id)
        {
            return await GetNameByID(int.Parse(id));
        }

        public async Task<tblGE_Branchs> Find(int? id)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspGE_BranchsSelectSingle";
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
                    cmd.CommandText = "uspGE_BranchsEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@BranchCode";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@BranchNameA", GE_Branchs.BranchNameA);
                    cmd.Parameters.AddWithValue("@BranchNameE", GE_Branchs.BranchNameE);
                    cmd.Parameters.AddWithValue("@CountryCode", GE_Branchs.CountryCode);
                    cmd.Parameters.AddWithValue("@CityCode", GE_Branchs.CityCode);
                    cmd.Parameters.AddWithValue("@AddressA", GE_Branchs.AddressA);
                    cmd.Parameters.AddWithValue("@AddressE", GE_Branchs.AddressE);
                    cmd.Parameters.AddWithValue("@Tel1", GE_Branchs.Tel1);
                    cmd.Parameters.AddWithValue("@Tel2", GE_Branchs.Tel2);
                    cmd.Parameters.AddWithValue("@Tel3", GE_Branchs.Tel3);
                    cmd.Parameters.AddWithValue("@Fax", GE_Branchs.Fax);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();

                    GE_Branchs.BranchCode = (short)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", GE_Branchs.BranchCode);
                    return GE_Branchs.BranchCode;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", GE_Branchs.BranchNameA, dex.Message);
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
                    cmd.CommandText = "uspGE_BranchsEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchCode", GE_Branchs.BranchCode);
                    cmd.Parameters.AddWithValue("@BranchNameA", GE_Branchs.BranchNameA);
                    cmd.Parameters.AddWithValue("@BranchNameE", GE_Branchs.BranchNameE);
                    cmd.Parameters.AddWithValue("@CountryCode", GE_Branchs.CountryCode);
                    cmd.Parameters.AddWithValue("@CityCode", GE_Branchs.CityCode);
                    cmd.Parameters.AddWithValue("@AddressA", GE_Branchs.AddressA);
                    cmd.Parameters.AddWithValue("@AddressE", GE_Branchs.AddressE);
                    cmd.Parameters.AddWithValue("@Tel1", GE_Branchs.Tel1);
                    cmd.Parameters.AddWithValue("@Tel2", GE_Branchs.Tel2);
                    cmd.Parameters.AddWithValue("@Tel3", GE_Branchs.Tel3);
                    cmd.Parameters.AddWithValue("@Fax", GE_Branchs.Fax);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", GE_Branchs.BranchCode);
                    return GE_Branchs.BranchCode;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", GE_Branchs.BranchNameA, dex.Message);
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
                    cmd.CommandText = "uspGE_BranchsDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", GE_Branchs.BranchCode);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    await cmd.ExecuteNonQueryAsync();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {GE_Branchs.BranchCode} is Deleted Scussefully  ");
                    return true;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {GE_Branchs.BranchCode} is was not Deleted with Error {dex.Message}  ");
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
                    cmd.CommandText = "uspGE_BranchsDelete";
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
    public class GE_BranchsDatalist : ALookup<tblGE_Branchs>
    {



        public GE_BranchsDatalist(Boolean multi = false)
        {

            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "BranchNameA";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tblGE_Branchs> GetModels()
        {
            IEnumerable<tblGE_Branchs> listing = (IEnumerable<tblGE_Branchs>)new GE_BranchsVM().GetAll().ToEnumerable();
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

