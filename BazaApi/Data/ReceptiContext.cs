using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Recepti.Models;

namespace Recepti.Data
{
    public partial class ReceptiContext : DbContext
    {
        public ReceptiContext()
        {
        }

        public ReceptiContext(DbContextOptions<ReceptiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategorija> Kategorijas { get; set; } = null!;
        public virtual DbSet<Korisnik> Korisniks { get; set; } = null!;
        public virtual DbSet<Recenzije> Recenzijes { get; set; } = null!;
        public virtual DbSet<Recept> Recepts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategorija>(entity =>
            {
                entity.ToTable("Kategorija");

                entity.HasIndex(e => e.Id, "IX_Kategorija_ID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.ToTable("Korisnik");

                entity.HasIndex(e => e.Id, "IX_Korisnik_ID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Recenzije>(entity =>
            {
                entity.ToTable("Recenzije");

                entity.HasIndex(e => e.Id, "IX_Recenzije_ID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idkorisnik).HasColumnName("IDkorisnik");

                entity.Property(e => e.Idrecept).HasColumnName("IDrecept");

                entity.HasOne(d => d.IdreceptNavigation)
                    .WithMany(p => p.Recenzijes)
                    .HasForeignKey(d => d.Idrecept)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Recept>(entity =>
            {
                entity.ToTable("Recept");

                entity.HasIndex(e => e.Id, "IX_Recept_ID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idkategorije).HasColumnName("IDkategorije");

                entity.Property(e => e.Idkorisnik).HasColumnName("IDkorisnik");

                entity.HasOne(d => d.IdkategorijeNavigation)
                    .WithMany(p => p.Recepts)
                    .HasForeignKey(d => d.Idkategorije)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdkorisnikNavigation)
                    .WithMany(p => p.Recepts)
                    .HasForeignKey(d => d.Idkorisnik)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
