using Core_WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_WebApp.Models;

namespace Core_WebApp.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly AuthService _service;
		public AuthController(AuthService service)
		{
			_service = service;
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterUser user)
		{
			if (ModelState.IsValid)
			{
				var isUserCreated = await _service.RegisterUserAsync(user);
				if (isUserCreated == false)
				{
					return Conflict("This user is already registered");
				}
				var response = new ResponseData()
				{
					Message = $"The User Registered Successfully {user.Email}"
				};
				return Ok(response);
			}
			return BadRequest(ModelState);
		}

		[HttpPost]
		public async Task<IActionResult> Auth(LoginUser user)
		{
			if (ModelState.IsValid)
			{
				var authToken = await _service.AuthenticateUser(user);
				if (authToken == null)
				{
					return Unauthorized("Login Failed");
				}
				var response = new ResponseData()
				{
					Message =  authToken
				};
				return Ok(response);
			}
			return BadRequest(ModelState);
		}
	}
}
