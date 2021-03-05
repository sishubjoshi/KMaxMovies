using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Infosys.KMaxMovies.DataAccessLayer.Models
{
    public partial class KMaxMoviesDBContext : DbContext
    {
        public KMaxMoviesDBContext()
        {
        }

        public KMaxMoviesDBContext(DbContextOptions<KMaxMoviesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Screen> Screen { get; set; }
        public virtual DbSet<Show> Show { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("KMaxMoviesDBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId)
                    .HasColumnName("MovieID")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Screen>(entity =>
            {
                entity.Property(e => e.ScreenId)
                    .HasColumnName("ScreenID")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Multiplex)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.Property(e => e.ShowId)
                    .HasColumnName("ShowID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.MovieId)
                    .IsRequired()
                    .HasColumnName("MovieID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ScreenId)
                    .IsRequired()
                    .HasColumnName("ScreenID")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Show)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Show_Movie_MovieID");

                entity.HasOne(d => d.Screen)
                    .WithMany(p => p.Show)
                    .HasForeignKey(d => d.ScreenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Show_Screen_ScreenID");
            });
        }
    }
}
