using System.Text.Json.Serialization;

namespace Reservations.Models;

public class Client : Person
{
    [JsonIgnore]
    public ICollection<Reservation> Reservations { get; set; }
}