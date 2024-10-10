using Company_System.BLL.Manager;
using Company_System.DAL.Models;
using Company_System.DAL.Repository;
using Company_System.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Company_System
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

	
            builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();
			builder.Services.AddDbContext<Company_SystemContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
			});

            builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
            builder.Services.AddScoped<IAccountManager, AccountManager>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Company_SystemContext>();

            builder.Services.AddSession();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseSession();
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Account}/{action=Register}/{id?}");

			app.Run();
		}
	}
}