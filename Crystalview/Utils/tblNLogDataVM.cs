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

    public class tbltblNLogData
    {
        #region base calss definitions

        [Display(Name = "tblNLogData-ID", Description = "tblNLogData-ID.")]
        //[Bind(Exclude = "ID")] //---- ID properties is excluded from model.
        [Key]
        [ReadOnly(true)]
        //[HiddenInput(DisplayValue = false)]
        [LookupColumn(Hidden = true)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ID { get; set; }

        [Display(Name = "tblNLogData-Application", Description = "tblNLogData-Application.")]
        [LookupColumn(Hidden = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? Application { get; set; }

        [Display(Name = "tblNLogData-MachineName", Description = "tblNLogData-Machine Name.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? MachineName { get; set; }

        [Display(Name = "tblNLogData-ActionName", Description = "tblNLogData-Action Name.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? ActionName { get; set; }

        [Display(Name = "tblNLogData-SiteName", Description = "tblNLogData-Site Name.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? SiteName { get; set; }

        [Display(Name = "tblNLogData-LoggedDT", Description = "tblNLogData-Logged DT.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.Date, ErrorMessage = "InvalidDate")]
        public DateTime? LoggedDT { get; set; }

        [Display(Name = "tblNLogData-logged", Description = "tblNLogData-logged.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.Date, ErrorMessage = "InvalidDate")]
        public DateTime? logged { get; set; }

        [Display(Name = "tblNLogData-Level", Description = "tblNLogData-Level.")]
        [LookupColumn(Hidden = false)]
        [StringLength(5, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? Level { get; set; }

        [Display(Name = "tblNLogData-UserName", Description = "tblNLogData-User Name.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? UserName { get; set; }

        [Display(Name = "tblNLogData-Message", Description = "tblNLogData-Message.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? Message { get; set; }

        [Display(Name = "tblNLogData-Logger", Description = "tblNLogData-Logger.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? Logger { get; set; }

        [Display(Name = "tblNLogData-Properties", Description = "tblNLogData-Properties.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? Properties { get; set; }

        [Display(Name = "tblNLogData-ServerName", Description = "tblNLogData-Server Name.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? ServerName { get; set; }

        [Display(Name = "tblNLogData-Port", Description = "tblNLogData-Port.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? Port { get; set; }

        [Display(Name = "tblNLogData-Url", Description = "tblNLogData-Url.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? Url { get; set; }

        [Display(Name = "tblNLogData-Https", Description = "tblNLogData-Https.")]
        [LookupColumn(Hidden = false)]
        public Boolean Https { get; set; }

        [Display(Name = "tblNLogData-ServerAddress", Description = "tblNLogData-Server Address.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? ServerAddress { get; set; }

        [Display(Name = "tblNLogData-RemoteAddress", Description = "tblNLogData-Remote Address.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? RemoteAddress { get; set; }

        [Display(Name = "tblNLogData-Callsite", Description = "tblNLogData-Callsite.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? Callsite { get; set; }

        [Display(Name = "tblNLogData-Exception", Description = "tblNLogData-Exception.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? Exception { get; set; }

        [Display(Name = "tblNLogData-IsError", Description = "tblNLogData-Is Error.")]
        [LookupColumn(Hidden = false)]
        public Boolean IsError { get; set; }

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

    public class tblNLogDataVM : BaseVM
    {
        public tbltblNLogData tblNLogData;

        #region selection helper functions

        public SelectList GettblNLogDataForLkp()
        {
            var LookupData = GetAll()
                ;
            return new SelectList(LookupData, "ID", "Name");
        }

        public IEnumerable<tbltblNLogData> GetAll()
        {
            using (var conn = new SqlConnection(strConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "usptblNLogDataSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new tbltblNLogData
                        {
                            ID = reader.GetValue<int>("ID"),
                            Application = reader.GetValue<string>("Application"),
                            MachineName = reader.GetValue<string>("MachineName"),
                            ActionName = reader.GetValue<string>("ActionName"),
                            SiteName = reader.GetValue<string>("SiteName"),
                            LoggedDT = reader.IsDBNull(reader.GetOrdinal("LoggedDT")) ? (DateTime?)null : DateTime.Parse(reader.GetString(reader.GetOrdinal("LoggedDT")), new CultureInfo("en-US")),
                            logged = reader.IsDBNull(reader.GetOrdinal("logged")) ? (DateTime?)null : DateTime.Parse(reader.GetString(reader.GetOrdinal("logged")), new CultureInfo("en-US")),
                            Level = reader.GetValue<string>("Level"),
                            UserName = reader.GetValue<string>("UserName"),
                            Message = reader.GetValue<string>("Message"),
                            Logger = reader.GetValue<string>("Logger"),
                            Properties = reader.GetValue<string>("Properties"),
                            ServerName = reader.GetValue<string>("ServerName"),
                            Port = reader.GetValue<string>("Port"),
                            Url = reader.GetValue<string>("Url"),
                            Https = reader.GetValue<bool>("Https"),
                            ServerAddress = reader.GetValue<string>("ServerAddress"),
                            RemoteAddress = reader.GetValue<string>("RemoteAddress"),
                            Callsite = reader.GetValue<string>("Callsite"),
                            Exception = reader.GetValue<string>("Exception"),
                            IsError = reader.GetValue<bool>("IsError"),
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
                cmd.CommandText = "SELECT IsNull(COUNT(*),1) FROM tblNLogData";
                cmd.CommandType = CommandType.Text;
                Int32 count = (Int32)cmd.ExecuteScalar();

                return count;
            }
        }

        public IEnumerable<tbltblNLogData> GetPaged(int Page)
        {
            using (var conn = new SqlConnection(strConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "usptblNLogDataPagedSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@Page", Page);
                cmd.Parameters.AddWithValue("@RecsPerPage", 20);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new tbltblNLogData
                        {
                            ID = reader.GetValue<int>("ID"),
                            Application = reader.GetValue<string>("Application"),
                            MachineName = reader.GetValue<string>("MachineName"),
                            ActionName = reader.GetValue<string>("ActionName"),
                            SiteName = reader.GetValue<string>("SiteName"),
                            LoggedDT = reader.IsDBNull(reader.GetOrdinal("LoggedDT")) ? (DateTime?)null : DateTime.Parse(reader.GetString(reader.GetOrdinal("LoggedDT")), new CultureInfo("en-US")),
                            logged = reader.IsDBNull(reader.GetOrdinal("logged")) ? (DateTime?)null : DateTime.Parse(reader.GetString(reader.GetOrdinal("logged")), new CultureInfo("en-US")),
                            Level = reader.GetValue<string>("Level"),
                            UserName = reader.GetValue<string>("UserName"),
                            Message = reader.GetValue<string>("Message"),
                            Logger = reader.GetValue<string>("Logger"),
                            Properties = reader.GetValue<string>("Properties"),
                            ServerName = reader.GetValue<string>("ServerName"),
                            Port = reader.GetValue<string>("Port"),
                            Url = reader.GetValue<string>("Url"),
                            Https = reader.GetValue<bool>("Https"),
                            ServerAddress = reader.GetValue<string>("ServerAddress"),
                            RemoteAddress = reader.GetValue<string>("RemoteAddress"),
                            Callsite = reader.GetValue<string>("Callsite"),
                            Exception = reader.GetValue<string>("Exception"),
                            IsError = reader.GetValue<bool>("IsError"),
                        };
                    }
                }
            }
        }

        public tbltblNLogData GetEmpty()
        {
            return new tbltblNLogData
            {
                ID = 0,
                Application = "",
                MachineName = "",
                ActionName = "",
                SiteName = "",
                LoggedDT = DateTime.Today,
                logged = DateTime.Today,
                Level = "",
                UserName = "",
                Message = "",
                Logger = "",
                Properties = "",
                ServerName = "",
                Port = "",
                Url = "",
                Https = false,
                ServerAddress = "",
                RemoteAddress = "",
                Callsite = "",
                Exception = "",
                IsError = false,
            };
        }

        public String? GetNameByID(int? id)
        {
            var ResultOne = Find(id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.Application.ToString();
        }

        public String? GetNameByID(string id)
        {
            return GetNameByID(int.Parse(id));
        }

        public tbltblNLogData Find(int? id)
        {
            using (var conn = new SqlConnection(strConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "usptblNLogDataSelectSingle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@ID", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new tbltblNLogData
                        {
                            ID = reader.GetValue<int>("ID"),
                            Application = reader.GetValue<string>("Application"),
                            MachineName = reader.GetValue<string>("MachineName"),
                            ActionName = reader.GetValue<string>("ActionName"),
                            SiteName = reader.GetValue<string>("SiteName"),
                            LoggedDT = reader.IsDBNull(reader.GetOrdinal("LoggedDT")) ? (DateTime?)null : DateTime.Parse(reader.GetString(reader.GetOrdinal("LoggedDT")), new CultureInfo("en-US")),
                            logged = reader.IsDBNull(reader.GetOrdinal("logged")) ? (DateTime?)null : DateTime.Parse(reader.GetString(reader.GetOrdinal("logged")), new CultureInfo("en-US")),
                            Level = reader.GetValue<string>("Level"),
                            UserName = reader.GetValue<string>("UserName"),
                            Message = reader.GetValue<string>("Message"),
                            Logger = reader.GetValue<string>("Logger"),
                            Properties = reader.GetValue<string>("Properties"),
                            ServerName = reader.GetValue<string>("ServerName"),
                            Port = reader.GetValue<string>("Port"),
                            Url = reader.GetValue<string>("Url"),
                            Https = reader.GetValue<bool>("Https"),
                            ServerAddress = reader.GetValue<string>("ServerAddress"),
                            RemoteAddress = reader.GetValue<string>("RemoteAddress"),
                            Callsite = reader.GetValue<string>("Callsite"),
                            Exception = reader.GetValue<string>("Exception"),
                            IsError = reader.GetValue<bool>("IsError"),
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
                    cmd.CommandText = "usptblNLogDataEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@ID";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@Application", tblNLogData.Application);
                    cmd.Parameters.AddWithValue("@MachineName", tblNLogData.MachineName);
                    cmd.Parameters.AddWithValue("@ActionName", tblNLogData.ActionName);
                    cmd.Parameters.AddWithValue("@SiteName", tblNLogData.SiteName);
                    cmd.Parameters.AddWithValue("@LoggedDT", tblNLogData.LoggedDT);
                    cmd.Parameters.AddWithValue("@logged", tblNLogData.logged);
                    cmd.Parameters.AddWithValue("@Level", tblNLogData.Level);
                    cmd.Parameters.AddWithValue("@UserName", tblNLogData.UserName);
                    cmd.Parameters.AddWithValue("@Message", tblNLogData.Message);
                    cmd.Parameters.AddWithValue("@Logger", tblNLogData.Logger);
                    cmd.Parameters.AddWithValue("@Properties", tblNLogData.Properties);
                    cmd.Parameters.AddWithValue("@ServerName", tblNLogData.ServerName);
                    cmd.Parameters.AddWithValue("@Port", tblNLogData.Port);
                    cmd.Parameters.AddWithValue("@Url", tblNLogData.Url);
                    cmd.Parameters.AddWithValue("@Https", tblNLogData.Https);
                    cmd.Parameters.AddWithValue("@ServerAddress", tblNLogData.ServerAddress);
                    cmd.Parameters.AddWithValue("@RemoteAddress", tblNLogData.RemoteAddress);
                    cmd.Parameters.AddWithValue("@Callsite", tblNLogData.Callsite);
                    cmd.Parameters.AddWithValue("@Exception", tblNLogData.Exception);
                    cmd.Parameters.AddWithValue("@IsError", tblNLogData.IsError);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();

                    tblNLogData.ID = (int)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", tblNLogData.ID);
                    return tblNLogData.ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", tblNLogData.Application, dex.Message);
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
                    cmd.CommandText = "usptblNLogDataEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", tblNLogData.ID);
                    cmd.Parameters.AddWithValue("@Application", tblNLogData.Application);
                    cmd.Parameters.AddWithValue("@MachineName", tblNLogData.MachineName);
                    cmd.Parameters.AddWithValue("@ActionName", tblNLogData.ActionName);
                    cmd.Parameters.AddWithValue("@SiteName", tblNLogData.SiteName);
                    cmd.Parameters.AddWithValue("@LoggedDT", tblNLogData.LoggedDT);
                    cmd.Parameters.AddWithValue("@logged", tblNLogData.logged);
                    cmd.Parameters.AddWithValue("@Level", tblNLogData.Level);
                    cmd.Parameters.AddWithValue("@UserName", tblNLogData.UserName);
                    cmd.Parameters.AddWithValue("@Message", tblNLogData.Message);
                    cmd.Parameters.AddWithValue("@Logger", tblNLogData.Logger);
                    cmd.Parameters.AddWithValue("@Properties", tblNLogData.Properties);
                    cmd.Parameters.AddWithValue("@ServerName", tblNLogData.ServerName);
                    cmd.Parameters.AddWithValue("@Port", tblNLogData.Port);
                    cmd.Parameters.AddWithValue("@Url", tblNLogData.Url);
                    cmd.Parameters.AddWithValue("@Https", tblNLogData.Https);
                    cmd.Parameters.AddWithValue("@ServerAddress", tblNLogData.ServerAddress);
                    cmd.Parameters.AddWithValue("@RemoteAddress", tblNLogData.RemoteAddress);
                    cmd.Parameters.AddWithValue("@Callsite", tblNLogData.Callsite);
                    cmd.Parameters.AddWithValue("@Exception", tblNLogData.Exception);
                    cmd.Parameters.AddWithValue("@IsError", tblNLogData.IsError);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", tblNLogData.ID);
                    return tblNLogData.ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", tblNLogData.Application, dex.Message);
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
                    cmd.CommandText = "usptblNLogDataDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", tblNLogData.ID);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    cmd.ExecuteNonQuery();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {tblNLogData.ID} is Deleted Scussefully  ");
                    return true;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {tblNLogData.ID} is was not Deleted with Error {dex.Message}  ");
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
                    cmd.CommandText = "usptblNLogDataDelete";
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

    public class tblNLogDataDatalist : ALookup<tbltblNLogData>
    {
        public tblNLogDataDatalist(Boolean multi = false)
        {
            //


            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "Application";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tbltblNLogData> GetModels()
        {
            IQueryable<tbltblNLogData> listing = new tblNLogDataVM().GetAll().AsQueryable();

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