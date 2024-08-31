using InventoryManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Classes;
using InventoryManagement.Classes.ProductManagement;

namespace InventoryManagement.Classes.Inventory
{
    public class Inventory : Add, Delete, DisplayList, Edit
    {
        private List<Product> InventoryProducts = new();
        public void AddItem(Product item)
        {
            if (item is not null)
            {
                InventoryProducts.Add(item);
            }
        }

        public void DeleteItem(string name)
        {

            Product product = SearchItem(name);
            if (product is not null)
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
            else
            {
                Console.WriteLine("Inventory is empty, no product found!");
            }
        }
        public Product SearchItem(string name)
        {
            foreach (var item in InventoryProducts)
            {
                if (item.Name.ToLower().Equals(name.ToLower())) return item;
            }
            return null;
        }

        // There is two suggested approaches, I'm confuesed which one to implement
        // The first is to re-implement search logic in a loop and edit the object once found,
        // The second one is to add extra parameters for the search method to implement the edit process (make edit optional when search)
        // But I think the second one doesn't work with single responsibility principle
        public void Edit(string name, Product newProduct)
        {
            bool found = false;
            foreach (var item in InventoryProducts)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    found = true;
                    item.Name = newProduct.Name;
                    item.Price = newProduct.Price;
                    item.Quantity = newProduct.Quantity;
                }
            }
            if (found) Console.WriteLine("Product updated successfully!");
            else Console.WriteLine("Product doesn't exist!");
        }
    }
}
