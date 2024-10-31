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

        public async Task<Product> SearchItem(string name)
        {
            var items = await _databaseInstance.ReadItems(name);
            return items[0];
        }

        public async Task Edit(string name, Product newProduct)
        {
            try
            {
                await _databaseInstance.UpdateItem(name, newProduct);
                Console.WriteLine("Product updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong, please try again!");
            }
        }
    }
}
