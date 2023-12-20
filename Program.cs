using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nupat_MVC_Identity.Data;
using Nupat_MVC_Identity.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionKey = builder.Configuration.GetConnectionString("DataConnection") ?? "dhdhdh";
builder.Services.AddDbContext<DataContext>(options =>
options.UseMySql(connectionKey,
ServerVersion.AutoDetect(connectionKey)));

//Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedEmail = false;
}
).AddDefaultTokenProviders().AddDefaultUI().AddEntityFrameworkStores<DataContext>();



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
app.MapRazorPages();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
