using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InsuranceAPIs.Models
{
    public partial class testDBContext : DbContext
    {
        public testDBContext()
        {
        }

        public testDBContext(DbContextOptions<testDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PentaDetail> PentaDetails { get; set; } = null!;
        public virtual DbSet<PentaDetail1> PentaDetails1 { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=10.150.8.151;User ID=sa;Password=Sa@sstc654321;Database=testDB;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PentaDetail>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.IdNumber).HasMaxLength(100);

                entity.Property(e => e.MemIdNumber).HasMaxLength(100);

                entity.Property(e => e.QuoteId).HasMaxLength(50);

                entity.Property(e => e.QuoteNo).HasMaxLength(1);

                entity.Property(e => e.SegmentCode).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);
            });

            modelBuilder.Entity<PentaDetail1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PentaDetails", "Domestic");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.MemIdNumber).HasMaxLength(100);

                entity.Property(e => e.MemQuoteId).HasMaxLength(50);

                entity.Property(e => e.ProposerIdNumber).HasMaxLength(100);

                entity.Property(e => e.ProposerQuoteId).HasMaxLength(50);

                entity.Property(e => e.SegmentCode).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
