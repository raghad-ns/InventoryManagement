using InventoryManagement.AppSettings;
using InventoryManagement.Classes.common;
using InventoryManagement.Classes.ProductManagement;
using InventoryManagement.Classes.ProductManagement.ProductTypes;
using InventoryManagement.Enums.common;
using System.Data.SqlClient;
using System.Text.Json;

namespace InventoryManagement.Database;

public class Database
{
    private string _connString;

    public Database()
    {
        string appSettingsJson = File.ReadAllText(@"..\..\..\AppSettings\appsettings.json");
        var appSettingsObject = JsonSerializer.Deserialize<AppSettingsModel>(appSettingsJson);
        _connString = appSettingsObject.SQLServerConnectionString;
    }

    public async Task<List<Product>> ReadItems(string? name= null)
    {
        var itemsList = new List<Product>();

        try
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                //access SQL Server and run your command
                SqlCommand items = new SqlCommand("SELECT * FROM Items " + (!string.IsNullOrEmpty(name) ? $"WHERE Name = '{name}'" : ""), conn);

                conn.Open();
                SqlDataReader dataReader = items.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        var price = new Price(
                                    double.Parse(dataReader["Price"].ToString()),
                                    (Currency)Enum.Parse(typeof(Currency), dataReader["Currency"].ToString())
                                );

                        var product = new RegularProduct(
                                int.Parse(dataReader["Id"].ToString()),
                                dataReader["Name"].ToString(),
                                price,
                                int.Parse(dataReader["Quantity"].ToString())
                            );

                        itemsList.Add(product);
                    }
                }
                else
                {
                    Console.WriteLine("No data found.");
                }
                dataReader.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: Failed to connect to the DB");
        }

        return itemsList;
    }

    public async Task AddItem(Product product)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand insertProductQuery = new SqlCommand(
                    $"INSERT INTO Items (Name, Quantity, Price, Currency) " +
                        $"VALUES ('{product.Name}', {product.Quantity}, {product.Price.Amount}, '{product.Price.Currency.ToString()}')",
                    conn
                    );

                conn.Open();
                int rowsAffected = await insertProductQuery.ExecuteNonQueryAsync(); // Executes the query
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: Failed to connect to the DB");
        }
    }

    public async Task DeleteItem(string name)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand deleteItem = new SqlCommand($"DELETE FROM Items WHERE Name = '{name}'", conn);

                conn.Open();
                int rowsAffected = await deleteItem.ExecuteNonQueryAsync();
            }
    }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: Failed to connect to the DB");
        }
    }

    public async Task UpdateItem(string name, Product product)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand updateProductQuery = new SqlCommand(
                    $@"
                        UPDATE Items 
                        SET Name = '{product.Name}', Quantity = {product.Quantity}, Price= {product.Price.Amount}, Currency= '{product.Price.Currency.ToString()}'
                        WHERE Name = '{name}'",
                    conn
                    );

                conn.Open();
                int rowsAffected = await updateProductQuery.ExecuteNonQueryAsync(); // Executes the query
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: Failed to connect to the DB");
        }
    }

}
