using Global.DBModels;
using Global.Globalization;
using Global.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Runtime.Loader;
using System.Security.Claims;
using WTEG.Core;


namespace Global.Models
{
    public static class SiteUtils
    {
        public static string CipherKey => "l8cpD27QcWDXjAg8ut+qH0IkWv/p38DrAst4Ee83jMg=";
        public static IWebHostEnvironment HostingEnvironment { get; set; }
        public static string AppName { get; set; }

        public static string SettingsLocation { get; set; }

        public static string SiteConfig { get; set; }

        public static string strConnection { get; set; }

        public static string NLOGConnection { get; set; }

        public static string GeneralConnection { get; set; }

        public static string CultureCookieName { get; set; }

        public static string LoggedInUser { get; set; }

        public static int ActiveMenu { get; set; }

        public static string DefaultCulture { get; set; }

        public static string ApplicationVersion
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                DateTime buildDate = new DateTime(2000, 1, 1)
                                        .AddDays(version.Build).AddSeconds(version.Revision * 2);
                return $"{version} ";//({buildDate})
            }
        }

 

        #region language part
        public static string FixAndSetLanguage(string culture)
        {
            #region new part to avoid ne w culture issues with data and separators

            var cultureInfo = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            CultureInfo ci = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            //ci.DisplayName = "ar-Ali";
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
            ci.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = ci;
            // ci.CurrentCulture.TextInfo.IsRightToLeft = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft;
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            #endregion new part to avoid ne w culture issues with data and separators

            //CultureHelper.SetUserLocale(culture, culture);

            //var cultureInfo = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentCulture.NumberFormat.DigitSubstitution = DigitShapes.None;
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            //Thread.CurrentThread.CurrentCulture = cultureInfo;
            //Thread.CurrentThread.CurrentUICulture = cultureInfo;

            return CultureInfo.CurrentCulture.Name;
        }

        public static string SetLanguage(HttpResponse Response, string culture = "ar-EG")
        {
            Response.Cookies.Append(
                //SiteUtils.CultureCookieName,
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture ?? "ar-eg")),
                new CookieOptions
                {
                    Path = "/",
                    HttpOnly = true,
                    IsEssential = true, //<- there
                    Secure = false,
                    SameSite = SameSiteMode.Lax,

                

                    Expires = DateTimeOffset.UtcNow.AddDays(15)
                }
            );

            return FixAndSetLanguage(culture);
            //return CultureInfo.CurrentCulture.Name;
            //return CultureHelper.GetCurrentCulture();
        }
        #endregion

     

     

        #region friendly error part
        public static string FriendlyErrorMessage(string Message)
        {
            var listOfStrings = new tblErrorMsgMappingVM().GetAll().ToList();

            var ErrorMessage = listOfStrings.Find(x => Message.Contains(x.OriginalError));


            if (ErrorMessage != null)
            {
                Message = ErrorMessage.ErrorMessage;
            }
            else
            {
                ErrorMessage = listOfStrings.Find(x => x.OriginalError.Contains(Message));
                if (ErrorMessage != null)
                {
                    Message = ErrorMessage.ErrorMessage;
                }
                else
                    Message = "Unknown Error ,pelase review the log";
            }
             

            if (Message.Contains("CK_ivItemBatchbal"))
                Message = "OutOfbalance";

            if (Message.Contains("FK_apPurchInvH_tblCodes"))
                Message = "MustEnterPaymentMethod";

            if (Message.Contains("CK_arSalesInvHDue"))
                Message = "InvoiceTotalCannotbeNeg";
            if (Message.Contains("OutOfbalance"))
                Message = "OutOfbalance";
            if (Message.Contains("deadlocked"))
                Message = "Deadlock";
            if (Message.Contains("The DELETE statement conflicted with the"))
                Message = "DeleteError";
            if (Message.Contains("FOREIGN KEY constraint"))
                Message = "FOREIGNKEY";
            if (Message.Contains("Cannot insert duplicate key row in object"))
                Message = "DuplicateKey";
            if (Message.Contains("Cannot insert the value NULL into column")
                |
                Message.Contains("Value cannot be null")
                )
                Message = "NullColumn";



            var value = Message;
            return value;
        }

        public static string FriendlyErrorMessage(Exception dex)
        {
            var Message = dex.Message;

            #region old code before strign new one

            //var listOfStrings = new tblErrorMsgMappingVM().GetAll().ToList();

            //var ErrorMessage = listOfStrings.Find(x => Message.Contains(x.OriginalError));

            //if (ErrorMessage != null)
            //{
            //    Message = ErrorMessage.ErrorMessage;

            //}
            //else
            //    Message = "Unknown Error ,pelase review the log";
            //#region old manual way

            ////if (Message.Contains("CK_ivItemBatchbal"))
            ////    Message = "OutOfbalance";

            ////if (Message.Contains("FK_apPurchInvH_tblCodes"))
            ////    Message = "MustEnterPaymentMethod";

            ////if (Message.Contains("CK_arSalesInvHDue"))
            ////    Message = "InvoiceTotalCannotbeNeg";
            ////if (Message.Contains("OutOfbalance"))
            ////    Message = "OutOfbalance";
            ////if (Message.Contains("deadlocked"))
            ////    Message = "Deadlock";
            ////if (Message.Contains("The DELETE statement conflicted with the"))
            ////    Message = "DeleteError";
            ////if (Message.Contains("FOREIGN KEY constraint"))
            ////    Message = "FOREIGNKEY";
            ////if (Message.Contains("Cannot insert duplicate key row in object"))
            ////    Message = "DuplicateKey";
            ////if (Message.Contains("Cannot insert the value NULL into column")
            ////    |
            ////    Message.Contains("Value cannot be null")
            ////    )
            ////    Message = "NullColumn";
            //#endregion

            //var value = new tblLocalizationRecordsVM().GetResourceValue(Message, "ErrorMsg");

            #endregion old code before strign new one

            return FriendlyErrorMessage(Message);
        }

        public static List<string> GetModelErrros(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.Where(E => E.Errors.Count > 0)
                         .SelectMany(E => E.Errors)
                         .Select(E => E.ErrorMessage)
                         .ToList();

            return errors;
        }

        #endregion



        #region create user stuff

        public static async Task<bool> AddUser(UserViewModel model, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                Culture = model.Culture,
                IsEnabled = true
            };

            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                foreach (var role in model.userRoles)
                {
                    ApplicationRole applicationRole = await roleManager.FindByIdAsync(role);
                    if (applicationRole != null)
                    {
                        IdentityResult roleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                    }
                }

                #region calims add part

                // add the claims to keep data in claim part
                await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.GivenName, user.FullName));
                //get the first name out of full anme
                var Nickname = !String.IsNullOrWhiteSpace(user.FullName) && user.FullName.IndexOf(" ") > 0
                    ? user.FullName.Substring(0, user.FullName.IndexOf(" "))
                    : user.FullName;
                await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.NickName, Nickname));
                await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.Culture, user.Culture));
                await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.AvatarURL, user.AvatarURL));
                await userManager.AddClaimAsync(user, new Claim("IsEnabled", "true"));

                #endregion calims add part

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Generates a Random Password
        /// respecting the given strength requirements.
        /// </summary>
        /// <param name="opts">A valid PasswordOptions object
        /// containing the password strength requirements.</param>
        /// <returns>A random password</returns>
        public static string GenerateRandomPassword(PasswordOptions? opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        #endregion create user stuff

        #region Gets the build date and time (by reading the COFF header)

        // http://msdn.microsoft.com/en-us/library/ms680313

        //struct _IMAGE_FILE_HEADER
        //{
        //    public ushort Machine;
        //    public ushort NumberOfSections;
        //    public uint TimeDateStamp;
        //    public uint PointerToSymbolTable;
        //    public uint NumberOfSymbols;
        //    public ushort SizeOfOptionalHeader;
        //    public ushort Characteristics;
        //};

        //static DateTime GetBuildDateTime(Assembly assembly)
        //{
        //    //var path = assembly.GetName().CodeBase;
        //    //if (File.Exists(path))
        //    //{ var buffer = new byte[Math.Max(Marshal.SizeOf(typeof(_IMAGE_FILE_HEADER)), 4)]; using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read)) { fileStream.Position = 0x3C; fileStream.Read(buffer, 0, 4); fileStream.Position = BitConverter.ToUInt32(buffer, 0); // COFF header offset fileStream.Read(buffer, 0, 4); // "PE\0\0" fileStream.Read(buffer, 0, buffer.Length); } var pinnedBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned); try { var coffHeader = (_IMAGE_FILE_HEADER)Marshal.PtrToStructure(pinnedBuffer.AddrOfPinnedObject(), typeof(_IMAGE_FILE_HEADER)); return TimeZoneInfo.  .CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1) + new TimeSpan(coffHeader.TimeDateStamp * TimeSpan.TicksPerSecond)); } finally { pinnedBuffer.Free(); }
        //    //}
        //    //return new DateTime();
        //}

        #endregion Gets the build date and time (by reading the COFF header)


    }

    #region constyants

    // file part constants for all site wide process
    public static class Constants
    {
        public static string tempPath = "~/SavedPDF/";
        public static string HelpPath = "HelpFiles";
        public static string serverMapPath = "SavedPDF";
        public static string UrlBase = "/SavedPDF/";
        public static string DeleteURL = "/Utils/FileUpload/DeleteFile/?file=";
        public static string DeleteType = "GET";
        public static string StorageRoot;
    }

    #endregion constyants

    #region site settings management

    public class SiteSettings
    {
        #region compnaydata

        private string _ShortName;

        public String? ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value; }
        }

        private string _LongName;

        public String? LongName
        {
            get { return _LongName; }
            set { _LongName = value; }
        }

        private string _LogoPath;

        public String? LogoPath
        {
            get { return _LogoPath; }
            set { _LogoPath = value; }
        }

        private string _SocialInsNumber;

        public String? SocialInsNumber
        {
            get { return _SocialInsNumber; }
            set { _SocialInsNumber = value; }
        }

        private string _SocialZone;

        public String? SocialZone
        {
            get { return _SocialZone; }
            set { _SocialZone = value; }
        }

        private string _Director;

        public String? Director
        {
            get { return _Director; }
            set { _Director = value; }
        }

        private string _Address;

        public String? Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _LegalEntity;

        public String? LegalEntity
        {
            get { return _LegalEntity; }
            set { _LegalEntity = value; }
        }

        private double _OverTimeMax;

        public double OverTimeMax
        {
            get { return _OverTimeMax; }
            set { _OverTimeMax = value; }
        }

        private bool _isParent;

        public bool IsParent
        {
            get { return _isParent; }
            set { _isParent = value; }
        }

        private Boolean _ShowIDS;

        public Boolean ShowIDS
        {
            get { return _ShowIDS; }
            set { _ShowIDS = value; }
        }

        #endregion compnaydata

        #region working data

        private short _WeekStartDay;

        public short WeekStartDay
        {
            get { return _WeekStartDay; }
            set { _WeekStartDay = value; }
        }

        private short _WorkingDaysWeekly;

        public short WorkingDaysWeekly
        {
            get { return _WorkingDaysWeekly; }
            set { _WorkingDaysWeekly = value; }
        }

        private short _WorkingHouseDaily;

        public short WorkingHouseDaily
        {
            get { return _WorkingHouseDaily; }
            set { _WorkingHouseDaily = value; }
        }

        private string _StartingHour;

        public String? StartingHour
        {
            get { return _StartingHour; }
            set { _StartingHour = value; }
        }

        private string _EndingHour;

        public String? EndingHour
        {
            get { return _EndingHour; }
            set { _EndingHour = value; }
        }

        private int _WorkingDaysMonthly;

        public int WorkingDaysMonthly
        {
            get { return _WorkingDaysMonthly; }
            set { _WorkingDaysMonthly = value; }
        }

        private bool _Sun;

        public bool Sun
        {
            get { return _Sun; }
            set { _Sun = value; }
        }

        private bool _Mon;

        public bool Mon
        {
            get { return _Mon; }
            set { _Mon = value; }
        }

        private bool _Tue;

        public bool Tue
        {
            get { return _Tue; }
            set { _Tue = value; }
        }

        private bool _Wed;

        public bool Wed
        {
            get { return _Wed; }
            set { _Wed = value; }
        }

        private bool _Thu;

        public bool Thu
        {
            get { return _Thu; }
            set { _Thu = value; }
        }

        private bool _Fri;

        public bool Fri
        {
            get { return _Fri; }
            set { _Fri = value; }
        }

        private bool _Sat;

        public bool Sat
        {
            get { return _Sat; }
            set { _Sat = value; }
        }

        #endregion working data

        #region password

        private bool _ShowPassword;

        public bool ShowPassword
        {
            get { return _ShowPassword; }
            set { _ShowPassword = value; }
        }

        private short _PasswordDays;

        public short PasswordDays
        {
            get { return _PasswordDays; }
            set { _PasswordDays = value; }
        }

        #endregion password

        #region site settings

        private string _SiteUrl;

        public String? SiteUrl
        {
            get { return _SiteUrl; }
            set { _SiteUrl = value; }
        }

        private string _TextLogFilePath;

        public String? TextLogFilePath
        {
            get { return _TextLogFilePath; }
            set { _TextLogFilePath = value; }
        }

        private string _UploadDirectoryPath;

        public String? UploadDirectoryPath
        {
            get { return _UploadDirectoryPath; }
            set { _UploadDirectoryPath = value; }
        }

        private string _serverPhotoUploadDirectory;

        public String? ServerPhotoUploadDirectory
        {
            get { return _serverPhotoUploadDirectory; }
            set { _serverPhotoUploadDirectory = value; }
        }

        private string _UploadMailAttatchements;

        public String? UploadMailAttatchements
        {
            get { return _UploadMailAttatchements; }
            set { _UploadMailAttatchements = value; }
        }

        private string _SiteName;

        public String? SiteName
        {
            get
            {
                return _SiteName;
            }
            set
            {
                lock (this)
                {
                    _SiteName = value;
                }
            }
        }

        private string _LeftTheme;

        public String? LeftTheme
        {
            get { return _LeftTheme; }
            set { _LeftTheme = value; }
        }

        private string _RightTheme;

        public String? RightTheme
        {
            get { return _RightTheme; }
            set { _RightTheme = value; }
        }

        private string _DefaultTheme;

        public String? DefaultTheme
        {
            get { return _DefaultTheme; }
            set { _DefaultTheme = value; }
        }

        private string _DefaultCulture;

        public String? DefaultCulture
        {
            get { return _DefaultCulture; }
            set { _DefaultCulture = value; }
        }

        private short _DefaultMenuExpand;

        public short DefaultMenuExpand
        {
            get { return _DefaultMenuExpand; }
            set { _DefaultMenuExpand = value; }
        }

        #endregion site settings

        #region email

        private string _SiteEmailAddress;

        public String? SiteEmailAddress
        {
            get
            {
                return _SiteEmailAddress;
            }
            set
            {
                lock (this)
                {
                    _SiteEmailAddress = value;
                }
            }
        }

        public String? SiteEmailFromField
        {
            get
            {
                return String.Format("{0} <{1}>", _SiteName, _SiteEmailAddress);
            }
        }

        private string _SMTPServerName;

        public String? SMTPServerName
        {
            get { return _SMTPServerName; }
            set { _SMTPServerName = value; }
        }

        private string _SMTPServerUser;

        public String? SMTPServerUser
        {
            get { return _SMTPServerUser; }
            set { _SMTPServerUser = value; }
        }

        private string _SMTPServerPassword;

        public String? SMTPServerPassword
        {
            get { return _SMTPServerPassword; }
            set { _SMTPServerPassword = value; }
        }

        private string _SMTPServerPort;

        public String? SMTPServerPort
        {
            get { return _SMTPServerPort; }
            set { _SMTPServerPort = value; }
        }

        private string _PasswordMail;

        public String? PasswordMail
        {
            get { return _PasswordMail; }
            set { _PasswordMail = value; }
        }

        private string _InfoMail;

        public String? InfoMail
        {
            get { return _InfoMail; }
            set { _InfoMail = value; }
        }

        private string _TransferEmail;

        public String? TransferEmail
        {
            get { return _TransferEmail; }
            set { _TransferEmail = value; }
        }

        private string _WithDrawEmail;

        public String? WithDrawEmail
        {
            get { return _WithDrawEmail; }
            set { _WithDrawEmail = value; }
        }

        private string _PersonalInfoEmail;

        public String? PersonalInfoEmail
        {
            get { return _PersonalInfoEmail; }
            set { _PersonalInfoEmail = value; }
        }

        private string _DepositEmail;

        public String? DepositEmail
        {
            get { return _DepositEmail; }
            set { _DepositEmail = value; }
        }

        private string _ComplaintEmail;

        public String? ComplaintEmail
        {
            get { return _ComplaintEmail; }
            set { _ComplaintEmail = value; }
        }

        private string _OpenAccountEmail;

        public String? OpenAccountEmail
        {
            get { return _OpenAccountEmail; }
            set { _OpenAccountEmail = value; }
        }

        #endregion email

        #region roles

        private string _AdminRoleName;

        public String? AdminRoleName
        {
            get { return _AdminRoleName; }
            set { _AdminRoleName = value; }
        }

        private string _UserRoleName;

        public String? UserRoleName
        {
            get { return _UserRoleName; }
            set { _UserRoleName = value; }
        }

        #endregion roles

        #region polls

        private int _VotingLockInterval;

        public int VotingLockInterval
        {
            get { return _VotingLockInterval; }
            set { _VotingLockInterval = value; }
        }

        private bool _VotingLockByCookie;

        public bool VotingLockByCookie
        {
            get { return _VotingLockByCookie; }
            set { _VotingLockByCookie = value; }
        }

        private bool _VotingLockByIP;

        public bool VotingLockByIP
        {
            get { return _VotingLockByIP; }
            set { _VotingLockByIP = value; }
        }

        private bool _ArchiveIsPublic;

        public bool ArchiveIsPublic
        {
            get { return _ArchiveIsPublic; }
            set { _ArchiveIsPublic = value; }
        }

        private bool _EnableCaching;

        public bool EnableCaching
        {
            get { return _EnableCaching; }
            set { _EnableCaching = value; }
        }

        private int _CacheDuration;

        public int CacheDuration
        {
            get { return _CacheDuration > 0 ? _CacheDuration : 60; }
            set { _CacheDuration = value; }
        }

        #endregion polls

        #region report settings

        private string _ReportServerPath;

        public String? ReportServerPath
        {
            get { return _ReportServerPath; }
            set { _ReportServerPath = value; }
        }

        private string _DefaultReportFormat;

        public String? DefaultReportFormat
        {
            get { return _DefaultReportFormat; }
            set { _DefaultReportFormat = value; }
        }

        private bool _ReportShowToolBar;

        public bool ReportShowToolBar
        {
            get { return _ReportShowToolBar; }
            set { _ReportShowToolBar = value; }
        }

        #endregion report settings
    }

    /// <summary>
    /// Contains the implementation for the site settings.
    /// </summary>
    public class AppSiteSettings
    {
        private static string XmlConfigFile = SiteUtils.SettingsLocation + "/" + SiteUtils.SiteConfig ?? "site-config.json";

        //"~/App_Data/site-config.xml";
        private SiteSettings? Settings;

        public SiteSettings LoadFromConfiguration()
        {
            // SiteSettings Settings;//= LoadFromXml();
            Settings = JsonConvert.DeserializeObject<SiteSettings>(File.ReadAllText(XmlConfigFile));

            //if no data then se the default values
            if (Settings.AdminRoleName == null)
            {
                Settings = new SiteSettings();

                #region main compnay data

                Settings.Address = "";
                Settings.Director = "";
                Settings.LegalEntity = "";
                Settings.LogoPath = "";
                Settings.LongName = "";
                Settings.SocialInsNumber = "";
                Settings.SocialZone = "";
                Settings.IsParent = false;
                Settings.ShowIDS = false;

                #endregion main compnay data

                #region Working Date and hours

                Settings.WeekStartDay = 1;
                Settings.StartingHour = "9:00";
                Settings.EndingHour = "17:00";
                Settings.Fri = true;
                Settings.Mon = false;
                Settings.Sat = true;
                Settings.Sun = false;
                Settings.Thu = false;
                Settings.Tue = false;
                Settings.Wed = false;
                Settings.WorkingDaysMonthly = 22;
                Settings.WorkingDaysWeekly = 5;
                Settings.WorkingHouseDaily = 48;

                #endregion Working Date and hours

                #region Site Related Data

                Settings.SiteUrl = "http://localhost";
                Settings.AdminRoleName = "Admin";
                Settings.UserRoleName = "Customer";
                Settings.InfoMail = "info@Finance.com";
                Settings.PasswordDays = 30;
                Settings.ShowPassword = false;
                Settings.PasswordMail = "Password@Finance.com";
                Settings.TextLogFilePath = "~/App_Data";
                Settings.ServerPhotoUploadDirectory = "~/images/Site";
                Settings.UploadDirectoryPath = "/SavedPDF/";
                Settings.UploadMailAttatchements = "~/App_Data/MailAttatchements";
                Settings.SiteEmailAddress = "Site@Finance.com";

                Settings.SiteName = "Finance";
                Settings.SMTPServerName = "mail.Finance.com";
                Settings.SMTPServerPassword = "Passw0rd";
                Settings.SMTPServerUser = "password@Finance.com";
                Settings.SMTPServerPort = "587";

                Settings.TransferEmail = "Transfer@Finance.com";
                Settings.WithDrawEmail = "WithDraw@Finance.com";
                Settings.PersonalInfoEmail = "PersonalInfo@Finance.com";
                Settings.DepositEmail = "Deposit@Finance.com";
                Settings.ComplaintEmail = "Complaint@Finance.com";
                Settings.OpenAccountEmail = "PersonalInfo@Finance.com";

                Settings.LeftTheme = "Red-e";
                Settings.RightTheme = "Red-a";
                Settings.DefaultTheme = "Red-a";
                Settings.DefaultCulture = "ar-EG";

                Settings.DefaultMenuExpand = 10;

                #endregion Site Related Data

                #region poll

                Settings.VotingLockInterval = 15;
                Settings.VotingLockByCookie = true;
                Settings.VotingLockByIP = false;
                Settings.ArchiveIsPublic = true;
                Settings.EnableCaching = false;
                Settings.CacheDuration = 60;

                #endregion poll

                #region report related

                Settings.ReportServerPath = "http://localhost/ReportServer";
                Settings.DefaultReportFormat = "PDF";
                Settings.ReportShowToolBar = false;

                #endregion report related

                SaveSettings(Settings);
            }

            //Constants.serverMapPath =
            //Constants.UrlBase = Settings.UploadDirectoryPath;
            return Settings;
        }

        public bool UpdateSettings(SiteSettings settings)
        {
            // write settings to code or db

            // Serialize to Xml Config File
            return SaveSettings(settings);
            // Utils.DoMsg(null, "-30", GetAsString(Settings), "UpdateSettings()", true, false);
            //return true;
        }

        private static bool SaveSettings(SiteSettings settings)
        {
            if (settings == null)
                return false;

            JsonSerializer serializer = new JsonSerializer();

            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(XmlConfigFile))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, settings);
                // {"ExpiryDate":new Date(1230375600000),"Price":0}
            }

            return true;
        }
    }

    #endregion site settings management




}