using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesProj.Data.Repositories;
namespace SalesProj.Data
{
    class Product
    {
        public int saleID;
        public int SaleID { get => saleID; set => saleID = value; }

        public string productName;
        public string ProductName { get => productName; set => productName = value; }

        public int quantity;
        public int Quantity { get => quantity; set => quantity = value; }

        public double price;
        public double Price { get => price; set => price = value; }

        public DateTime saleDate;


        
        public string GetInfo()
        {
            return $"\nID: {saleID}\nName: {productName}\nQuantity: {quantity}\nPrice: {price} \nSale Date: {saleDate.ToShortDateString()}";
        }

        public Product(int saleID = 0, string productName = "Unknown", int quantity = 0, double price = 0.0)
        {
            this.saleID = saleID;
            this.productName = productName;
            this.quantity = quantity;
            this.price = price;
            saleDate = saleDate;
        }
    }
}
