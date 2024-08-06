namespace Reservations.Models;

public class Client : Person
{
    public ICollection<Reservation> Reservations { get; set; }
}