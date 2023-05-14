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
    //�ϥΪ̷|�HSliding�B�@�A��ϥΪ̬��D�ɥO�P�ĥδN�|�����C�T�ηưʹL���C�o�N���ۤ@���O�P�L���A�N�ݭn���s����@�ӥO�P�Өϥκ���
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
//�U����涶�ǭn���T
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
