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
    }
}