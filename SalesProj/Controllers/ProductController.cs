﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesProj.Services;
using SalesProj.Data;
namespace SalesProj.Controllers
{
    class ProductController
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }
        public void Create()
        {
            Console.WriteLine("Enter the Sale ID:");
            int saleID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Product Name:");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter the Quantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Price:");
            double price = Convert.ToDouble(Console.ReadLine());

            DateTime saleDate = DateTime.Today;

            Product toCreate = new Product() { saleID = saleID, productName = productName, quantity = quantity, price = price, saleDate = saleDate };
            Product newProduct = productService.Create(toCreate);
            Console.WriteLine($"New product created: {newProduct}");

        }

        public void ReadProducts()
        {
            IEnumerable<Product> productsInDb = productService.Read();
            foreach (var product in productsInDb)
            {
                Console.WriteLine($"{product.GetInfo()}");
            }
            Console.WriteLine("\nPress Any Key to Continue");
            Console.ReadKey();
        }
        internal void Delete()
        {
            Console.WriteLine("Enter item id");
            Console.Write("> ");
            string input = Console.ReadLine();
            bool b = int.TryParse(input, out int id);

            if (b)
            {
                productService.Delete(id);
                Console.WriteLine($"Deleted ID: {id}");
            }
            else
            {
                Console.WriteLine("else delete id");
            }        
        }
    }
}
