using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesProj.Data;
using SalesProj.Data.Repositories;
using System.Data;

namespace SalesProj.Data.Repositories
{
    internal class ProductRepository : ICrdRepository<Product, int>
    {
        private readonly MySqlConnection connection;

        public ProductRepository(MySqlConnection mySqlConnection)
        {
            connection = mySqlConnection;
        }

        public Product Create(Product toCreate)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO Sales(product_name,sale_quantity,item_price) VALUES ('{toCreate.ProductName}',{toCreate.Quantity},{toCreate.Price})";

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            Product product = new Product();
            product.SaleID = (int)command.LastInsertedId;
            product.ProductName = toCreate.ProductName;

            return product;
        }

        public IList<Product> Read()
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Sales";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            IList<Product> products = ItemsFromReader(reader);
            connection.Close();

            return products;
        }


        public void Delete(int id)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM Sales WHERE id={id}";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
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

        public bool Exists(int u)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM sales WHERE id=@id"; // @id is a placeholder/parameter for prepared statements
            command.Parameters.AddWithValue("@id", u); // adding value to prepared statement

            connection.Open();
            command.Prepare(); // prepare the statement to be executed
            int result = Convert.ToInt32(command.ExecuteScalar()); // ExecuteScalar returns a single value
            connection.Close();

            return result > 0;
        }
        
    }
}
