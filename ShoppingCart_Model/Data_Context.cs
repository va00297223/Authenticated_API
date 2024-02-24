using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace ShoppingCart_Model
{
    public class Data_Context : DbContext
    {
        public Data_Context(DbContextOptions<Data_Context> options) : base(options)
        {
        }

        // DbSet properties for your models
        public DbSet<Product_Model> Products { get; set; }
        public DbSet<Category_Model> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}
