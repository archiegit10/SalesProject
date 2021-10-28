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
            //total sales for year 
            Console.WriteLine("Enter the year: ");
            Console.Write(">");
            string year = Console.ReadLine();
            string totalYearSum = "";
            string salesSum = productService.TotalYearRead(totalYearSum, year);
            Console.Write($"Sales sum for year {year} is £{salesSum}\n");
            Console.WriteLine("\nPress Any Key to Continue");
            Console.ReadKey();

        }
        public void ProductSalesMonth()
        {
            // list all individual sales for month and year
            Console.WriteLine("Enter the Year:");
            Console.Write(">");
            string year = Console.ReadLine();
            Console.WriteLine("Enter the Month: (IN DIGITS 1-12)");
            Console.Write(">");
            string month = Console.ReadLine();
            string totalYearMonthSum = "";
            string salesSum = productService.TotalYearMonthRead(totalYearMonthSum, year, month);
            Console.Write($"Sales sum for year {year} and month {month} is £{salesSum}\n");
            Console.WriteLine("\nPress Any Key to Continue");
            Console.ReadKey();
        }

        public void TotalSalesYear()
        {
            // sum of all sales for year
            Console.WriteLine("Enter the year: ");
            Console.Write(">");
            string year = Console.ReadLine();
            Console.Write($"Individual Sales in year {year}\n");

            IEnumerable<Product> productsInDb = productService.TotalSalesYear(year);
            foreach (var product in productsInDb)
            {
                Console.WriteLine($"{product.GetInfo()}");
            }
            Console.WriteLine("\nPress Any Key to Continue");
            Console.ReadKey();

        }
        public void TotalSalesMonth()
        {
            // sum of sales for month
            Console.WriteLine("Enter the year: ");
            Console.Write(">");
            string year = Console.ReadLine();
            Console.WriteLine("Enter the Month: (IN DIGITS 1-12)");
            Console.Write(">");
            string month = Console.ReadLine();
            Console.Write($"Individual Sales in year {year} and month {month}\n");

            IEnumerable<Product> productsInDb = productService.TotalSalesYearMonth(year, month);
            foreach (var product in productsInDb)
            {
                Console.WriteLine($"{product.GetInfo()}");
            }
            Console.WriteLine("\nPress Any Key to Continue");
            Console.ReadKey();
        }
    }
}
