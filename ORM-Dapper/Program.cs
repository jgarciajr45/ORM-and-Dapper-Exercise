using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var DapperDepartmenRepository = new DapperDepartmentRepository(conn);


            var repo = new DapperProductRepository(conn);

            Console.WriteLine("what is the name of your new product?");
            var prodName = Console.ReadLine();

            Console.WriteLine("What is the price?");
            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("what is the category id?");
            var prodCat = int.Parse(Console.ReadLine());

            repo.CreateProduct(prodName, prodPrice, prodCat);


            var prodList = repo.GetAllProducts();


            foreach (var prod in prodList)
            {
                Console.WriteLine($"{prod.ProductID} - {prod.Name}");
            }


            Console.WriteLine("what is the product id you want to update?");
            var prodID = int.Parse(Console.ReadLine());

            Console.WriteLine("what is the new product name?");
            var newName = Console.ReadLine();

            repo.UpdateProduct(prodID, newName);


            Console.WriteLine("what is the product ID you want to delete?");
            prodID = int.Parse(Console.ReadLine());

            repo.DeleteProduct(prodID);

        }

    }
}

