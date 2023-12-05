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
    #region create metModelviewa class

    public class syMenuVM : BaseVM
    {
        #region base calss definitions

        [Display(Name = "syMenu-ID", Description = "syMenu-ID.")]
        //[Bind(Exclude = "ID")] //---- ID properties is excluded from model.
        [Key]
        [ReadOnly(true)]
        //[HiddenInput(DisplayValue = false)]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ID { get; set; }

        [Display(Name = "syMenu-ParentID", Description = "syMenu-Parent ID.")]
        [LookupColumn(Hidden = true)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32? ParentID { get; set; }

        [Display(Name = "syMenu-Url", Description = "syMenu-Url.")]
        [LookupColumn(Hidden = true)]
        [StringLength(249, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? Url { get; set; }

        [Display(Name = "syMenu-Description", Description = "syMenu-Description.")]
        [Required(ErrorMessage = "{0} is required.")]
        [LookupColumn(Hidden = true)]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? Description { get; set; }

        [Display(Name = "syMenu-OrderID", Description = "syMenu-Order ID.")]
        [Required(ErrorMessage = "{0} is required.")]
        [LookupColumn(Hidden = true)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 OrderID { get; set; }

        [Display(Name = "syMenu-IsEnabled", Description = "syMenu-Is Enabled.")]
        [LookupColumn(Hidden = true)]
        public Boolean IsEnabled { get; set; }

        [Display(Name = "syMenu-Target", Description = "syMenu-Target.")]
        [LookupColumn(Hidden = true)]
        [StringLength(10, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? Target { get; set; }

        [Display(Name = "syMenu-ParentTab", Description = "syMenu-Parent Tab.")]
        [LookupColumn(Hidden = true)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        [Range(0, 254, ErrorMessage = "InvalidRange")]
        public Int16 ParentTab { get; set; }

        [Display(Name = "syMenu-ActionName", Description = "syMenu-Action Name.")]
        [LookupColumn(Hidden = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String? ActionName { get; set; }

        [Display(Name = "syMenu-ControllerName", Description = "syMenu-Controller Name.")]
        [LookupColumn(Hidden = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String? ControllerName { get; set; }

        [Display(Name = "syMenu-IconName", Description = "syMenu-Icon Name.")]
        [LookupColumn(Hidden = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String? IconName { get; set; }

        // extra master details part to be used
        public Boolean? ShowGrid { get; set; }

        public List<tblsyMenuNames>? syMenuNamesDetails { get; set; }
        public List<tblsyMenuRoles>? syMenuRolesDetails { get; set; }

        #endregion base calss definitions

        #region selection helper functions

        public SelectList GetsyMenuForLkp()
        {
            var LookupData = GetAll()
                ;
            return new SelectList(LookupData, "ID", "Description");
        }

        public IEnumerable<syMenuVM> GetAll()
        {
            using (var conn = new SqlConnection(SiteUtils.GeneralConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "uspsyMenuSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new syMenuVM
                        {
                            ID = reader.GetValue<int>("ID"),
                            ParentID = reader.GetValue<int>("ParentID"),
                            Url = reader.GetValue<string>("Url"),
                            Description = reader.GetValue<string>("Description"),
                            OrderID = reader.GetValue<int>("OrderID"),
                            IsEnabled = reader.GetValue<bool>("IsEnabled"),
                            Target = reader.GetValue<string>("Target"),
                            ParentTab = reader.GetValue<Int16>("ParentTab"),
                            ActionName = reader.GetValue<string>("ActionName"),
                            ControllerName = reader.GetValue<string>("ControllerName"),
                            IconName = reader.GetValue<string>("IconName"),
                        };
                    }
                }
            }
        }

        #region tree view related

        public IEnumerable<syMenuVM> GetAllParents()
        {
            return GetAll().Where(m => m.ParentID == -1);
        }

        public IEnumerable<syMenuVM> GetAllChildren(int id)
        {
            return GetAll().Where(m => m.ParentID == id);
        }

        #endregion tree view related

        public IEnumerable<syMenuVM> GetEmpty()
        {
            yield return new syMenuVM
            {
                ID = 0,
                ParentID = 0,
                Url = null,
                Description = null,
                OrderID = 0,
                IsEnabled = false,
                Target = null,
                ParentTab = 0,
                ActionName = null,
                ControllerName = null,
                IconName = null,
            };
        }

        public String? GetNameByID(int? id)
        {
            var ResultOne = GetAll().FirstOrDefault((p) => p.ID == (int)id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.Description;
        }

        public String? GetNameByID(string id)
        {
            return GetNameByID(int.Parse(id));
        }

        public syMenuVM Find(int id)
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
                    cmd.CommandText = "uspsyMenuEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@ID";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@ParentID", ParentID);
                    cmd.Parameters.AddWithValue("@Url", Url);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    cmd.Parameters.AddWithValue("@IsEnabled", IsEnabled);
                    cmd.Parameters.AddWithValue("@Target", Target);
                    cmd.Parameters.AddWithValue("@ParentTab", ParentTab);
                    cmd.Parameters.AddWithValue("@ActionName", ActionName);
                    cmd.Parameters.AddWithValue("@ControllerName", ControllerName);
                    cmd.Parameters.AddWithValue("@IconName", IconName);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();

                    ID = (int)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", ID);
                    return ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", ParentID, dex.Message);
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
                    cmd.CommandText = "uspsyMenuEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@ParentID", ParentID);
                    cmd.Parameters.AddWithValue("@Url", Url);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    cmd.Parameters.AddWithValue("@IsEnabled", IsEnabled);
                    cmd.Parameters.AddWithValue("@Target", Target);
                    cmd.Parameters.AddWithValue("@ParentTab", ParentTab);
                    cmd.Parameters.AddWithValue("@ActionName", ActionName);
                    cmd.Parameters.AddWithValue("@ControllerName", ControllerName);
                    cmd.Parameters.AddWithValue("@IconName", IconName);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", ID);
                    return ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", ParentID, dex.Message);
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
                    cmd.CommandText = "uspsyMenuDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    cmd.ExecuteNonQuery();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {ID} is Deleted Scussefully  ");// ID);
                    return true;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {ID} is was not Deleted with Error {dex.Message}  ");//;ParentID, dex.Message);
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
                    cmd.CommandText = "uspsyMenuDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.ExecuteNonQuery();
                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {id} is Deleted Scussefully  ");// ID);
                    return true;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {id} is was not Deleted with Error {dex.Message}  ");//;ParentID, dex.Message);
                return false;
            }
        }

        #endregion CRUD
    }

    #endregion create metModelviewa class

    #region Searching and listing class datalist amnd autocomplete

    public class syMenuDatalist : ALookup<syMenuVM>
    {
        public syMenuDatalist(Boolean multi = false)
        {
            //


            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "ParentID";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<syMenuVM> GetModels()
        {
            IQueryable<syMenuVM> listing = new syMenuVM().GetAll().AsQueryable();

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