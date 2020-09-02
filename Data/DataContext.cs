using DGT.Models;
using Microsoft.EntityFrameworkCore;

namespace DGT.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt ) : base(opt){ }

        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<ConductorVehiculo> ConductorVehiculos { get; set; }
        public DbSet<Infraccion> Infracciones { get; set; }
        public DbSet<Sancion> Sanciones { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConductorVehiculo>()
                .HasKey(cv => new { cv.Dni, cv.Matricula });
            
            modelBuilder.Entity<ConductorVehiculo>()
                .HasOne(cv => cv.Conductor)
                .WithMany(c => c.ConductorVehiculos)
                .HasForeignKey(cv => cv.Dni);
            
            modelBuilder.Entity<ConductorVehiculo>()
                .HasOne(cv => cv.Vehiculo)
                .WithMany(v => v.ConductorVehiculos)
                .HasForeignKey(cv => cv.Matricula);
        }      
    }

}