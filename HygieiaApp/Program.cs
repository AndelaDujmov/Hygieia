using HygieiaApp;
using HygieiaApp.DataAccess.Data;
using HygieiaApp.DataAccess.DbInitializer;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL("server=localhost;database=hygieia;uid=root;pwd=andu404595;"));


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(200);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMedicineForConditionRepository, MedicineForConditionRepository>();
builder.Services.AddTransient<AdminService>();
builder.Services.AddTransient<PatientService>();
builder.Services.AddTransient<DoctorService>();
builder.Services.AddScoped<IDbInitalizer, DbInitializer>();

builder.Services.AddDataProtection()
    .SetApplicationName("HygieiaApp")
    .AddKeyManagementOptions(options =>
    {
        options.NewKeyLifetime = new TimeSpan(180, 0, 0, 0);
        options.AutoGenerateKeys = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
SeedDb();
app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Patient}/{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDb()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInit = scope.ServiceProvider.GetRequiredService<IDbInitalizer>();
        dbInit.Initialize();
    }
}