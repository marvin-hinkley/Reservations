using Microsoft.EntityFrameworkCore;
using Reservations.Models;

namespace Reservations;

public class ReservationContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
            .HasKey(bc => bc.Id);
        modelBuilder.Entity<Reservation>()
            .HasOne(bc => bc.Provider)
            .WithMany(b => b.Reservations)
            .HasForeignKey(bc => bc.Id);  
        modelBuilder.Entity<Reservation>()
            .HasOne(bc => bc.Client)
            .WithMany(c => c.Reservations)
            .HasForeignKey(bc => bc.ClientId);

        modelBuilder
            .Entity<Client>()
            .HasData(
                new Client
                {
                    Id = Guid.Parse("b385f350-e17a-42df-95ad-1722ae9df831"),
                    FirstName = "Tom",
                    LastName = "Tom"
                }
            );
        modelBuilder
            .Entity<Provider>()
            .HasData(
                new Provider
                {
                    Id = Guid.Parse("a06cb0b4-7b9b-423b-96fc-14ff2efa7ce9"),
                    FirstName = "Bob",
                    LastName = "Bob",
                    Field = ProviderField.Rheumatology
                }
            );
    }
}