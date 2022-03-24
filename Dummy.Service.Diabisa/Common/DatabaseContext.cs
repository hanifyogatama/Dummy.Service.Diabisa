using Dummy.Service.Diabisa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Common
{
    public class DatabaseContext : DbContext
    {
        public DbContextOptions<DatabaseContext> options;

        public DbSet<DiabisaItem> Diabisa_Item_Dataset { get; set; }

        public DatabaseContext() : base() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> _options) : base(_options)
        {
            options = _options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // mapping variable to each exist table in database
            builder.Entity<DiabisaItem>().ToTable("MR_Diabisa").HasKey(dia => new { dia.id });
      
            base.OnModelCreating(builder);
        }
    }
}
