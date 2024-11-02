using InventoryManagement.Classes.common;
using InventoryManagement.Exceptions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Classes.ProductManagement
{
    public class Product
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public int Quantity { get; set; }

        private Price price= new();
        public Price Price
        {
            get { return this.price; }
            set
            {
                try
                {
                    this.price = value;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Product() { }
        public Product(Guid id, string name, Price price, int quantity)
        {
            try
            {
                this.Id = id;
                this.Name = name;
                this.Price = price;
                this.Quantity = quantity;
            }
            catch (NegativePriceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
