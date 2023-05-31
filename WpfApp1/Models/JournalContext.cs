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

    public virtual DbSet<C189> C189s { get; set; }

    public virtual DbSet<Fio> Fios { get; set; }

    public virtual DbSet<Gruppa> Gruppas { get; set; }

    public virtual DbSet<Ip192> Ip192s { get; set; }

    public virtual DbSet<Ip193> Ip193s { get; set; }

    public virtual DbSet<Ip195> Ip195s { get; set; }

    public virtual DbSet<JournalEvaluation> JournalEvaluations { get; set; }

    public virtual DbSet<P202> P202s { get; set; }

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

        modelBuilder.Entity<C189>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07A7F13944");

            entity.ToTable("C-189");

            entity.Property(e => e.Gruppa).HasColumnName("gruppa");
        });

        modelBuilder.Entity<Fio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC0713321EAB");

            entity.ToTable("FIO");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Gruppa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07A36FB69F");

            entity.ToTable("Gruppa");

            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Gruppa1).HasColumnName("gruppa");
            entity.Property(e => e.Numberlesson).HasColumnName("numberlesson");
            entity.Property(e => e.OffsetNotOffset).HasColumnName("offset/not offset");
        });

        modelBuilder.Entity<Ip192>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC077FA0D897");

            entity.ToTable("IP-192");

            entity.Property(e => e.Gruppa).HasColumnName("gruppa");
        });

        modelBuilder.Entity<Ip193>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07809475DC");

            entity.ToTable("IP-193");

            entity.Property(e => e.Gruppa).HasColumnName("gruppa");
        });

        modelBuilder.Entity<Ip195>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07EA904355");

            entity.ToTable("IP-195");

            entity.Property(e => e.Gruppa).HasColumnName("gruppa");
        });

        modelBuilder.Entity<JournalEvaluation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07D1B4B36A");

            entity.ToTable("JournalEvaluation");

            entity.Property(e => e.Gruppa).HasColumnName("gruppa");
        });

        modelBuilder.Entity<P202>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07F87613BD");

            entity.ToTable("P-202");

            entity.Property(e => e.Gruppa).HasColumnName("gruppa");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
