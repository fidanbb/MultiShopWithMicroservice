using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShopWithMicroservice.WebUI.Extensions;
using MultiShopWithMicroservice.WebUI.Handlers;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.CategoryServices;
using MultiShopWithMicroservice.WebUI.Services.Concrete;
using MultiShopWithMicroservice.WebUI.Services.Interfaces;
using MultiShopWithMicroservice.WebUI.Settings;
using NToastNotify;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
	opt.LoginPath = "/Login/Index";
	opt.LogoutPath = "/Login/Logout";
	opt.AccessDeniedPath = "/Pages/AccessDenied";
	opt.Cookie.SameSite = SameSiteMode.Strict;
	opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
	opt.Cookie.Name = "MultishopJwt";
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
	opt.LoginPath = "/Login/Index";
	opt.ExpireTimeSpan = TimeSpan.FromDays(5);
	opt.Cookie.Name = "MultishopCookie";
	opt.SlidingExpiration = true;
});


// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews()
     .AddNToastNotifyToastr(new ToastrOptions()
     {
         ProgressBar = true,
         PositionClass = ToastPositions.TopRight,
         TimeOut = 5000
     })
    .AddRazorRuntimeCompilation();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection(nameof(ClientSettings)));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));


builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddAccessTokenManagement();
builder.Services.AddHttpClientServices(builder.Configuration);



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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
