using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesProj.Data;
using SalesProj.Data.Repositories;



namespace SalesProj.Services
{
    class ProductService
    {

        private readonly ICrdRepository<Product, int> productRepository;
        public ProductService(ICrdRepository<Product, int> productRepository)
        {
            this.productRepository = productRepository;
        }

        internal Product Create(Product toCreate)
        {
            Product newProduct = productRepository.Create(toCreate);
            return newProduct;
            /*Console.WriteLine("Enter the Sale ID:");
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
            return product;*/
        }
        internal IEnumerable<Product> Read()
        {
            return productRepository.Read();
        }
        internal void Delete(int id)
        {
            if (!productRepository.Exists(id))
            {
                Console.WriteLine($"item with id: {id} does not exist");
            }
            productRepository.Delete(id);
        }
    }
}
