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

namespace Global.Models
{
    #region create table  class

    public class tblsyMenuRoles
    {
        #region base calss definitions

        [Display(Name = "syMenuRoles-ID", Description = "syMenuRoles-ID.")]
        //[Bind(Exclude = "ID")] //---- ID properties is excluded from model.
        [Key]
        [ReadOnly(true)]
        //[HiddenInput(DisplayValue = false)]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ID { get; set; }

        [Display(Name = "syMenuRoles-MenuID", Description = "syMenuRoles-Menu ID.")]
        [LookupColumn(Hidden = true)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 MenuID { get; set; }

        [Display(Name = "syMenuRoles-RoleID", Description = "syMenuRoles-Role ID.")]
        [LookupColumn(Hidden = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? RoleID { get; set; }

        #endregion base calss definitions
    }

    #endregion create table  class

    #region create metModelviewa class

    public class syMenuRolesVM : BaseVM
    {
        public tblsyMenuRoles syMenuRoles;

        #region selection helper functions

        public SelectList GetsyMenuRolesForLkp()
        {
            var LookupData = GetAll()
                ;
            return new SelectList(LookupData, "ID", "Name");
        }

        public SelectList GetsyMenuRolesForLkp(int MenuID)
        {
            var LookupData = GetAll(MenuID)
                ;
            return new SelectList(LookupData, "ID", "Name");
        }

        public IEnumerable<tblsyMenuRoles> GetAll(int MenuID)
        {
            using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "uspsyMenuRolesMenuSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@MenuID", MenuID);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new tblsyMenuRoles
                        {
                            ID = reader.GetValue<int>("ID"),
                            MenuID = reader.GetValue<int>("MenuID"),
                            RoleID = reader.GetValue<string>("RoleID"),
                        };
                    }
                }
            }
        }

        public IEnumerable<tblsyMenuRoles> GetAll()
        {
            using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "uspsyMenuRolesSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@MenuID", -1);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new tblsyMenuRoles
                        {
                            ID = reader.GetValue<int>("ID"),
                            MenuID = reader.GetValue<int>("MenuID"),
                            RoleID = reader.GetValue<string>("RoleID"),
                        };
                    }
                }
            }
        }

        public IEnumerable<tblsyMenuRoles> GetEmpty()
        {
            yield return new tblsyMenuRoles
            {
                ID = 0,
                MenuID = 0,
                RoleID = null,
            };
        }

        public String? GetNameByID(int id)
        {
            var ResultOne = GetAll().FirstOrDefault((p) => p.ID == (int)id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.RoleID;
        }

        public String? GetNameByID(string id)
        {
            return GetNameByID(int.Parse(id));
        }

        public tblsyMenuRoles Find(int id)
        {
            var ResultOne = GetAll().FirstOrDefault((p) => p.ID == (int)id);
            if (ResultOne == null)
            {
                return null;
            }
            return ResultOne;
        }

        #endregion selection helper functions

        #region application roles

        public int AddAllMenu(string RoleName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SiteUtils.GeneralConnection))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "usp_syAddAllMenuToRole";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoleName", RoleName);

                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", RoleName);
                    return 0;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", RoleName, dex.Message);
                return -1;
            }
        }

        #endregion application roles

        #region CRUD

        public int Insert()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SiteUtils.GeneralConnection))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "uspsyMenuRolesEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@ID";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@MenuID", syMenuRoles.MenuID);
                    cmd.Parameters.AddWithValue("@RoleID", syMenuRoles.RoleID);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();

                    syMenuRoles.ID = (int)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", syMenuRoles.ID);
                    return syMenuRoles.ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", syMenuRoles.MenuID, dex.Message);
                return -1;
            }
        }

        public int Update()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SiteUtils.GeneralConnection))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "uspsyMenuRolesEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", syMenuRoles.ID);
                    cmd.Parameters.AddWithValue("@MenuID", syMenuRoles.MenuID);
                    cmd.Parameters.AddWithValue("@RoleID", syMenuRoles.RoleID);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", syMenuRoles.ID);
                    return syMenuRoles.ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", syMenuRoles.MenuID, dex.Message);
                return -1;
            }
        }

        public bool Delete()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SiteUtils.GeneralConnection))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "uspsyMenuRolesDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", syMenuRoles.ID);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    cmd.ExecuteNonQuery();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {syMenuRoles.ID} is Deleted Scussefully  ");// );
                    return true;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {syMenuRoles.ID} is was not Deleted with Error {dex.Message}  ");//;syMenuRoles.MenuID, dex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SiteUtils.GeneralConnection))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "uspsyMenuRolesDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.ExecuteNonQuery();
                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {id} is Deleted Scussefully  ");// syMenuRoles.ID);
                    return true;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {id} is was not Deleted with Error {dex.Message}  ");//;syMenuRoles.MenuID, dex.Message);
                return false;
            }
        }

        #endregion CRUD


        #region extra 

        public bool GetUserSubsystem(int MenuOption, string UserName)
        {
            using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT   *  FROM [dbo].[viUserSubsystems] Where UserName = @UserName and parentTab = @SubSystem ";
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@UserName", UserName??"Unknown");
                cmd.Parameters.AddWithValue("@SubSystem", MenuOption);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public List<short> GetUserSubsystemList(string UserName)
        {

            var result = new List<short>();

            using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT   *  FROM [dbo].[viUserSubsystems] Where UserName = @UserName --and parentTab = @SubSystem ";
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@UserName", UserName ?? "Unknown");
                //cmd.Parameters.AddWithValue("@SubSystem", MenuOption);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetValue<short>("ParentTab"));
                    }
                }
            }
            return result;
        }
        #endregion
    }

    #endregion create metModelviewa class

    #region Searching and listing class datalist amnd autocomplete

    public class syMenuRolesDatalist : ALookup<tblsyMenuRoles>
    {
        public syMenuRolesDatalist(Boolean multi = false)
        {
            //


            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "MenuID";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tblsyMenuRoles> GetModels()
        {
            IQueryable<tblsyMenuRoles> listing = new syMenuRolesVM().GetAll(-1).AsQueryable();

            //        int i = listing.Count();

            return listing;
        }

        public override String GetColumnHeader(System.Reflection.PropertyInfo prop)
        {
            return prop.Name;
        }
    }

    #endregion Searching and listing class datalist amnd autocomplete
}