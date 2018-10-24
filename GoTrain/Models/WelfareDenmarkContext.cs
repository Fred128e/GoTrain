using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GoTrain.Models
{
    public partial class WelfareDenmarkContext : DbContext
    {
        public WelfareDenmarkContext()
        {
        }

        public WelfareDenmarkContext(DbContextOptions<WelfareDenmarkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Trainingspartners> Trainingspartners { get; set; }
        public virtual DbSet<TrainingsSessions> TrainingsSessions { get; set; }
        public virtual DbSet<TraningsPartnerSession> TraningsPartnerSession { get; set; }
        public virtual DbSet<Trophies> Trophies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=welfaredenmark.database.windows.net;Database= WelfareDenmark;USER ID=welfaredenmark; Password=Welfare_denmark;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingsSessions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<TraningsPartnerSession>(entity =>
            {
                entity.HasKey(e => new { e.TraningsPartnerId, e.TraningsSessionId });

                entity.HasIndex(e => e.TraningsSessionId);

                entity.Property(e => e.TraningsPartnerId).HasColumnName("TraningsPartnerID");

                entity.Property(e => e.TraningsSessionId).HasColumnName("TraningsSessionID");

                entity.HasOne(d => d.TraningsPartner)
                    .WithMany(p => p.TraningsPartnerSession)
                    .HasForeignKey(d => d.TraningsPartnerId);

                entity.HasOne(d => d.TraningsSession)
                    .WithMany(p => p.TraningsPartnerSession)
                    .HasForeignKey(d => d.TraningsSessionId);
            });

            modelBuilder.Entity<Trophies>(entity =>
            {
                entity.HasIndex(e => e.TraningspartnerForeignKey);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.HasOne(d => d.TraningspartnerForeignKeyNavigation)
                    .WithMany(p => p.Trophies)
                    .HasForeignKey(d => d.TraningspartnerForeignKey);
            });
        }
    }
}
