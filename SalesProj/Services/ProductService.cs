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
