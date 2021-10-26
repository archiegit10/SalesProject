using SalesProj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProj.Controllers
{
    class ReportController
    {
        private readonly ProductService productService;


        public ReportController(ProductService productService)
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
        public void ProductSalesYear()
        {
            // list all individual sales for year
        }
        public void ProductSalesMonth()
        {
            // list all individual sales for month
        }

        public void TotalSalesYear()
        {
            // sum of all sales
        }
        public void TotalSalesMonth()
        {
            // sum of sales for month
        }
    }
}
