using System;
using System.Collections.Generic;
using cb_ejercicio1.Models;
using Microsoft.EntityFrameworkCore;

namespace cb_ejercicio1.Data;

public partial class RulesDbContext : DbContext
{
    public RulesDbContext()
    {
    }

    public RulesDbContext(DbContextOptions<RulesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CbcReglaInconsistencia> CbcReglaInconsistencia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=RulesDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CbcReglaInconsistencia>(entity =>
        {
            entity.HasKey(e => e.ReglaId).HasName("PK__cbc_regl__66A783F3CC6EC7C5");

            entity.ToTable("cbc_regla_inconsistencia");

            entity.Property(e => e.Regla)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TipoRegla)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
