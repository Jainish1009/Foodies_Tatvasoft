using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodies.Models.ViewModels;

namespace Foodies.Models.Data
{
    public class ZomatoContext : DbContext
    {
       

        public ZomatoContext(DbContextOptions<ZomatoContext> options) : base(options)
        {
        }

       

        public DbSet<User> Users { get; set;  }

        public DbSet<RestMenu> RestMenus { get; set; }



    }
}
