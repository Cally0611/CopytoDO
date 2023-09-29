using System;
using System.Collections.Generic;
using CopytoDO.Models;
using Microsoft.EntityFrameworkCore;

namespace CopytoDO.Data;

public partial class OeedashboardContext : DbContext
{
    public OeedashboardContext()
    {
    }

    public OeedashboardContext(DbContextOptions<OeedashboardContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OeeDetailsAll> OeeDetailsAlls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\;Initial Catalog= OEEDashboard;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OeeDetailsAll>(entity =>
        {
            entity.Property(e => e.StopDownTime).HasComputedColumnSql("(datediff(second,[StopReasonStart],[StopReasonEnd]))", false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
