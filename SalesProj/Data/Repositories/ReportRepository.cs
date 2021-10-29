using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProj.Data.Repositories
{
    internal class ReportRepository : IReportRepository<Product,string>
    {
        private readonly MySqlConnection connection;

        public ReportRepository(MySqlConnection mySqlConnection)
        {
            connection = mySqlConnection;
        }
        public IList<Product> ItemsFromReader(MySqlDataReader reader)
        {
            IList<Product> products = new List<Product>();
            while (reader.Read())
            {
                // get values from current row in reader
                int sale_id = reader.GetFieldValue<int>("id");
                string product_name = reader.GetFieldValue<string>("product_name");
                int sale_quantity = reader.GetFieldValue<int>("sale_quantity");
                double item_price = reader.GetFieldValue<double>("item_price");
                DateTime saleDate = reader.GetFieldValue<DateTime>("sale_date");

                Product product = new Product() { SaleID = sale_id, ProductName = product_name, quantity = sale_quantity, price = item_price, saleDate = saleDate };
                products.Add(product);
            }
            return products;
        }
        public string TotalYearRead(string totalYearSum, string passyear)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select sum(item_price * sale_quantity) from sales where year(sale_date) = ('{passyear}')";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader(); // returns a reader object
            while (reader.Read())
            {
                totalYearSum = reader["sum(item_price * sale_quantity)"].ToString();
            }
            connection.Close();
            return totalYearSum;
        }
        public string TotalYearMonthRead(string totalYearMonthSum, string passYear, string passMonth)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select sum(item_price * sale_quantity) from sales where month(sale_date) = ('{passMonth}') and year(sale_date) = ('{passYear}')";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader(); // returns a reader object
            while (reader.Read())
            {
                totalYearMonthSum = reader["sum(item_price * sale_quantity)"].ToString();
            }
            connection.Close();
            return totalYearMonthSum;
        }

        public IList<Product> TotalSalesYear(string passYear)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from sales where year(sale_date) = ('{passYear}')";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader(); // returns a reader object
            IList<Product> products = ItemsFromReader(reader);
            connection.Close();
            return products;
        }

        public IList<Product> TotalSalesYearMonth(string passYear, string passMonth)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from sales where month(sale_date) = ('{passMonth}') and year(sale_date) = ('{passYear}')";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader(); // returns a reader object
            IList<Product> products = ItemsFromReader(reader);
            connection.Close();
            return products;
        }

        public IList<Product> SalesBetweenYear(string yearFrom, string yearToo)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from sales where year(sale_date) >= ('{yearFrom}') and year(sale_date) <= ('{yearToo}')";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader(); // returns a reader object
            IList<Product> products = ItemsFromReader(reader);
            connection.Close();
            return products;
        }


        //select* from sales where not(month(sale_date) < 01 and year(sale_date) < 2020 OR month(sale_date) > 05 and year(sale_date) > 2022);

        
    }
}
