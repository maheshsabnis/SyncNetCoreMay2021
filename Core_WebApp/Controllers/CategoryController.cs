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
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private IService<Category, int> _catService;
		public CategoryController(IService<Category, int> catService)
		{
			_catService = catService;
		}

		[HttpPost]
		[ActionName("PostByParameters")]
		public async Task<IActionResult> PostByParameters(string CategoryId, string CategoryName, int BasePrice)
		{
			try
			{
				var cat = new Category()
				{
					CategoryId = CategoryId,
					CategoryName = CategoryName,
					BasePrice = BasePrice
				};

				var result = await _catService.CreateAsync(cat);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}



		[HttpPost]
		[ActionName("PostByQuery")]
		public async Task<IActionResult> PostByQuery([FromQuery] Category cat)
		{
			try
			{

				var result = await _catService.CreateAsync(cat);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("{categoryid}/{categoryname}/{baseprice}")]
		[ActionName("PostByRoute")]
		public async Task<IActionResult> PostByRoute([FromRoute] Category cat)
		{
			try
			{

				var result = await _catService.CreateAsync(cat);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[ActionName("PostByForm")]
		public async Task<IActionResult> PostByForm([FromForm] Category cat)
		{
			try
			{

				var result = await _catService.CreateAsync(cat);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
