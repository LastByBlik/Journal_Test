using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.Models;

public partial class JournalContext : DbContext
{
    public JournalContext()
    {
    }

    public JournalContext(DbContextOptions<JournalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Authorization> Authorizations { get; set; }

    public virtual DbSet<Fio> Fios { get; set; }

    public virtual DbSet<Gruppa> Gruppas { get; set; }

    public virtual DbSet<JournalEvaluation> JournalEvaluations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Journal;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Authorization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC070ADB6680");

            entity.ToTable("Authorization");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
        });

        modelBuilder.Entity<Fio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC0713321EAB");

            entity.ToTable("FIO");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Gruppa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC073748E8F3");

            entity.ToTable("Gruppa");

            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Gruppa1).HasColumnName("gruppa");
            entity.Property(e => e.Namberlesson).HasColumnName("namberlesson");
            entity.Property(e => e.OffsetNotOffset).HasColumnName("offset/not offset");
        });

        modelBuilder.Entity<JournalEvaluation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07D1B4B36A");

            entity.ToTable("JournalEvaluation");

            entity.Property(e => e.Gruppa).HasColumnName("gruppa");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
