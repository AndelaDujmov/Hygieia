using HygieiaApp;
using HygieiaApp.DataAccess.Data;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models.Models;
using HygieiaApp.Utility.Utils.Email;
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

builder.Services.AddIdentity<IdentityUser, IdentityRole>(/*options => options.SignIn.RequireConfirmedAccount = true*/)
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMedicineForConditionRepository, MedicineForConditionRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<AdminService>();
builder.Services.AddTransient<PatientService>();
builder.Services.AddTransient<DoctorService>();

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

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Patient}/{controller=Home}/{action=Index}/{id?}");

app.Run();