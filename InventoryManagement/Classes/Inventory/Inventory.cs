using InventoryManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Classes;
using InventoryManagement.Classes.ProductManagement;
using InventoryManagement.Database;

namespace InventoryManagement.Classes.Inventory
{
    public class Inventory : Add, Delete, DisplayList, Edit
    {
        private MongoHelper _databaseDriver;
        private string _productCollectionName = "Product";

        public Inventory(MongoHelper databaseDriver)
        {
            _databaseDriver = databaseDriver;
        }

        public void AddItem(Product item)
        {
            try
            {
                _databaseDriver.InsertDocument(_productCollectionName, item);
                Console.WriteLine("Product added successfully!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong, please try again later!");
                    Console.WriteLine(ex.Message);
            }
        }

        public void DeleteItem(string name)
        {
            try
            {
                Product productToBeDeleted = _databaseDriver.LoadDocumentByName<Product>(_productCollectionName, name);
                _databaseDriver.DeleteDocument<Product>(_productCollectionName, productToBeDeleted.Id);
                Console.WriteLine("Product deleted successfully!");
            }
            catch
            {
                Console.WriteLine("Something went wrong, please try again later!");
            }
        }
        public void DisplayItemsList()
        {
            var inventoryProducts = _databaseDriver.LoadAllDocuments<Product>(_productCollectionName);
            if (inventoryProducts.Count > 0)
            {
                Console.WriteLine($"Inventory's products list: ");
                foreach (Product item in inventoryProducts)
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
            try
            {
                return _databaseDriver.LoadDocumentByName<Product>(_productCollectionName, name);
            }
            catch
            {
                return null;
            }
        }

        public void Edit(Guid id, Product newProduct)
        {
            try
            {
                _databaseDriver.UpsertDocument<Product>(_productCollectionName, id, newProduct);
                Console.WriteLine("Product updated successfully!");
            }
            catch
            {
                Console.WriteLine("Something went wrong, please try again later!");
            }
        }
    }
}
