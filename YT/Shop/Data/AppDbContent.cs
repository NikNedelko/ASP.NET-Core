using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data
{
    public class AppDbContent : DbContext
    {
        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options) { }
        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItems> ShopCartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
