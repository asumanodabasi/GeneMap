using GeneMap.BLL.Data;
using GeneMap.BLL.Data.Entities;
using GeneMap.BLL.Repo;
using GeneMap.WebUI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

#region Localizer
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources");
builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options=>
options.DataAnnotationLocalizerProvider = (type, factory) =>
{
    var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
    return factory.Create(nameof(SharedResource), assemblyName.Name);
});
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR")
    };
    options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
    options.SupportedCultures=supportCultures;
    options.SupportedUICultures=supportCultures;
    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider()); 
});
#endregion
// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSwaggerGen();
//builder.Services.AddEndpointsApiExplorer();
//cookiee
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(props =>
{
    props.Cookie.Name = "GeneMap.Auth";
    props.LoginPath = "/Auth/Login";
    props.AccessDeniedPath = "/Auth/Login";
    props.LogoutPath = "/Auth/Logout";
});

builder.Services.AddDbContext<PatientDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
   // options.SignIn.RequireConfirmedEmail = true; //email onaylý mý deðil mi bakar
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
}).AddEntityFrameworkStores<PatientDataContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<PatientRepo>();
builder.Services.AddScoped<PatientRelativeRepo>();
builder.Services.AddScoped<DoctorRepo>();
builder.Services.AddScoped<IlnessRepo>();
builder.Services.AddScoped<DiagnosisRepo>();   

var app = builder.Build();
//app.UseSwagger();
//app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var srv = scope.ServiceProvider;
    var context = srv.GetRequiredService<PatientDataContext>();
    context.Database.Migrate();
}
app.Run();

