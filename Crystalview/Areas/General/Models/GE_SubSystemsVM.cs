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
    /// class created tblGE_SubSystems 
    /// </summary>
    public class tblGE_SubSystems 
    {
        #region base calss definitions
[Display(Name = "GE_SubSystems-ID", Description = "GE_SubSystems-ID." )]
//[Bind(Exclude = "ID")] //---- ID properties is excluded from model.
[Key]
[ReadOnly(true)]
//[HiddenInput(DisplayValue = false)]
[LookupColumn(Hidden = true)]
[DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
public Int32 ID { get; set; }
       
[Display(Name = "GE_SubSystems-SubSystemName", Description = "GE_SubSystems-Sub System Name." )]
[LookupColumn(Hidden = false)]
[StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
[Required(ErrorMessage = "SubSystemName is required.")]
[RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
public String SubSystemName { get; set; }
       
[Display(Name = "GE_SubSystems-SubSystemArabicName", Description = "GE_SubSystems-Sub System Arabic Name." )]
[LookupColumn(Hidden = false)]
[StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
[Required(ErrorMessage = "SubSystemArabicName is required.")]
[RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
public String SubSystemArabicName { get; set; }
       
[Display(Name = "GE_SubSystems-SubSystemShortName", Description = "GE_SubSystems-Sub System Short Name." )]
[LookupColumn(Hidden = false)]
[StringLength(20, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
[Required(ErrorMessage = "SubSystemShortName is required.")]
[RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
public String SubSystemShortName { get; set; }
       
[Display(Name = "GE_SubSystems-IsActive", Description = "GE_SubSystems-Is Active." )]
[LookupColumn(Hidden = false)]
public Boolean IsActive { get; set; }
       
        #region foreign key child realtions to get parent names
        #endregion
#endregion
        #region lookupname
             public string lookupName {
            get {
            return ID.ToString();
        //        return LCNumber + "--" + SupplierIDName;
            }
            set { }
        }
#endregion
    }
        #endregion
    #region create metModelviewa class 
    public class GE_SubSystemsVM : BaseVM
    {
        public tblGE_SubSystems? GE_SubSystems ;
        #region helper fill row
        private static   tblGE_SubSystems  ReadSingleRow(IDataRecord reader)
        {
            var dataRecord =  new tblGE_SubSystems 
            {
                            ID = reader.GetValue<Int32>( "ID"),
                            SubSystemName = reader.GetValue<string>( "SubSystemName"),
                            SubSystemArabicName = reader.GetValue<string>( "SubSystemArabicName"),
                            SubSystemShortName = reader.GetValue<string>( "SubSystemShortName"),
                            IsActive = reader.GetValue<bool>( "IsActive"),
        #region foreign key child realtions to get parent names
        #endregion


            };

            return dataRecord;
        }
        #endregion

        #region selection helper functions
        public SelectList GetGE_SubSystemsForLkp()
        {
            var LookupData = GetAll()
                .Where(x => x.IsActive)
                .ToEnumerable()
                ;
            return new SelectList(LookupData , "ID", "lookupName");
        }

        public async Task<IEnumerable<SelectListItem>> GetGE_SubSystemsForLkpAsync()
        {
            List<SelectListItem> LookupData = await GetAll()
                .Where(x => x.IsActive)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.ID.ToString(),
                        Text = n.lookupName
                    }).ToListAsync();
            return LookupData;
        }
        public  async IAsyncEnumerable<tblGE_SubSystems> GetAll()
        {
            
            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspGE_SubSystemsSelect";
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
                cmd.CommandText = "SELECT IsNull(COUNT(*),1) FROM GE_SubSystems";
                cmd.CommandType = CommandType.Text;
                Int32 count = (int)await cmd.ExecuteScalarAsync();

                return count;


            }
        }
        public async IAsyncEnumerable<tblGE_SubSystems> GetPaged( int Page )
        {
            
            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspGE_SubSystemsPagedSelect";
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


        public  tblGE_SubSystems GetEmpty()
        {
            
                         return new tblGE_SubSystems
                        {
                            ID = 0, 
                            SubSystemName = "", 
                            SubSystemArabicName = "", 
                            SubSystemShortName = "", 
                            IsActive = false, 
                        };
        }
        public async Task<string> GetNameByID(int? id)
        {

            var ResultOne = await Find(id);
            if (ResultOne == null  || ResultOne.IsActive==false )
            {
                return "Unknown";
            }
            return ResultOne.SubSystemName.ToString(); 
        }
        public async Task<string> GetNameByID(string id)
        {
            return await GetNameByID(int.Parse(id));
        }

        public async Task<tblGE_SubSystems> Find(int? id)
        {
            
            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspGE_SubSystemsSelectSingle";
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
                    cmd.CommandText = "uspGE_SubSystemsEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@ID";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@SubSystemName", GE_SubSystems.SubSystemName);
                    cmd.Parameters.AddWithValue("@SubSystemArabicName", GE_SubSystems.SubSystemArabicName);
                    cmd.Parameters.AddWithValue("@SubSystemShortName", GE_SubSystems.SubSystemShortName);
                    cmd.Parameters.AddWithValue("@IsActive", GE_SubSystems.IsActive);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                      await cmd.ExecuteNonQueryAsync();

                    GE_SubSystems.ID = (int)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name +" ID {0} is Created Scussefully  ", GE_SubSystems.ID);
                    return GE_SubSystems.ID;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", GE_SubSystems.SubSystemName, dex.Message);
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
                    cmd.CommandText = "uspGE_SubSystemsEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                     
                    cmd.Parameters.AddWithValue("@ID", GE_SubSystems.ID);
                    cmd.Parameters.AddWithValue("@SubSystemName", GE_SubSystems.SubSystemName);
                    cmd.Parameters.AddWithValue("@SubSystemArabicName", GE_SubSystems.SubSystemArabicName);
                    cmd.Parameters.AddWithValue("@SubSystemShortName", GE_SubSystems.SubSystemShortName);
                    cmd.Parameters.AddWithValue("@IsActive", GE_SubSystems.IsActive);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                     await cmd.ExecuteNonQueryAsync();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", GE_SubSystems.ID);
                    return GE_SubSystems.ID;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", GE_SubSystems.SubSystemName, dex.Message);
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
                    cmd.CommandText = "uspGE_SubSystemsDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", GE_SubSystems.ID);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                      await cmd.ExecuteNonQueryAsync();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {GE_SubSystems.ID} is Deleted Scussefully  ");
                    return true;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {GE_SubSystems.ID} is was not Deleted with Error {dex.Message}  ");
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
                    cmd.CommandText = "uspGE_SubSystemsDelete";
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
    public class GE_SubSystemsDatalist : ALookup<tblGE_SubSystems>
    {



        public GE_SubSystemsDatalist(Boolean multi = false)
        {

            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort  = "SubSystemName";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tblGE_SubSystems> GetModels()
        {
            IEnumerable< tblGE_SubSystems> listing = (IEnumerable<tblGE_SubSystems>) new GE_SubSystemsVM().GetAll().ToEnumerable();
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

