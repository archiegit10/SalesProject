﻿using System;
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
        /*
        internal string TotalYearRead(string totalYearSum, string year)
        {
            string sum = totalYearSum;
            string passYear = year;
            return productRepository.TotalYearRead(totalYearSum, passYear);
        }

        internal string TotalYearMonthRead(string totalYearMonthSum, string year, string month)
        {
            string sum = totalYearMonthSum;
            string passYear = year;
            string passMonth = month;
            return productRepository.TotalYearMonthRead(totalYearMonthSum, passYear, passMonth);
        }
        internal IEnumerable<Product> TotalSalesYear(string year)
        {
            string passYear = year;
            return productRepository.TotalSalesYear(passYear);
        }
        internal IEnumerable<Product> TotalSalesYearMonth(string year, string month)
        {
            string passYear = year;
            string passMonth = month;
            return productRepository.TotalSalesYearMonth(passYear, passMonth);
        }
        */
    }
}
