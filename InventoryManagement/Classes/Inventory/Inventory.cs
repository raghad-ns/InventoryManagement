using InventoryManagement.Interfaces;
using InventoryManagement.Classes.ProductManagement;

namespace InventoryManagement.Classes.Inventory
{
    public class Inventory : Add, Delete, DisplayList, Edit
    {
        private List<Product> InventoryProducts;
        private Database.Database _databaseInstance;

        public Inventory(Database.Database databaseInstance)
        {
            _databaseInstance = databaseInstance;
        }

        public async Task AddItem(Product item)
        {
            try
            {
                await _databaseInstance.AddItem(item);
                Console.WriteLine("Product added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong, please try again later!");
            }
        }

        public async Task DeleteItem(string name)
        {
            try
            {
                await _databaseInstance.DeleteItem(name);
                Console.WriteLine("Product deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to delete this product!");
            }
        }

        public async Task DisplayItemsList()
        {
            var inventoryProducts = await _databaseInstance.ReadItems();
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
