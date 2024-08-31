using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Exceptions
{
    public class NegativePriceException(): Exception("Price should be greater than 0!");
    
}
