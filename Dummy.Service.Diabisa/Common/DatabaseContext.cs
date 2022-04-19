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

        public DbSet<BloodGlucoseItem> Diabisa_Item_Dataset { get; set; }

        public DatabaseContext() : base() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> _options) : base(_options)
        {
            options = _options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // mapping variable to each exist table in database
            builder.Entity<BloodGlucoseItem>().ToTable("MR_BloodGlucose").HasKey(bg => new { bg.id });
            builder.Entity<BloodPressureItem>().ToTable("MR_BloodPressure").HasKey(bp => new { bp.id });
            builder.Entity<ChartBloodGlucose>().ToTable("CHRT_BloodGlucose").HasKey(cbg => new { cbg.id });
            builder.Entity<ChartBloodPressure>().ToTable("CHRT_BloodPressure").HasKey(cbp => new { cbp.id });
      
            base.OnModelCreating(builder);
        }
    }
}
