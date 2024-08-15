using InventoryManagement.Classes.Product;
using InventoryManagement.Classes.common;
using System;

namespace InventoryManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our inventory management system");
            Product product = new Product(1,"Rice", new Price(5, Enums.common.Currency.ILS), 50);
        }
    }
}