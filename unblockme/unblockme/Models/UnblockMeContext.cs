using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace unblockme.Models
{
    public partial class UnblockMeContext : IdentityDbContext<Users2>
    {
        public UnblockMeContext()
        {
        }

        public UnblockMeContext(DbContextOptions<UnblockMeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Users2> Users { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-MQBHEA6\\SQLEXPRESS;Database=UnblockMe;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Cars>(entity =>
            {
                entity.ToTable("cars");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasMaxLength(20);

                entity.Property(e => e.IdOwner).HasColumnName("idOwner");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasColumnName("make")
                    .HasMaxLength(20);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasMaxLength(20);

                entity.Property(e => e.Plate)
                    .IsRequired()
                    .HasColumnName("plate")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Drivers>(entity =>
            {
                entity.ToTable("drivers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCar).HasColumnName("id_car");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdCarNavigation)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.IdCar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_drivers_cars");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_drivers_AspNetUsers");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.ToTable("reviews");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body");

                entity.Property(e => e.IdPoster).HasColumnName("id_poster");

                entity.Property(e => e.IdReciever).HasColumnName("id_reciever");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.IdRecieverNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.IdReciever)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reviews_AspNetUsers");
            });

            modelBuilder.Entity<Users2>(entity =>
            {
                entity.ToTable("AspNetUsers");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .HasMaxLength(25);

                entity.Property(e => e.Rating).HasColumnName("Rating");

                entity.Property(e => e.RatingCount).HasColumnName("RatingCount");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
