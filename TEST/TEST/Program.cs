using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TEST.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MVCDemoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MvcDemoConnectioString")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Name = "test";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    //使用者會以Sliding運作，當使用者活躍時令牌效用就會延長。禁用滑動過期。這意味著一旦令牌過期，就需要重新獲取一個令牌來使用網站
    options.SlidingExpiration = false;
    options.LoginPath = "/Employees/Login";
    options.LogoutPath = "/Employees/Logout";
    options.AccessDeniedPath = "/Home/AccessDenied";
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

app.UseRouting();
//下面兩行順序要正確
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
