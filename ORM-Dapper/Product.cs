using System;
namespace ORM_Dapper
{
	public class Product
	{
		public Product()
		{
		}

		public int ProductID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int CatagoryID { get; set; }
		public int OnSale { get; set; }
		public string StockLevel { get; set; }
	}
}

