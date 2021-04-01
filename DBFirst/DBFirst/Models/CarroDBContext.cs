using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirst.Models
{
    public partial class CarroDBContext : DbContext
    {
        public CarroDBContext()
        {
        }

        public CarroDBContext(DbContextOptions<CarroDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carros> Carros { get; set; }
        public virtual DbSet<Table> Table { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=CarroDB;User ID=DESKTOP-P1M7U70\\kalel;Password=39074318kjA; Trusted_Connection=True"; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carros>(entity =>
            {
                entity.HasKey(e => e.CarroId);

                entity.Property(e => e.Marca).HasMaxLength(50);

                entity.Property(e => e.Nome).HasMaxLength(50);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}
