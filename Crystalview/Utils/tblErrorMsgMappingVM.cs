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

    public class tbltblErrorMsgMapping
    {
        #region base calss definitions

        [Display(Name = "tblErrorMsgMapping-ID", Description = "tblErrorMsgMapping-ID.")]
        //[Bind(Exclude = "ID")] //---- ID properties is excluded from model.
        [Key]
        [ReadOnly(true)]
        //[HiddenInput(DisplayValue = false)]
        [LookupColumn(Hidden = true)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ID { get; set; }

        [Display(Name = "tblErrorMsgMapping-OriginalError", Description = "tblErrorMsgMapping-Original Error.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? OriginalError { get; set; }

        [Display(Name = "tblErrorMsgMapping-ErrorMessage", Description = "tblErrorMsgMapping-Error Message.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? ErrorMessage { get; set; }

        #endregion base calss definitions

        #region lookupname

        public String? lookupName
        {
            get
            {
                return OriginalError.ToString();
                //        return LCNumber + "--" + SupplierIDName;
            }
            set { }
        }

        #endregion lookupname
    }

    #endregion create table  class

    #region create metModelviewa class

    public class tblErrorMsgMappingVM : BaseVM
    {
        public tbltblErrorMsgMapping? tblErrorMsgMapping;

        #region selection helper functions

        public SelectList GettblErrorMsgMappingForLkp()
        {
            var LookupData = GetAll()
                ;
            return new SelectList(LookupData, "ID", "lookupName");
        }

        public IEnumerable<tbltblErrorMsgMapping> GetAll()
        {
            using (var conn = new SqlConnection(strConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "usptblErrorMsgMappingSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new tbltblErrorMsgMapping
                        {
                            ID = reader.GetValue<int>("ID"),
                            OriginalError = reader.GetValue<string>("OriginalError"),
                            ErrorMessage = reader.GetValue<string>("ErrorMessage"),
                        };
                    }
                }
            }
        }

        public int GetCount()
        {
            using (var conn = new SqlConnection(strConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT IsNull(COUNT(*),1) FROM tblErrorMsgMapping";
                cmd.CommandType = CommandType.Text;
                Int32 count = (Int32)cmd.ExecuteScalar();

                return count;
            }
        }

        public IEnumerable<tbltblErrorMsgMapping> GetPaged(int Page)
        {
            using (var conn = new SqlConnection(strConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "usptblErrorMsgMappingPagedSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@Page", Page);
                cmd.Parameters.AddWithValue("@RecsPerPage", 20);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new tbltblErrorMsgMapping
                        {
                            ID = reader.GetValue<int>("ID"),
                            OriginalError = reader.GetValue<string>("OriginalError"),
                            ErrorMessage = reader.GetValue<string>("ErrorMessage"),
                        };
                    }
                }
            }
        }

        public tbltblErrorMsgMapping GetEmpty()
        {
            return new tbltblErrorMsgMapping
            {
                ID = 0,
                OriginalError = "",
                ErrorMessage = "",
            };
        }

        public String? GetNameByID(int? id)
        {
            var ResultOne = Find(id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.OriginalError.ToString();
        }

        public String? GetNameByID(string id)
        {
            return GetNameByID(int.Parse(id));
        }

        public tbltblErrorMsgMapping Find(int? id)
        {
            using (var conn = new SqlConnection(strConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "usptblErrorMsgMappingSelectSingle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@ID", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new tbltblErrorMsgMapping
                        {
                            ID = reader.GetValue<int>("ID"),
                            OriginalError = reader.GetValue<string>("OriginalError"),
                            ErrorMessage = reader.GetValue<string>("ErrorMessage"),
                        };
                    }
                }
                return GetEmpty();
            }
        }

        #endregion selection helper functions

        #region CRUD

        public int Insert()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "usptblErrorMsgMappingEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@ID";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@OriginalError", tblErrorMsgMapping.OriginalError);
                    cmd.Parameters.AddWithValue("@ErrorMessage", tblErrorMsgMapping.ErrorMessage);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();

                    tblErrorMsgMapping.ID = (int)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", tblErrorMsgMapping.ID);
                    return tblErrorMsgMapping.ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", tblErrorMsgMapping.OriginalError, dex.Message);
                GlobalError = dex.Message;
                return -1;
            }
        }

        public int Update()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "usptblErrorMsgMappingEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", tblErrorMsgMapping.ID);
                    cmd.Parameters.AddWithValue("@OriginalError", tblErrorMsgMapping.OriginalError);
                    cmd.Parameters.AddWithValue("@ErrorMessage", tblErrorMsgMapping.ErrorMessage);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", tblErrorMsgMapping.ID);
                    return tblErrorMsgMapping.ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", tblErrorMsgMapping.OriginalError, dex.Message);
                GlobalError = dex.Message;
                return -1;
            }
        }

        public bool Delete()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "usptblErrorMsgMappingDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", tblErrorMsgMapping.ID);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    cmd.ExecuteNonQuery();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {tblErrorMsgMapping.ID} is Deleted Scussefully  ");
                    return true;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {tblErrorMsgMapping.ID} is was not Deleted with Error {dex.Message}  ");
                GlobalError = dex.Message;
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "usptblErrorMsgMappingDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.ExecuteNonQuery();
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
    }

    #endregion create metModelviewa class

    #region Searching and listing class datalist amnd autocomplete

    public class tblErrorMsgMappingDatalist : ALookup<tbltblErrorMsgMapping>
    {
        public tblErrorMsgMappingDatalist(Boolean multi = false)
        {
            //


            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "OriginalError";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tbltblErrorMsgMapping> GetModels()
        {
            IQueryable<tbltblErrorMsgMapping> listing = new tblErrorMsgMappingVM().GetAll().AsQueryable();
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