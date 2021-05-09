using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core_WebApp.CsutomMiddleware
{
	/// <summary>
	/// The Class that will be used to contain the information of Error Response
	/// </summary>
	public class ErrorResponse
	{
		public int ErrorCode { get; set; }
		public string ErrorMessage { get; set; }
	}

	/// <summary>
	///  The Custom Middleware class
	/// </summary>
	public class ExceptionMiddleware
	{
		private RequestDelegate _next;
		/// <summary>
		/// The RequestDelegate injection will help the class to be loaded in HTTP 
		/// pipleine for the execution
		/// </summary>
		/// <param name="next"></param>
		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		/// <summary>
		/// Method that contains logic for middleware
		/// </summary>
		/// <returns></returns>
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				// if not exception thej continue to the next middleware
				await _next(context);
			}
			catch (Exception ex)
			{
				// handle the exeception and generate the Custom Error Response
				// defing the Custom Error code for the response
				context.Response.StatusCode = 500;
				// read the Error Message
				string message = $"Error Occured while processing the request {ex.Message}";
				// format the response
				var errorResponse = new ErrorResponse()
				{ 
				  ErrorCode = context.Response.StatusCode,
				  ErrorMessage = message
				};

				// write the response in JSON format 
				var response = JsonSerializer.Serialize(errorResponse);
				// write the response
				await context.Response.WriteAsync(response);
			}
		}
	}

	/// <summary>
	/// The class that contains an extension method to register the Custom Middleware class
	/// in pipeline
	/// </summary>
	public static class CustomMiddleware
	{
		public static void UseErrorMiddleware(this IApplicationBuilder builder)
		{
			// The TMiddleware is currently typed to ExceptionMiddleware class which is
			// the cusom middleware
			builder.UseMiddleware<ExceptionMiddleware>();
		}
	}

}
