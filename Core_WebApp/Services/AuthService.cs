using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_WebApp.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Core_WebApp.Services
{
	public class AuthService
	{
		IConfiguration _configuration;
		SignInManager<IdentityUser> _signInManager;
		UserManager<IdentityUser> _userManager;

		public AuthService(SignInManager<IdentityUser> signInManager,
		UserManager<IdentityUser> userManager, IConfiguration configuration
			)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_configuration = configuration;
		}


		public async Task<bool> RegisterUserAsync(RegisterUser user)
		{
			var registerUser = new IdentityUser() { UserName = user.Email, Email = user.Email};

			var res = await _userManager.CreateAsync(registerUser, user.Password);
			if (res.Succeeded)
			{
				return true;
			}
			return false;
		}

		public async Task<string> AuthenticateUser(LoginUser user)
		{
			string jwtToken = "";

			// authenticate user
			var res = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, 
				 false, lockoutOnFailure: false);

			// if login is successful then issue token
			if (res.Succeeded)
			{
				// read the secret key
				var secretKey = Convert.FromBase64String(_configuration["JWTSettings:SecretKey"]);
				var expiry = Convert.ToInt32(_configuration["JWTSettings:ExpiryInMinuts"]);

				// create an IdentityUser object to create a token with the identity object as payload
				IdentityUser idUser = new IdentityUser(user.UserName);

				// define a token metadata

				var tokenMetadata = new SecurityTokenDescriptor()
				{
					Issuer = null,
					Audience = null,
					// claim in Payload of the token 
					Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>() {
						new Claim("username", idUser.Id.ToString())
					}),
					Expires = DateTime.UtcNow.AddMinutes(expiry),
					IssuedAt = DateTime.UtcNow,
					NotBefore = DateTime.UtcNow,
					// Signeture
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),
					SecurityAlgorithms.HmacSha256Signature)
				};

				// generate token using the metadata
				var tokenandler = new JwtSecurityTokenHandler();
				var token = tokenandler.CreateJwtSecurityToken(tokenMetadata);
				jwtToken = tokenandler.WriteToken(token);

			}
			else
			{
				jwtToken = "Login is Failed please check credentials";
			}

			return jwtToken;
		}
	}
}
