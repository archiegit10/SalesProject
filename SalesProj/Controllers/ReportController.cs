using SalesProj.Data;
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

        public void ProductSalesYear()
        {
            // list all individual sales for year
            Console.WriteLine("Enter the Year:");
            Console.Write(">");
            int salesYear = Convert.ToInt32(Console.ReadLine());

        }
        public void ProductSalesMonth()
        {
            // list all individual sales for month and year
            Console.WriteLine("Enter the Month:");
            Console.Write(">");
            int salesMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Year:");
            Console.Write(">");
            int salesYear = Convert.ToInt32(Console.ReadLine());
        }

        public void TotalSalesYear()
        {
            // sum of all sales for year
            Console.WriteLine("Enter the Year:");
            Console.Write(">");
            int totalYear = Convert.ToInt32(Console.ReadLine());

            int sum = 0;
            IEnumerable<Product> productsInDb = productService.Read();
            foreach (var product in productsInDb)
            {
                Console.WriteLine($"{product.GetInfo()}");
                if (product.saleDate.Year == totalYear)
                {
                    int productSum = (int)(product.price * product.quantity);
                    sum = sum + productSum;
                }
            }
            Console.WriteLine($"Sum of Sales for {totalYear}: {sum}");

        }
        public void TotalSalesMonth()
        {
            // sum of sales for month
            Console.WriteLine("Enter the Month:");
            Console.Write(">");
            int totalMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Year:");
            Console.Write(">");
            int totalYear = Convert.ToInt32(Console.ReadLine());

        }
    }
}
