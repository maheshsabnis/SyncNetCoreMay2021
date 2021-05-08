using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_WebApp.Services
{
	public class CategoryService : IService<Category, int>
	{
		private SyncAppDbContext _context;
		public CategoryService(SyncAppDbContext context)
		{
			_context = context;
		}

		public async Task<Category> CreateAsync(Category entity)
		{
			var result = await _context.Categories.AddAsync(entity);
			await _context.SaveChangesAsync();
			return result.Entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			// search record
			var record = await _context.Categories.FindAsync(id);
			if(record == null) return false;
			_context.Categories.Remove(record);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<Category>> GetAsync()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task<Category> GetAsync(int id)
		{
			return await _context.Categories.FindAsync(id);
		}

		public async Task<Category> UpdateAsync(int id, Category entity)
		{

			//_context.Entry<Category>(entity).State = EntityState.Modified;
			//await _context.SaveChangesAsync();

			// search record
			var record = await _context.Categories.FindAsync(id);
			if (record != null) 
			{
				// update
				record.CategoryId = entity.CategoryId;
				record.CategoryName = entity.CategoryName;
				record.BasePrice = entity.BasePrice;
				await _context.SaveChangesAsync();
				return record;
			}
			return null;
		}
	}
}
