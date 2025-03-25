using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CustomI.Sample.CustomUserManagement.Data;
using CustomI.Sample.CustomUserManagement.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CustomISampleCustomUserManagementContextConnection") ?? throw new InvalidOperationException("Connection string 'CustomISampleCustomUserManagementContextConnection' not found.");;

builder.Services.AddDbContext<CustomISampleCustomUserManagementContext>(options => options.UseSqlServer(connectionString));
//scaffoldad identity 
builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CustomISampleCustomUserManagementContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
