namespace Reservations.Models;

public class Reservation
{
    public Guid Id { get; set; }
    
    public Guid ProviderId { get; set; }
    public Provider Provider { get; set; }
    public Guid? ClientId { get; set; }
    public Client Client { get; set; }
    
    // Beginning time of reservation
    public DateTime Time { get; set; }
    // Duration of reservation in minutes
    public int Duration { get; set; } = 15;
    public ReservationState State { get; set; } = ReservationState.Available;
}

public enum ReservationState
{
    Available,
    // Confirmed reservation
    Confirmed,
    // Cancelled reservation
    Cancelled,
    // Unconfirmed reservation
    Scheduled,
    // Past reservation, unattended by client
    Missed,
    // Past reservation, attended by client
    Complete
} 