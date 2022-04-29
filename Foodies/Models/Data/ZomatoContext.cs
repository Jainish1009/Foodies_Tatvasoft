using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodies.Models.ViewModels;
using Foodies.Models;

namespace Foodies.Models.Data
{
    public class ZomatoContext : DbContext
    {
       

        public ZomatoContext(DbContextOptions<ZomatoContext> options) : base(options)
        {
        }

       

        public DbSet<User> Users { get; set;  }

        public DbSet<RestMenu> RestMenus { get; set; }

        public DbSet<Foodies.Models.BookOrder> BookOrders { get; set; }

        public DbSet<Invoice> Invoices { get; set; }



    }
}
