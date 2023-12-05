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

    public class tblsyMenuNames
    {
        #region base calss definitions

        [Display(Name = "syMenuNames-ID", Description = "syMenuNames-ID.")]
        //[Bind(Exclude = "ID")] //---- ID properties is excluded from model.
        [Key]
        [ReadOnly(true)]
        //[HiddenInput(DisplayValue = false)]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ID { get; set; }

        [Display(Name = "syMenuNames-MenuID", Description = "syMenuNames-Menu ID.")]
        [LookupColumn(Hidden = true)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 MenuID { get; set; }

        [Display(Name = "syMenuNames-Name", Description = "syMenuNames-Name.")]
        [LookupColumn(Hidden = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String? Name { get; set; }

        [Display(Name = "syMenuNames-LanguageID", Description = "syMenuNames-Language ID.")]
        [LookupColumn(Hidden = true)]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? LanguageID { get; set; }

        [Display(Name = "syMenuNames-Description", Description = "syMenuNames-Description.")]
        [LookupColumn(Hidden = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? Description { get; set; }

        #endregion base calss definitions
    }

    #endregion create table  class

    #region create metModelviewa class

    public class syMenuNamesVM : BaseVM
    {
        public tblsyMenuNames? syMenuNames;

        #region selection helper functions

        public SelectList GetsyMenuNamesForLkp()
        {
            var LookupData = GetAll()
                ;
            return new SelectList(LookupData, "ID", "Name");
        }

        public SelectList GetsyMenuNamesForLkp(int MenuID)
        {
            var LookupData = GetAll(MenuID)
                ;
            return new SelectList(LookupData, "ID", "Name");
        }

        public IEnumerable<tblsyMenuNames> GetAll(int MenuID)
        {
            using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "uspsyMenuNamesSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@MenuID", MenuID);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new tblsyMenuNames
                        {
                            ID = reader.GetValue<int>("ID"),
                            MenuID = reader.GetValue<int>("MenuID"),
                            Name = reader.GetValue<string>("Name"),
                            LanguageID = reader.GetValue<string>("LanguageID"),
                            Description = reader.GetValue<string>("Description"),
                        };
                    }
                }
            }
        }

        public IEnumerable<tblsyMenuNames> GetAll()
        {
            using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "uspsyMenuNamesSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@MenuID", -1);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new tblsyMenuNames
                        {
                            ID = reader.GetValue<int>("ID"),
                            MenuID = reader.GetValue<int>("MenuID"),
                            Name = reader.GetValue<string>("Name"),
                            LanguageID = reader.GetValue<string>("LanguageID"),
                            Description = reader.GetValue<string>("Description"),
                        };
                    }
                }
            }
        }

        public IEnumerable<tblsyMenuNames> GetEmpty()
        {
            yield return new tblsyMenuNames
            {
                ID = 0,
                MenuID = 0,
                Name = null,
                LanguageID = null,
                Description = null,
            };
        }

        public String? GetNameByID(int id)
        {
            var ResultOne = GetAll().FirstOrDefault((p) => p.ID == (int)id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.Name;
        }

        public String? GetNameByID(string id)
        {
            return GetNameByID(int.Parse(id));
        }

        public tblsyMenuNames Find(int id)
        {
            var ResultOne = GetAll().FirstOrDefault((p) => p.ID == (int)id);
            if (ResultOne == null)
            {
                return null;
            }
            return ResultOne;
        }

        #endregion selection helper functions

        #region CRUD

        public int Insert()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SiteUtils.GeneralConnection))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "uspsyMenuNamesEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@ID";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@MenuID", syMenuNames.MenuID);
                    cmd.Parameters.AddWithValue("@Name", syMenuNames.Name);
                    cmd.Parameters.AddWithValue("@LanguageID", syMenuNames.LanguageID);
                    cmd.Parameters.AddWithValue("@Description", syMenuNames.Description);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    //cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();

                    syMenuNames.ID = (int)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", syMenuNames.ID);
                    return syMenuNames.ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", syMenuNames.MenuID, dex.Message);
                GlobalError = dex.Message; return -1;
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
                    cmd.CommandText = "uspsyMenuNamesEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", syMenuNames.ID);
                    cmd.Parameters.AddWithValue("@MenuID", syMenuNames.MenuID);
                    cmd.Parameters.AddWithValue("@Name", syMenuNames.Name);
                    cmd.Parameters.AddWithValue("@LanguageID", syMenuNames.LanguageID);
                    cmd.Parameters.AddWithValue("@Description", syMenuNames.Description);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    //cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", syMenuNames.ID);
                    return syMenuNames.ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", syMenuNames.MenuID, dex.Message);
                GlobalError = dex.Message; return -1;
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
                    cmd.CommandText = "uspsyMenuNamesDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", syMenuNames.ID);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    cmd.ExecuteNonQuery();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {syMenuNames.ID} is Deleted Scussefully  ");// );
                    return true;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {syMenuNames.ID} is was not Deleted with Error {dex.Message}  ");//;syMenuNames.MenuID, dex.Message);
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
                    cmd.CommandText = "uspsyMenuNamesDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.ExecuteNonQuery();
                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {id} is Deleted Scussefully  ");// syMenuNames.ID);
                    return true;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {id} is was not Deleted with Error {dex.Message}  ");//;syMenuNames.MenuID, dex.Message);
                return false;
            }
        }

        #endregion CRUD
    }

    #endregion create metModelviewa class

    #region Searching and listing class datalist amnd autocomplete

    public class syMenuNamesDatalist : ALookup<tblsyMenuNames>
    {
        public syMenuNamesDatalist(Boolean multi = false)
        {
            //


            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "MenuID";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tblsyMenuNames> GetModels()
        {
            IQueryable<tblsyMenuNames> listing = new syMenuNamesVM().GetAll(-1).AsQueryable();

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