using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebApp.Models
{
	public class Category
	{
		[Key] // Primary Identity Key
		public int CategoryRowId { get; set; }
		[Required(ErrorMessage ="Category Id is must")]
		[StringLength(20)]
		public string CategoryId { get; set; }
		[Required(ErrorMessage = "Category Name is must")]
		[StringLength(200)]
		public string CategoryName { get; set; }
		[Required(ErrorMessage = "Base Price is must")]
		public int BasePrice { get; set; }
		public ICollection<Product> Products { get; set; } // One-To-Many Relation
	}

	public class Product
	{
		[Key]
		public int ProductRowId { get; set; }
		[Required(ErrorMessage = "Product Id is must")]
		[StringLength(20)]
		public string ProductId { get; set; }
		[Required(ErrorMessage = "Product Name is must")]
		[StringLength(200)]
		public string ProductName { get; set; }
		[Required(ErrorMessage = "Manufacturer is must")]
		[StringLength(200)]
		public string Manufacturer { get; set; }
		[Required(ErrorMessage = "Price is must")]
		 
		public int Price { get; set; }
		[Required(ErrorMessage = "Category Row Id is must")]
		 
		public int CategoryRowId { get; set; } // Expected Foreign Key
		public Category Category { get; set; }
	}
}
