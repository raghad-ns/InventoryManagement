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
            }
            else 
            {
                Console.WriteLine("Product Doesn't exist");
            }
        }
        public void DisplayItemsList()
        {
            foreach (Product item in InventoryProducts) { 
                Console.WriteLine(item.ToString());
            }
        }
        public Product SearchItem(string name) {
            foreach (var item in InventoryProducts)
            {
                if (item.Name == name) return item;
            }
            return null;
        }
    }
}
