using InventoryManagement.Classes.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Classes.ProductManagement.ProductTypes
{
    internal class RegularProduct: Product
    {
        public RegularProduct() { }
        public RegularProduct(int id, string name, Price price, int quantity) : base(id, name, price, quantity) { }

        public override string ToString()
        {
            return $"Product name: {Name}, price: {Price.Amount}, stock quantity: {Quantity}";
        }
    }
}
