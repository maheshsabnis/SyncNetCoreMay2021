using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebApp.Models
{
	public class RegisterUser
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string ConfirmPasword { get; set; }
	}

	public class LoginUser
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
	}

	public class ResponseData
	{
		public string Message { get; set; }
	}
}
