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

    public class tblsyIncidents
    {
        #region base calss definitions

        [Display(Name = "syIncidents-ID", Description = "syIncidents-ID.")]
        //[Bind(Exclude = "ID")] //---- ID properties is excluded from model.
        [Key]
        [ReadOnly(true)]
        //[HiddenInput(DisplayValue = false)]
        [LookupColumn(Hidden = true)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ID { get; set; }

        [Display(Name = "syIncidents-Subject", Description = "syIncidents-Subject.")]
        [LookupColumn(Hidden = false)]
        [StringLength(80, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? Subject { get; set; }

        [Display(Name = "syIncidents-SubSystem", Description = "syIncidents-Sub System.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 SubSystem { get; set; }

        [Display(Name = "syIncidents-URL", Description = "syIncidents-U RL.")]
        [LookupColumn(Hidden = false)]
        [StringLength(80, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String? URL { get; set; }

        [Display(Name = "syIncidents-Priority", Description = "syIncidents-Priority.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 Priority { get; set; }

        [Display(Name = "syIncidents-UserName", Description = "syIncidents-User Name.")]
        [LookupColumn(Hidden = false)]
        [StringLength(10, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String? UserName { get; set; }

        [Display(Name = "syIncidents-IncidentType", Description = "syIncidents-Incident Type.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 IncidentType { get; set; }

        [Display(Name = "syIncidents-IncidentDate", Description = "syIncidents-Incident Date.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.Date, ErrorMessage = "InvalidDate")]
        public DateTime? IncidentDate { get; set; }

        [Display(Name = "syIncidents-IncidentTime", Description = "syIncidents-Incident Time.")]
        [LookupColumn(Hidden = false)]
        [StringLength(5, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [DataType(DataType.Time, ErrorMessage = "InvalidTime")]
        public String? IncidentTime { get; set; }

        [Display(Name = "syIncidents-Description", Description = "syIncidents-Description.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? Description { get; set; }

        [Display(Name = "syIncidents-StepsToGenerate", Description = "syIncidents-Steps To Generate.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.MultilineText)]
        public String? StepsToGenerate { get; set; }

        [Display(Name = "syIncidents-Status", Description = "syIncidents-Status.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 Status { get; set; }

        [Display(Name = "syIncidents-StatusDate", Description = "syIncidents-Status Date.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.Date, ErrorMessage = "InvalidDate")]
        public DateTime? StatusDate { get; set; }

        #region foreign key child realtions to get parent names

        public String? IncidentTypeName { get; set; }
        public String? PriorityName { get; set; }
        public String? StatusName { get; set; }
        public String? SubSystemName { get; set; }

        #endregion foreign key child realtions to get parent names

        #endregion base calss definitions
    }

    #endregion create table  class

    #region create metModelviewa class

    public class syIncidentsVM : BaseVM
    {
        public tblsyIncidents? syIncidents;

        #region selection helper functions

        public SelectList GetsyIncidentsForLkp()
        {
            var LookupData = GetAll()
                ;
            return new SelectList(LookupData, "ID", "Name");
        }

        public IEnumerable<tblsyIncidents> GetAll()
        {
            using (var conn = new SqlConnection(strConnection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "uspsyIncidentsSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new tblsyIncidents
                        {
                            ID = reader.GetValue<int>("ID"),
                            Subject = reader.GetValue<string>("Subject"),
                            SubSystem = reader.GetValue<int>("SubSystem"),
                            URL = reader.GetValue<string>("URL"),
                            Priority = reader.GetValue<Int16>("Priority"),
                            UserName = reader.GetValue<string>("UserName"),
                            IncidentType = reader.GetValue<int>("IncidentType"),
                            IncidentDate = reader.IsDBNull(reader.GetOrdinal("IncidentDate")) ? (DateTime?)null : DateTime.Parse(reader.GetString(reader.GetOrdinal("IncidentDate")), new CultureInfo("en-US")),
                            IncidentTime = reader.GetValue<string>("IncidentTime"),
                            Description = reader.GetValue<string>("Description"),
                            StepsToGenerate = reader.GetValue<string>("StepsToGenerate"),
                            Status = reader.GetValue<Int16>("Status"),
                            StatusDate = reader.IsDBNull(reader.GetOrdinal("StatusDate")) ? (DateTime?)null : DateTime.Parse(reader.GetString(reader.GetOrdinal("StatusDate"))),

                            #region foreign key child realtions to get parent names

                            IncidentTypeName = reader.GetValue<string>("IncidentTypeName"),
                            PriorityName = reader.GetValue<string>("PriorityName"),
                            StatusName = reader.GetValue<string>("StatusName"),
                            SubSystemName = reader.GetValue<string>("SubSystemName"),

                            #endregion foreign key child realtions to get parent names
                        };
                    }
                }
            }
        }

        public IEnumerable<tblsyIncidents> GetEmpty()
        {
            yield return new tblsyIncidents
            {
                ID = 0,
                Subject = null,
                SubSystem = 0,
                URL = null,
                Priority = 0,
                UserName = null,
                IncidentType = 0,
                IncidentDate = DateTime.Today,
                IncidentTime = null,
                Description = null,
                StepsToGenerate = null,
                Status = 0,
                StatusDate = DateTime.Today,
            };
        }

        public String? GetNameByID(int id)
        {
            var ResultOne = GetAll().FirstOrDefault((p) => p.ID == (int)id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.Subject;
        }

        public String? GetNameByID(string id)
        {
            return GetNameByID(int.Parse(id));
        }

        public tblsyIncidents Find(int id)
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
                using (SqlConnection conn = new SqlConnection(strConnection))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "uspsyIncidentsEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@ID";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@SubSystem", syIncidents.SubSystem);
                    cmd.Parameters.AddWithValue("@URL", syIncidents.URL);
                    cmd.Parameters.AddWithValue("@Priority", syIncidents.Priority);
                    cmd.Parameters.AddWithValue("@Subject", syIncidents.Subject);
                    //cmd.Parameters.AddWithValue("@UserName", syIncidents.UserName);
                    cmd.Parameters.AddWithValue("@IncidentType", syIncidents.IncidentType);
                    cmd.Parameters.AddWithValue("@IncidentDate", syIncidents.IncidentDate);
                    cmd.Parameters.AddWithValue("@IncidentTime", syIncidents.IncidentTime);
                    cmd.Parameters.AddWithValue("@Description", syIncidents.Description);
                    cmd.Parameters.AddWithValue("@StepsToGenerate", syIncidents.StepsToGenerate);
                    cmd.Parameters.AddWithValue("@Status", syIncidents.Status);
                    cmd.Parameters.AddWithValue("@StatusDate", syIncidents.StatusDate);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();

                    syIncidents.ID = (int)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", syIncidents.ID);
                    return syIncidents.ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", syIncidents.Subject, dex.Message);
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
                    cmd.CommandText = "uspsyIncidentsEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", syIncidents.ID);
                    cmd.Parameters.AddWithValue("@Subject", syIncidents.Subject);
                    cmd.Parameters.AddWithValue("@SubSystem", syIncidents.SubSystem);
                    cmd.Parameters.AddWithValue("@URL", syIncidents.URL);
                    cmd.Parameters.AddWithValue("@Priority", syIncidents.Priority);
                    // cmd.Parameters.AddWithValue("@UserName", syIncidents.UserName);
                    cmd.Parameters.AddWithValue("@IncidentType", syIncidents.IncidentType);
                    cmd.Parameters.AddWithValue("@IncidentDate", syIncidents.IncidentDate);
                    cmd.Parameters.AddWithValue("@IncidentTime", syIncidents.IncidentTime);
                    cmd.Parameters.AddWithValue("@Description", syIncidents.Description);
                    cmd.Parameters.AddWithValue("@StepsToGenerate", syIncidents.StepsToGenerate);
                    cmd.Parameters.AddWithValue("@Status", syIncidents.Status);
                    cmd.Parameters.AddWithValue("@StatusDate", syIncidents.StatusDate);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    cmd.ExecuteNonQuery();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", syIncidents.ID);
                    return syIncidents.ID;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", syIncidents.Subject, dex.Message);
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
                    cmd.CommandText = "uspsyIncidentsDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", syIncidents.ID);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    cmd.ExecuteNonQuery();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {syIncidents.ID} is Deleted Scussefully  ");// );
                    return true;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {syIncidents.ID} is was not Deleted with Error {dex.Message}  ");//;syIncidents.Subject, dex.Message);
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
                    cmd.CommandText = "uspsyIncidentsDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.ExecuteNonQuery();
                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {id} is Deleted Scussefully  ");// syIncidents.ID);
                    return true;
                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {id} is was not Deleted with Error {dex.Message}  ");//;syIncidents.Subject, dex.Message);
                GlobalError = dex.Message;
                return false;
            }
        }

        #endregion CRUD
    }

    #endregion create metModelviewa class

    #region Searching and listing class datalist amnd autocomplete

    public class syIncidentsDatalist : ALookup<tblsyIncidents>
    {
        public syIncidentsDatalist(Boolean multi = false)
        {
            //


            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "Subject";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tblsyIncidents> GetModels()
        {
            IQueryable<tblsyIncidents> listing = new syIncidentsVM().GetAll().AsQueryable();

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