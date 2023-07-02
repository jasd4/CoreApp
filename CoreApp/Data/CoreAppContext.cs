using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreApp.Models;

namespace CoreApp.Data
{
    public class CoreAppContext : DbContext
    {
        public CoreAppContext (DbContextOptions<CoreAppContext> options)
            : base(options)
        {
        }

        public DbSet<CoreApp.Models.Moto> Moto { get; set; } = default!;
    }
}
