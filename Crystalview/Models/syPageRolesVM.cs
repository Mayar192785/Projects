using Global.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using NLog;
using NonFactors.Mvc.Lookup;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using WTEG.Core;
using LogLevel = NLog.LogLevel;

namespace Global.DBModels
{
    #region create table  class

    public class tblsyPageRoles
    {
        #region base calss definitions

        [Display(Name = "syPageRoles-ID", Description = "syPageRoles-ID.")]
        //[Bind(Exclude = "ID")] //---- ID properties is excluded from model.
        [Key]
        [ReadOnly(true)]
        //[HiddenInput(DisplayValue = false)]
        [LookupColumn(Hidden = true)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ID { get; set; }

        [Display(Name = "syPageRoles-RoleName", Description = "syPageRoles-Role Name.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? RoleName { get; set; }

        [Display(Name = "syPageRoles-PageName", Description = "syPageRoles-Page Name.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? PageName { get; set; }

        [Display(Name = "syPageRoles-CanDelete", Description = "syPageRoles-Can Delete.")]
        [LookupColumn(Hidden = false)]
        public Boolean CanDelete { get; set; }

        [Display(Name = "syPageRoles-CanUpdate", Description = "syPageRoles-Can Update.")]
        [LookupColumn(Hidden = false)]
        public Boolean CanUpdate { get; set; }

        [Display(Name = "syPageRoles-CanAdd", Description = "syPageRoles-Can Add.")]
        [LookupColumn(Hidden = false)]
        public Boolean CanAdd { get; set; }

        [Display(Name = "syPageRoles-CanPrint", Description = "syPageRoles-Can Print.")]
        [LookupColumn(Hidden = false)]
        public Boolean CanPrint { get; set; }

        #endregion base calss definitions

        #region lookupname

        public String? lookupName
        {
            get
            {
                return ID.ToString();
                //        return LCNumber + "--" + SupplierIDName;
            }
            set { }
        }

        #endregion lookupname
    }

    #endregion create table  class

    #region create metModelviewa class

    public class syPageRolesVM : BaseVM
    {
        public tblsyPageRoles syPageRoles;

        #region selection helper functions

        public SelectList GetsyPageRolesForLkp()
        {
            var LookupData = GetAll()
                .ToEnumerable()
                ;
            return new SelectList(LookupData, "ID", "lookupName");
        }

        public async Task<IEnumerable<SelectListItem>> GetsyPageRolesForLkpAsync()
        {
            List<SelectListItem> LookupData = await GetAll()
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.ID.ToString(),
                        Text = n.lookupName
                    }).ToListAsync();
            return LookupData;
        }

        public async IAsyncEnumerable<tblsyPageRoles> GetAll()
        {
            await using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspsyPageRolesSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        yield return new tblsyPageRoles
                        {
                            ID = reader.GetValue<int>("ID"),
                            RoleName = reader.GetValue<string>("RoleName"),
                            PageName = reader.GetValue<string>("PageName"),
                            CanDelete = reader.GetValue<bool>("CanDelete"),
                            CanUpdate = reader.GetValue<bool>("CanUpdate"),
                            CanAdd = reader.GetValue<bool>("CanAdd"),
                            CanPrint = reader.GetValue<bool>("CanPrint"),
                        };
                    }
                }
            }
        }

        public async Task<int> GetCount()
        {
            await using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "SELECT IsNull(COUNT(*),1) FROM syPageRoles";
                cmd.CommandType = CommandType.Text;
                Int32 count = (int)await cmd.ExecuteScalarAsync();

                return count;
            }
        }

        public async IAsyncEnumerable<tblsyPageRoles> GetPaged(int Page)
        {
            await using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspsyPageRolesPagedSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@Page", Page);
                cmd.Parameters.AddWithValue("@RecsPerPage", 20);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        yield return new tblsyPageRoles
                        {
                            ID = reader.GetValue<int>("ID"),
                            RoleName = reader.GetValue<string>("RoleName"),
                            PageName = reader.GetValue<string>("PageName"),
                            CanDelete = reader.GetValue<bool>("CanDelete"),
                            CanUpdate = reader.GetValue<bool>("CanUpdate"),
                            CanAdd = reader.GetValue<bool>("CanAdd"),
                            CanPrint = reader.GetValue<bool>("CanPrint"),
                        };
                    }
                }
            }
        }

        public tblsyPageRoles GetEmpty()
        {
            return new tblsyPageRoles
            {
                ID = 0,
                RoleName = "",
                PageName = "",
                CanDelete = true,
                CanUpdate = true,
                CanAdd = true,
                CanPrint = true,
            };
        }

        public async Task<string> GetNameByID(int? id)
        {
            var ResultOne = await Find(id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.RoleName.ToString();
        }

        public async Task<string> GetNameByID(string id)
        {
            return await GetNameByID(int.Parse(id));
        }

        public async Task<tblsyPageRoles> Find(int? id)
        {
            await using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspsyPageRolesSelectSingle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@ID", id);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new tblsyPageRoles
                        {
                            ID = reader.GetValue<int>("ID"),
                            RoleName = reader.GetValue<string>("RoleName"),
                            PageName = reader.GetValue<string>("PageName"),
                            CanDelete = reader.GetValue<bool>("CanDelete"),
                            CanUpdate = reader.GetValue<bool>("CanUpdate"),
                            CanAdd = reader.GetValue<bool>("CanAdd"),
                            CanPrint = reader.GetValue<bool>("CanPrint"),
                        };
                    }
                }
                return GetEmpty();
            }
        }

        #endregion selection helper functions

        #region CRUD

        public async Task<int> Insert()
        {
            try
            {
                await using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
                await using (var cmd = conn.CreateCommand())
                {
                    await conn.OpenAsync();
                    cmd.CommandText = "uspsyPageRolesEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@ID";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@RoleName", syPageRoles.RoleName);
                    cmd.Parameters.AddWithValue("@PageName", syPageRoles.PageName);
                    cmd.Parameters.AddWithValue("@CanDelete", syPageRoles.CanDelete);
                    cmd.Parameters.AddWithValue("@CanUpdate", syPageRoles.CanUpdate);
                    cmd.Parameters.AddWithValue("@CanAdd", syPageRoles.CanAdd);
                    cmd.Parameters.AddWithValue("@CanPrint", syPageRoles.CanPrint);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();

                    syPageRoles.ID = (int)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", syPageRoles.ID);
                    return syPageRoles.ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", syPageRoles.RoleName, dex.Message);
                GlobalError = dex.Message;
                return -1;
            }
        }

        public async Task<int> Update()
        {
            try
            {
                await using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
                await using (var cmd = conn.CreateCommand())
                {
                    await conn.OpenAsync();
                    cmd.CommandText = "uspsyPageRolesEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", syPageRoles.ID);
                    cmd.Parameters.AddWithValue("@RoleName", syPageRoles.RoleName);
                    cmd.Parameters.AddWithValue("@PageName", syPageRoles.PageName);
                    cmd.Parameters.AddWithValue("@CanDelete", syPageRoles.CanDelete);
                    cmd.Parameters.AddWithValue("@CanUpdate", syPageRoles.CanUpdate);
                    cmd.Parameters.AddWithValue("@CanAdd", syPageRoles.CanAdd);
                    cmd.Parameters.AddWithValue("@CanPrint", syPageRoles.CanPrint);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", syPageRoles.ID);
                    return syPageRoles.ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", syPageRoles.RoleName, dex.Message);
                GlobalError = dex.Message;
                return -1;
            }
        }

        public async Task<bool> Delete()
        {
            try
            {
                await using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
                await using (var cmd = conn.CreateCommand())
                {
                    await conn.OpenAsync();
                    cmd.CommandText = "uspsyPageRolesDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", syPageRoles.ID);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    await cmd.ExecuteNonQueryAsync();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {syPageRoles.ID} is Deleted Scussefully  ");
                    return true;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {syPageRoles.ID} is was not Deleted with Error {dex.Message}  ");
                GlobalError = dex.Message;
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
                await using (var cmd = conn.CreateCommand())
                {
                    await conn.OpenAsync();
                    cmd.CommandText = "uspsyPageRolesDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
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

        #endregion CRUD

        #region extra part

        /// <summary>
        /// user to return false if user is not logged in
        /// </summary>
        /// <returns></returns>

        public tblsyPageRoles GetAnosymus()
        {
            return new tblsyPageRoles
            {
                ID = 0,
                RoleName = "",
                PageName = "",
                CanDelete = false,
                CanUpdate = false,
                CanAdd = false,
                CanPrint = false,
            };
        }

        public async Task<tblsyPageRoles> getPagePermisison(string PageName, string UserName)
        {
            //var uri = Request.GetDisplayUrl();
            // get user role , not loged in
            if (UserName == null)
                return GetAnosymus();

            await using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspsyPageRolesSelectPermission";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageName", PageName);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new tblsyPageRoles
                        {
                            ID = reader.GetValue<int>("ID"),
                            RoleName = reader.GetValue<string>("RoleName"),
                            PageName = reader.GetValue<string>("PageName"),
                            CanDelete = reader.GetValue<bool>("CanDelete"),
                            CanUpdate = reader.GetValue<bool>("CanUpdate"),
                            CanAdd = reader.GetValue<bool>("CanAdd"),
                            CanPrint = reader.GetValue<bool>("CanPrint"),
                        };
                    }
                }
                return GetEmpty();
            }
        }

        public async Task<bool> pageCanCreate(string PageName, string UserName)
        {
            //var permiossions = await getPagePermisison(PageName, UserName);
            return true;//permiossions.CanAdd;
        }

        public async Task<bool> pageCanEdit(string PageName, string UserName)
        {
            //var permiossions = await getPagePermisison(PageName, UserName);
            return true;//permiossions.CanUpdate;
        }

        public async Task<bool> pageCanDelete(string PageName, string UserName)
        {
            //var permiossions = await getPagePermisison(PageName, UserName);
            return true;//permiossions.CanDelete;
        }

        public async Task<bool> pageCanPrint(string PageName, string UserName)
        {
            //var permiossions = await getPagePermisison(PageName, UserName);
            return true;//permiossions.CanPrint;
        }

        #endregion extra part
    }

    #endregion create metModelviewa class

    #region Searching and listing class datalist amnd autocomplete

    public class syPageRolesDatalist : ALookup<tblsyPageRoles>
    {
        public syPageRolesDatalist(Boolean multi = false)
        {
            //


            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "RoleName";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tblsyPageRoles> GetModels()
        {
            IEnumerable<tblsyPageRoles> listing = (IEnumerable<tblsyPageRoles>)new syPageRolesVM().GetAll();
            //        int i = listing.Count();

            return listing.AsQueryable();
        }

        public override String GetColumnHeader(System.Reflection.PropertyInfo prop)
        {
            return prop.Name;
        }
    }

    #endregion Searching and listing class datalist amnd autocomplete
}