using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebApp.Models
{
	/// <summary>
	/// DbContext, used to manage the DB COnnection
	/// CLR Class (aka ENtity Class) to Table Mapping
	/// Manages Transactions
	/// 1. Async Methods for Transactions
	///		- AddAsync()
	///			- DbContext.DbSet.AddAsync(entity); OR  DbContext.DbSet.AddRangeAsync(entity[]);
	///		- FindAsync()
	///			- DbContext.DbSet.FindAsync(Primary Key);
	///		- ToListAsync()
	///			- DbContext.DbSet.ToListAsync();
	///	2. Delete is Synchornous method	
	///		- DbbContext.DbSet.Remove(entity);
	///	3. COmmit Transactions
	///		- DbContext.SaveChangesAsync();
	///	4. DbSet State Changes
	///		- DbContext.DbSet.State = State.Modified; used for Update
	/// </summary>
	public class SyncAppDbContext : DbContext
	{
		// defining DbSet<T> properties where T is the CLR class mapped with Table in Database
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

		/// <summary>
		/// DI Specification for Providing Data instances in a session scope\
		/// Read the DB COnnection String from DI from the Startup class
		/// </summary>
		public SyncAppDbContext(DbContextOptions<SyncAppDbContext> options):base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// define One-to-Many Relationship using FLuent API
			modelBuilder.Entity<Product>()
						.HasOne(c => c.Category) // One-To-One
						.WithMany(p => p.Products) // One-To-Many
						.HasForeignKey(p => p.CategoryRowId); // FOreign Key
		}
	}
}
