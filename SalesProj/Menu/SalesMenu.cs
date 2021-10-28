using SalesProj.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesProj.Menu;

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
            bool inMenu = true;

            while (inMenu)
            {
                Console.WriteLine("\n--------------------\nData Report Menu\n1. Sales by Year\n2. Sales by Month and Year\n3. Total Sales by Year\n4. Total Sales by Year and Month\n5. Back\n--------------------");
                Console.Write("> ");
                string input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "1":
                        // sales by year
                        productController.SalesYear();

                        break;
                    case "2":
                        //Sales by month and year
                        productController.SalesYearMonth();
                        break;
                    case "3":
                        // total sales by year
                        productController.TotalSalesYear();

                        break;
                    case "4":
                        // total sales by year and month
                        productController.TotalSalesMonth();
                        break;
                    case "5":
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
