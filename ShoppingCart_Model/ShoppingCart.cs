using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart_Model
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string? User { get; set; }
        public List<Product_Model>? Products { get; set; }
    }
}
