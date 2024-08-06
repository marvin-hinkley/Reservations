using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Reservations.Models;

public class Reservation
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    
    public Guid ProviderId { get; set; }
    [JsonIgnore]
    public Provider Provider { get; set; }
    public Guid? ClientId { get; set; }
    [JsonIgnore]
    public Client Client { get; set; }
    
    // Beginning time of reservation
    public DateTime Time { get; set; }
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