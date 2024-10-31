using InventoryManagement.Classes.common;
using InventoryManagement.Classes.ProductManagement;
using InventoryManagement.Classes.ProductManagement.ProductTypes;
using InventoryManagement.Enums.common;
using System.Data.SqlClient;

namespace InventoryManagement.Database;

public class Database
{
    public async Task<List<Product>> ReadItems()
    {
        var itemsList = new List<Product>();

        string connString = @"Server=DESKTOP-33KIDRJ\SQLEXPRESS;Database=InventoryManagement;Trusted_Connection = True;";

        try
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //access SQL Server and run your command
                SqlCommand items = new SqlCommand("SELECT * FROM Items ", conn);

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
}
