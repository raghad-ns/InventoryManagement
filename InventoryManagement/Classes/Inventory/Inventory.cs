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
                var productId = await _databaseInstance.AddItem(item);
                Console.WriteLine($"Product added successfully with id: {productId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine(ex);
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
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DisplayItemsList()
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Product> SearchItem(string name)
        {
            try
            {
                var items = await _databaseInstance.ReadItems(name);
                return items[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task Edit(string name, Product newProduct)
        {
            try
            {
                Product updatedProduct = await _databaseInstance.UpdateItem(name, newProduct);
                Console.WriteLine($"Product with name ({updatedProduct.Name}) updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
