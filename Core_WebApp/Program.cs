using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}
		/// <summary>
		/// Entry point for ASP.NET Core Hosting Environment(?)
		/// Manage an execution of Request using Following Objects
		/// 1. Initialize the Depedenency Extesions
		///		- DBContext Pools
		///		- Identity Env.
		///		- Custom Services
		///			- Deveoper Logical Code
		///		- Sessions
		///		- CORS
		///		- Request Processing Filters
		///			- Razor Veiws
		///			- MVC COntrollers and API
		///			- Only For API
		///	2. RequestDelegate Instance inside the HttPContext 	(Middlewares)	
		///		- Auth. Check
		///		- Exception Object Initialization
		///		- Session Mgmt
		///		- CORS
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					// UseStartup() extension method injects the IConfiguration in the AStartup class  
					webBuilder.UseStartup<Startup>();
				});
	}
}
