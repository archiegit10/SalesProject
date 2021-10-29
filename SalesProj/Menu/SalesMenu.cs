using SalesProj.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesProj.Menu;
using SalesProj.Utils;
using SalesProj.Data.Repositories;

namespace SalesProj.Menu
{
    class SalesMenu
    {
        private readonly ProductController productController;
        
        public SalesMenu(ProductController productController)
        {
            this.productController = productController;
        }


        public void SubMenu()
        {
            Console.WriteLine("\n1. DATA ENTRY\n2. REPORTS\n3. QUIT");
            Console.Write("> ");
            string input = Console.ReadLine();
            switch (input.ToUpper())
            {
                case "1" or "DATA ENTRY":
                    DataSubMenu();
                    break;
                case "2" or "REPORTS":
                    ReportsSubMenu();
                    break;
                case "3" or "QUIT":
                    break;
                default:
                    Console.WriteLine("Invalid Choice, please enter a valid choice e.g. '1' or 'DATA ENTRY' etc \n Press Any Key To Continue");
                    Console.ReadKey();
                    Console.Clear();
                    SubMenu();
                    break;
            }
        }

        public void ReportsSubMenu()
        {

            ReportController reportController = new ReportController(new Services.ReportService(new ReportRepository(MySqlUtil.GetConnection())));
            bool inMenu = true;

            while (inMenu)
            {
                Console.WriteLine("\n--------------------\nData Report Menu\n1. Sales by Year\n2. Sales by Month and Year\n3. Total Sales by Year\n4. Total Sales by Year and Month\n5. Sales Between Two Years\n6. Sales Between Two Years and Months\n7. Average Sales for a Month Over Years\n11. Back\n--------------------");
                Console.Write("> ");
                string input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "1":
                        // sales by year
                        //productController.SalesYear();
                        reportController.ProductSalesYear();

                        break;
                    case "2":
                        //Sales by month and year
                        reportController.ProductSalesMonth();
                        break;
                    case "3":
                        // total sales by year
                        reportController.TotalSalesYear();

                        break;
                    case "4":
                        // total sales by year and month
                        reportController.TotalSalesMonth();
                        break;
                    case "5":
                        //	All sales between two specified years (inclusive)
                        reportController.SalesBetweenYear();
                        break;
                    case "6":
                        //	All sales between two specified years and months (inclusive)
                        //select* from sales where not(month(sale_date) < 01 and year(sale_date) < 2020 OR month(sale_date) > 05 and year(sale_date) > 2022);
                        break;
                    case "7":
                        //	The average sales for a given month over a specified amount of years (Example output: July over the past 3 years has averaged £4500 in sales)
                        //select avg(monthsales) as averagesales from(select year(sale_date), sum(sale_quantity* item_price) as monthsales from sales where month(sale_date) = 05 group by year(sale_date) order by year(sale_date) desc limit 1) AS eachyear;
                        break;
                    case "8":
                        //	The average sales per month for a specified year (Example output: In 2021, the average amount of sales per month is £4000)
                        break;
                    case "9":
                        //	The month of a specified year that made the most sales (Example output: In 2018, the highest sales were made in February at £7500)
                        break;
                    case "10":
                        //	The month of a specified year that made the least sales
                        break;
                    case "11":
                        SubMenu();
                        inMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice, please enter a valid choice e.g. '1' \n Press Any Key To Continue");
                        Console.ReadKey();
                        Console.Clear();
                        ReportsSubMenu();
                        break;
                }

            }
        }

        public void DataSubMenu()
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine("\nData Entry\n1. READ all products\n2. CREATE Product\n3. DELETE Products\n4. BACK");
                Console.Write("> ");
                string input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "1" or "READ":
                        //Controller to read movies
                        productController.ReadProducts();
                        break;
                    case "2" or "CREATE":
                        //controller to create
                        productController.Create();
                        break;
                    case "3" or "DELETE":
                        //controller to delete movie
                        productController.Delete();
                        break;
                    case "4" or "BACK":
                        SubMenu();
                        inMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice, please enter a valid choice e.g. '1' or 'READ' etc \n Press Any Key To Continue");
                        Console.ReadKey();
                        Console.Clear();
                        DataSubMenu();
                        break;
                }
            }

        }
    }
}
