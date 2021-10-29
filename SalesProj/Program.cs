
using System;
using MySql.Data.MySqlClient;
using SalesProj.Controllers;
using SalesProj.Data.Repositories;
using SalesProj.Menu;
using SalesProj.Services;
using SalesProj.Utils;


namespace SalesProj
{
    class Program
    {
        
        static void Main(string[] args)
        {
            using MySqlConnection connection = MySqlUtil.GetConnection();
            
            SalesMenu menu = new SalesMenu(
                new ProductController(
                    new ProductService(
                        new ProductRepository(
                            connection))));
            
            menu.SubMenu();
            /*
            //creating the sales table in the database 
            connection.Open();
            MySqlUtil.RunSchema(Environment.CurrentDirectory + @"\Data\Sql\Schema.sql", connection);
            connection.Dispose();
            */
        }
    }
}
