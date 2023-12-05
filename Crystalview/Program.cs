using Global.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;

//using WebApiContrib.Core.Formatter.Csv;

#region initialte logger  custom exception handling error

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
#endregion using custom exception handling error


var builder = WebApplication.CreateBuilder(args);

#region use NLog  custom exception handling error
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
#endregion

#region set my varuables all over the site

var WebRootPath = builder.Environment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
SiteUtils.SettingsLocation = Path.Combine(WebRootPath, "Settings").Replace(@"\", "/"); ;
SiteUtils.GeneralConnection = builder.Configuration.GetConnectionString("DefaultConnection");
SiteUtils.strConnection = builder.Configuration.GetConnectionString("DefaultConnection");
SiteUtils.AppName = builder.Configuration.GetValue<string>("AppName");
SiteUtils.SiteConfig = builder.Configuration.GetValue<string>("SiteConfig");
SiteUtils.HostingEnvironment = builder.Environment;
WTEG.Core.Utils.strConnection = SiteUtils.strConnection;
WTEG.Core.Utils.strLocalizationConnection = builder.Configuration.GetConnectionString("LocalizationConnection");
WTEG.Core.Utils.strIdentityConnection = builder.Configuration.GetConnectionString("IdentityConnection");

#endregion set my varuables all over the site


#region injection for controller methods f=data in all site
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddSingleton<LocalizationModelContext, LocalizationModelContext>();
#endregion

#region cookies general options

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential
    // cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    // requires using Microsoft.AspNetCore.Http;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

#endregion cookies general options



#region localization settings
builder.Services.AddControllersWithViews()
       .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-Us"),
        new CultureInfo("ar-EG")
    };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedUICultures = supportedCultures;
});

//app.UseRequestLocalization();

//builder.Services.AddControllersWithViews()
//.AddNewtonsoftJson()
//.AddViewLocalization()
//.AddDataAnnotationsLocalization()
//.AddRazorRuntimeCompilation()
//;

//builder.Services.AddRazorPages();

#endregion localization settings




//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<ApplicationDbContext>();



#region identity settings



// Add framework services.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddScoped<SignInManager<ApplicationUser>, ApplicationSignInManager>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationClaimsPrincipalFactory>();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    //options.Password.RequiredUniqueChars = 6;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.RequireUniqueEmail = true;

    // Default SignIn settings.
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});

//nulling out the security stamp validator logic to see if that fixes the issue to start:
//services.ConfigureApplicationCookie(o => o.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents());
//services.Configure<SecurityStampValidatorOptions>(options =>
//{ enables immediate logout, after updating the user's stat.
//    options.ValidationInterval = TimeSpan.FromSeconds(12);
//});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    //options.Cookie.Name = "YourAppCookieName";
    //options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.Cookie.HttpOnly = true;
    //ExpireTimeSpan = TimeSpan.FromMinutes(Int32.Parse(Configuration.GetSection("AppSettings:CookieAuthentication:ExpireMinutes").Value)
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Accounts/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
    options.LogoutPath = "/Accounts/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
    options.AccessDeniedPath = "/Accounts/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
});

////Add application services.


#endregion identity settings


var app = builder.Build();
// Add services to the container.

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    //app.UseMigrationsEndPoint();
//}
//else
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseRequestLocalization();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.Run();
