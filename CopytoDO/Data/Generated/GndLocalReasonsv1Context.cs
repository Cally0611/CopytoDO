using System;
using System.Collections.Generic;
using CopytoDO.Models;
using Microsoft.EntityFrameworkCore;

namespace CopytoDO.Data;

public partial class GndLocalReasonsv1Context : DbContext
{
    public GndLocalReasonsv1Context()
    {
    }

    public GndLocalReasonsv1Context(DbContextOptions<GndLocalReasonsv1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AppAnalysis> AppAnalyses { get; set; }

    public virtual DbSet<Reasondetail> Reasondetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLExpress;Initial Catalog= GND_Local_Reasonsv1;Integrated Security=True;TrustServerCertificate=True");

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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
