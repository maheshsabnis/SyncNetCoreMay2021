using Core_WebApp.Models;
using Core_WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebApp.Controllers
{
	[Route("api/[controller]")]
	 [ApiController]
	public class CategoryAPIController : ControllerBase
	{
		private IService<Category, int> _catService;
		public CategoryAPIController(IService<Category, int> catService)
		{
			_catService = catService;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var result = await _catService.GetAsync();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var result = await _catService.GetAsync(id);
			return Ok(result);
		}
		/// <summary>
		/// FromBody
		/// </summary>
		/// <param name="category"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Post(Category category)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var result = await _catService.CreateAsync(category);
					return Ok(result);
				}
				return BadRequest(ModelState);
			}
			catch (Exception ex)
			{
				return BadRequest($"Some Error Occured in Post {ex.Message}");
			}
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Category category)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var result = await _catService.UpdateAsync(id,category);
					return Ok(result);
				}
				return BadRequest(ModelState);
			}
			catch (Exception ex)
			{
				return BadRequest($"Some Error Occured in Put {ex.Message}");
			}
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _catService.DeleteAsync(id);
			if (result == false) return NotFound($"Record based on id = {id} is missing");
			return Ok(result);
		}
	}
}
