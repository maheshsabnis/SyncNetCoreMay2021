using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebApp.Services
{
	/// <summary>
	/// TEntity, is the ENtity CLass
	/// The 'in' is the input parameter for methods in interface
	/// TPk, will be the Primary Key TYpe
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <typeparam name="TPk"></typeparam>
	public interface IService<TEntity, in TPk> where TEntity : class
	{
		public Task<IEnumerable<TEntity>> GetAsync();
		public Task<TEntity> GetAsync(TPk id);
		public Task<TEntity> CreateAsync(TEntity entity);
		public Task<TEntity> UpdateAsync(TPk id, TEntity entity);
		public Task<bool> DeleteAsync(TPk id);
	}
}
