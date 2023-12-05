
using Microsoft.AspNetCore.Mvc.Rendering;
using NLog;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using LogLevel = NLog.LogLevel;

namespace Global.Models
{
    public class BaseVM
    {
        //dependency injection stuff to weok on 
        //public static IConfiguration Configuration { get; set; }
        //private readonly UserManager<ApplicationUser> _userManager;
        // public dynamic appSettings = new Utils.AppSettingsData();
        public static Logger logger = LogManager.GetLogger("dblogger");

        public String? strConnection = SiteUtils.strConnection;
        public String? GlobalError = null;
        public String? LogonUser = SiteUtils.LoggedInUser;


    }

    public class DateFunctions
    {

        /// <summary>
        /// to use specail details about dates like month nmes and week days 
        /// usage as below 
        /// </summary>
        //<select asp-for="WeekDay" class="form-control chosen-select "
        //   asp-items="new DateFunctions().DaysNames">
        //   <option disabled selected value="">--- @Localizer["PleaseSelect"] ---</option>
        // </select>

        public List<SelectListItem>? TimeZoneList = TimeZoneInfo
            .GetSystemTimeZones()
            .Select((Zones, id) => new SelectListItem
            {
                Value = Zones.Id,
                Text = Zones.DisplayName
            }).ToList();

        public System.Collections.Generic.List<SelectListItem> MonthsNames = DateTimeFormatInfo
         .CurrentInfo
         .MonthNames
         .Select((monthName, index) => new SelectListItem
         {
             Value = (index + 1).ToString(),
             Text = monthName
         }).ToList();

        public System.Collections.Generic.List<SelectListItem> DaysNames = DateTimeFormatInfo
        .CurrentInfo
        .DayNames
        .Select((dayName, index) => new SelectListItem
        {
            Value = (index + 1).ToString(),
            Text = dayName
        }).ToList();

        public System.Collections.Generic.List<SelectListItem> TimeRange = DateTimeFormatInfo
         .CurrentInfo
         .ShortTimePattern
         .Select((Time, Values) => new SelectListItem
         {
             Value = Time.ToString(),
             Text = Time.ToString()
         }).ToList();
        // Enumerable.Range(00, 24)
        //.Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString() })
        //.ToList();

        public DateFunctions()
        {

        }
        public String? GetMonthName(int id)
        {
            return GetMonthName(id.ToString());

        }
        public String? GetMonthName(string id)
        {


            var ResultOne = MonthsNames.FirstOrDefault((p) => p.Value == id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.Text;
        }


        public String? GetDaysName(int id)
        {
            return GetDaysName(id.ToString());

        }
        public String? GetDaysName(string id)
        {

            var ResultOne = DaysNames.FirstOrDefault((p) => p.Value == id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.Text;
        }

        public DateTime GetLastYearDay()
        {
            return new DateTime(DateTime.Now.Year, 12, 31);
        }

        public enum TimeSlide { Hour = 60, HalfHour = 30, QuarterHour = 15 };
        public enum TimeFormat { Time24 = 24, Time12 = 12 };
        public IEnumerable<SelectListItem> ListOfTimeIntervals
        {
            get
            {
                var list = new List<SelectListItem>();
                // range of hours, multiplied by 4 (e.g. 24 hours = 96)
                int timeRange = 96;

                // range of minutes, e.g. 15 min
                int minuteRange = 15;

                // starting time, e.g. 0:00
                TimeSpan startTime = new TimeSpan(0, 0, 0);

                // placeholder
                list.Add(new SelectListItem { Text = "Choose a time", Value = "0", Disabled = true });

                // get standard ticks
                DateTime startDate = new DateTime(DateTime.MinValue.Ticks);

                // create time format based on range above
                for (int i = 0; i < timeRange; i++)
                {
                    int minutesAdded = minuteRange * i;
                    TimeSpan timeAdded = new TimeSpan(0, minutesAdded, 0);
                    TimeSpan tm = startTime.Add(timeAdded);
                    DateTime result = startDate + tm;

                    list.Add(new SelectListItem { Text = result.ToString("HH:mm"), Value = result.ToString("HH:mm") });
                }

                return list;
            }
        }



    }




    #region lookup table  class 

    /// <summary>
    /// lookup table for usage as geenric lookup for list box details
    /// has only id and name 
    /// </summary>
    /// 
    public class tblLookups
    {

        [Display(Name = "lookup-ID", Description = "lookup-ID.")]
        [Key]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ID { get; set; }

        [Display(Name = "lookup-Name", Description = "lookup-Name.")]

        public String? Name { get; set; }

        [Display(Name = "lookup-lookupName", Description = "lookup-lookupName.")]

        public String? lookupName { get; set; }


    }
    #endregion


    #region create year table  class 
    public class tblYears
    {

        [Display(Name = "clServices-FromYear ", Description = "clServices-From Year .")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 FromYear { get; set; }


        [Display(Name = "clServices-Toear ", Description = "clServices-To Year .")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ToYear { get; set; }

        [Display(Name = "clServices-ExtraPercent1", Description = "clServices-ExtraPercent1.")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Decimal ExtraPercent1 { get; set; }

        [Display(Name = "clServices-ExtraPercent2", Description = "clServices-ExtraPercent2.")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Decimal ExtraPercent2 { get; set; }



    }
    #endregion

}