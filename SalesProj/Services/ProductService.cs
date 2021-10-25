using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesProj.Product;

namespace SalesProj.Services
{
    class ProductService
    {
        private IList<Product.Product> products;

        public ProductService()
        {
            products = new List<Product.Product>();
        }

        internal Product.Product Create(Product.Product product)
        {
            Console.WriteLine("Enter the Sale ID:");
            int saleID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Product Name:");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter the Quantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Price:");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the Sale Date:");
            string pattern = "dd/MM/yyyy";
            DateTime saleDate = DateTime.ParseExact(Console.ReadLine(),pattern, null);


            Product.Product newProduct = new Product.Product(saleID, productName, quantity, price, saleDate);
            products.Add(newProduct);
            Console.WriteLine($"Created new movie of {newProduct}");
            return product;
        }

        internal Product.Product Read(Product.Product products)
        {
            return products;
        }
    }
}
