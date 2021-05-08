using Core_WebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_WebApp.Models;
using Core_WebApp.Services;

namespace Core_WebApp
{
	public class Startup
	{
		/// <summary>
		/// The ICOnfiguration interface is used to load the appsettings.json file for
		/// all application level settings
		/// </summary>
		/// <param name="configuration"></param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// USed to define Dependencies instances aka global services in Hosting Env.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));

			// Register the DbContext for APplication Data Access

			services.AddDbContext<SyncAppDbContext>(options=> {
				options.UseSqlServer(Configuration.GetConnectionString("SyncAppDbContext"));
			});

			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();

			// Custom and Addon Service Registration
			services.AddScoped<IService<Category, int>, CategoryService>();

			// ASP.NET Core ECoSystem Service Registration
			services.AddRazorPages();
			services.AddControllers()
					.AddJsonOptions(option=> {
						option.JsonSerializerOptions.PropertyNamingPolicy = null;
					}); // api
		//	services.AddControllersWithViews(); // MVC Views and API
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		// The Actual Request Processing Method
		// IApplicationBuilder interface, the contract for managing all middlewares(?)
		// IWebHostEnvironment, responsible to read Host Cofiguration e.g. Reverse Proxy and DB Connection Impersanation
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				// standard error page for Dev. Time  Running Exception 
				app.UseDeveloperExceptionPage();
				// Standard Database Error page
				app.UseDatabaseErrorPage();
			}
			else
			{
				// Dev. Defined Exception Page
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers(); // Mapping the EndPoint for API Controllers
			});
		}
	}
}
