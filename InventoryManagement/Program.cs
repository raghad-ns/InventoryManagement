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
                    case "1": // Add
                        inventory.AddItem(GetProductInfo());
                        break;

                    case "2": // Display list
                        inventory.DisplayItemsList();
                        break;
                    case "3": // Edit
                        Console.WriteLine("Enter the product name to edit: ");
                        string productNameToEdit = Console.ReadLine();
                        inventory.Edit(productNameToEdit, GetProductInfo());
                        break;
                    case "4": // Delete
                        Console.WriteLine("Enter the product name to delete");
                        string productName = Console.ReadLine();
                        inventory.DeleteItem(productName);
                        break;
                    case "5": // Search
                        Console.WriteLine($"Enter the product name to search for: ");
                        string searchTerm = Console.ReadLine();
                        Product product = inventory.SearchItem(searchTerm);
                        if (product != null)
                        {
                            Console.WriteLine("Product found:");
                            Console.WriteLine(product.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Product doesn't exist!");
                        }
                        break;
                    case "0": // Exit
                        break;
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }

        private static Product GetProductInfo()
        {
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
            return new RegularProduct(id, name, new Price(price, currency), quantity);
        }
    }
}