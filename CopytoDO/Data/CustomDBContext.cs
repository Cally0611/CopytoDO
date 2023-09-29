using CopytoDO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopytoDO.Data
{
    public partial class CustomDBContext : GndLocalReasonsv1Context
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("LocalExpressDB");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppAnalysis>(entity =>
            {
                entity.Property(e => e.AppButtonColour).IsFixedLength();
                entity.Property(e => e.AppMode).IsFixedLength();
                entity.Property(e => e.TimeDiff).HasComputedColumnSql("(datediff(second,[App_starttime],[App_endtime]))", false);
            });

            modelBuilder.Entity<Reasondetail>(entity =>
            {
                entity.HasKey(e => e.StopTimeId).HasName("PK_StopReasondetails");

                entity.Property(e => e.WorkerId).IsFixedLength();
                entity.Ignore(e => e.WorkerId);
                entity.Ignore(e => e.WorkerIdname);
            });

         
        }

        public CustomDBContext() 
        { 

        }

     
    }
}
