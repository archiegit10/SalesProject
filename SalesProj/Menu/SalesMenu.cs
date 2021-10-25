using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProj.Menu
{
    class SalesMenu
    {
        public static void SubMenu()
        {
            Console.WriteLine("1. DATA ENTRY\n2. REPORTS\n3. QUIT");

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

        private static void ReportsSubMenu()
        {
            bool inMenu = true;

            while (inMenu)
            {
                Console.WriteLine("Data Report\n1. Sales by Year\n2. Sales by Month and Year\n3. Total Sales by Year\n4. Total Sales by Year and Month\n5. Back");
                string input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "1":
                        //Controller to for report  
                        break;
                    case "2":
                        //Controller to for report  
                        break;
                    case "3":
                        //Controller to for report
                        break;
                    case "4":
                        //Controller to for report
                        break;
                    case "5":
                        SubMenu();
                        inMenu = false;
                        break;
                }
                Console.WriteLine("Reports");

            }
        }

        private static void DataSubMenu()
        {
            //SalesController salesControl = new SalesController();
            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine("Data Entry\n1. Read all products\n2. Create Product\n3. Delete Products\n4. Back");
                string input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "1" or "READ":
                        //Controller to read movies
                        break;
                    case "2" or "CREATE":
                        //controller to create movie
                        break;
                    case "3" or "DELETE":
                        //controller to delete movie
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
