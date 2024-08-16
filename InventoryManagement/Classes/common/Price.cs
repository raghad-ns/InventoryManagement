using InventoryManagement.Enums.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Classes.common
{
    public class Price
    {
        private double amount;
        public double Amount
        {
            get { return amount; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price should be greater than 0");
                else amount = value;
            }
        }
        public Currency Currency { get; set; }
        public Price() { }
        public Price(double price, Currency currency)
        {
            this.Amount = price;
            this.Currency = currency;
        }
    }
}
