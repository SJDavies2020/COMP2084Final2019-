using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace F2019Places.Models
{
    public partial class f19Context : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public f19Context()
        {
        }

        public f19Context(DbContextOptions<f19Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Destination> Destination { get; set; }
        public virtual DbSet<Region> Region { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add to get Identity to work so we don't get primary key errors. Bug fix for the identity library
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Photo).IsUnicode(false);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Destination)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Region_Destination");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });
          
        }
    }
}
