﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProj.Product
{
    class Product
    {
        private int saleID;
        public int SaleID { get => saleID; set => saleID = value; }

        private string productName;
        public string ProductName { get => productName; set => productName = value; }

        private int quantity;
        public int Quantity { get => quantity; set => quantity = value; }

        private double price;
        public double Price { get => price; set => price = value; }

        private DateTime? saleDate;
        public DateTime? SaleDate { get => saleDate; set => saleDate = value; }

        
        public string GetInfo()
        {
            return $"\nID: {saleID}\nName: {productName}\nQuantity: {quantity}\nPrice: {price}\nSale Date: {saleDate}";
        }

        public Product(int saleID = 0, string productName = "Unknown", int quantity = 0, double price = 0.0, DateTime? saleDate = null)
        {
            if (!saleDate.HasValue)
            {
                DateTime thisDay = DateTime.Today;
                saleDate = thisDay;
            }
            this.saleID = saleID;
            this.productName = productName;
            this.quantity = quantity;
            this.price = price;
            this.saleDate = saleDate;
        }
    }
}
