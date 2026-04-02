using System;
using System.Collections.Generic;
using Herois.Models;
using Microsoft.EntityFrameworkCore;

namespace Herois.BdContextHerois;

public partial class HeroisContext : DbContext
{
    public HeroisContext()
    {
    }

    public HeroisContext(DbContextOptions<HeroisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipe> Equipes { get; set; }

    public virtual DbSet<Heroi> Herois { get; set; }

    public virtual DbSet<Missao> Missaos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Herois;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipe>(entity =>
        {
            entity.HasKey(e => e.IdEquipe).HasName("PK__Equipe__D80524125D41EFC7");

            entity.Property(e => e.IdEquipe).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Heroi>(entity =>
        {
            entity.HasKey(e => e.IdHeroi).HasName("PK__Heroi__C6D83F156BFF2AFE");

            entity.Property(e => e.IdHeroi).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdEquipeNavigation).WithMany(p => p.Herois).HasConstraintName("FK__Heroi__IdEquipe__60A75C0F");
        });

        modelBuilder.Entity<Missao>(entity =>
        {
            entity.HasKey(e => e.IdMissao).HasName("PK__Missao__51FA0AD5F2A03C7C");

            entity.Property(e => e.IdMissao).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdEquipeNavigation).WithMany(p => p.Missaos).HasConstraintName("FK__Missao__IdEquipe__6477ECF3");

            entity.HasOne(d => d.IdHeroiNavigation).WithMany(p => p.Missaos).HasConstraintName("FK__Missao__IdHeroi__656C112C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
