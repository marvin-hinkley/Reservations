namespace Reservations;

public class DbInitializer(ReservationContext context)
{
    public void Run()
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}