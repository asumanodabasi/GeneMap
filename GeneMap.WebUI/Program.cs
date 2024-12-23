using GeneMap.BLL.Data;
using GeneMap.BLL.Data.Entities;
using GeneMap.BLL.Repo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
