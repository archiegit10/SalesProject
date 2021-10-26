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
            }
        }

        public void ReportsSubMenu()
        {
            bool inMenu = true;

            while (inMenu)
            {
                Console.WriteLine("\nData Report\n1. Sales by Year\n2. Sales by Month and Year\n3. Total Sales by Year\n4. Total Sales by Year and Month\n5. Back");
                Console.Write("> ");
                string input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "1":
                        // sales by year

                        break;
                    case "2":
                        //Sales by month and year   
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
                }

            }
        }

        public void DataSubMenu()
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine("\nData Entry\n1. Read all products\n2. Create Product\n3. Delete Products\n4. Back");
                Console.Write("> ");
                string input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "1" or "READ":
                        //Controller to read movies
                        productController.ReadProducts();
                        break;
                    case "2" or "CREATE":
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
                }
            }

        }
    }
}
