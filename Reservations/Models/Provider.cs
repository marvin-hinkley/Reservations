namespace Reservations.Models;

public class Provider : Person
{
    public ProviderField Field { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}

public enum ProviderField
{
    Rheumatology,
    Cardiology,
    Oncology,
    Podiatry
}