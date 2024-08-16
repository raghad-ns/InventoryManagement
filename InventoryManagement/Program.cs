using InventoryManagement.Classes.ProductManagement;
using InventoryManagement.Classes.common;
using System;
using InventoryManagement.Classes.ProductManagement.ProductTypes;
using InventoryManagement.Enums.common;
using InventoryManagement.Classes.InventoryManagement;

namespace InventoryManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            Console.WriteLine("***Welcome to our inventory management system***");
            // Product product = new RegularProduct(1, "Rice", new Price(5, Enums.common.Currency.ILS), 50);
            // Console.WriteLine($"product name: {product.Name}");

            string action = string.Empty;

            while (action != "0")
            {
                Console.Clear();
                Console.WriteLine("Select an action");
                Console.WriteLine("1. Add product.");
                Console.WriteLine("2. View all products.");
                Console.WriteLine("3. Edit a product.");
                Console.WriteLine("4. Delete a product.");
                Console.WriteLine("5. Search for a product.");
                Console.WriteLine("0. Exit.");
                action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        Console.WriteLine("Enter product Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter product Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the quantity in stock: ");
                        int quantity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the product's price: ");
                        double price = double.Parse(Console.ReadLine());
                        Console.WriteLine("Choose the currency:/n");
                        int index = 1;
                        foreach (string currencyName in Enum.GetNames(typeof(Currency)))
                        {
                            Console.WriteLine($"{index++}. {currencyName}");
                        }
                        string choosenCurrency = Console.ReadLine();
                        Currency currency = (Currency)Enum.Parse(typeof(Currency), choosenCurrency ?? "1");
                        inventory.AddItem(new RegularProduct(id, name, new Price(price, currency), quantity));
                        Console.WriteLine("Product added successfully");
                        Console.ReadLine();
                        break;

                    case "2":
                        inventory.DisplayItemsList();
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "0":
                        break;
                }
            }
        }
    }
}