using AutoRent.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AutoRent.Data
{
    public class AutoRentDbContext : DbContext
    {
        public AutoRentDbContext(DbContextOptions<AutoRentDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Restrict);


            // Soft Delete Filter
            modelBuilder.Entity<Customer>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Car>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Rental>().HasQueryFilter(c => !c.IsDeleted);

        }
    }
}


