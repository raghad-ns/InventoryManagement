using InventoryManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Classes;
using InventoryManagement.Classes.ProductManagement;
using InventoryManagement.Classes.ProductManagement.ProductTypes;

namespace InventoryManagement.Classes.InventoryManagement
{
    public class Inventory: Add,Delete,DisplayList
    {
        private List<Product> InventoryProducts = new();
        public void AddItem(Product item) {
            if (item != null)
            {
                InventoryProducts.Add(item);
            }
        }

        public void DeleteItem(string name) { 

            Product product = SearchItem(name);
            if (product != null)
            {
                InventoryProducts.Remove(product as Product);
                Console.WriteLine("Product deleted successfully!");
            }
            else 
            {
                Console.WriteLine("Product Doesn't exist");
            }
        }
        public void DisplayItemsList()
        {
            if (InventoryProducts.Count > 0)
            {
                Console.WriteLine($"Inventory's products list: ");
                foreach (Product item in InventoryProducts)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else {
                Console.WriteLine("Inventory is empty, no product found!");
            }
        }
        public Product SearchItem(string name) {
            foreach (var item in InventoryProducts)
            {
                if (item.Name.ToLower() == name.ToLower()) return item;
            }
            return null;
        }
    }
}
