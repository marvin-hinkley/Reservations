using Reservations.Models;

namespace Reservations.Services;

public interface IReservationService
{
    private static List<Reservation> _reservations = [];
    
    // Retrieves list of available reservations
    Task<IEnumerable<Reservation>> GetAvailableReservations(
        TimeRange? timeRange = null,
        Guid? providerId = null,
        CancellationToken cancellationToken = default
    );

    // Updates available reservations for a provider
    Task UpdateReservations(
        IEnumerable<Reservation> reservations,
        Guid providerId,
        CancellationToken cancellationToken = default
    );

    // Schedule a reservation for a particular time
    Task ScheduleReservation(
        Reservation reservation,
        CancellationToken cancellationToken = default
    );
    
    // Confirm a scheduled resrevation
    Task ConfirmReservation(
        Guid id,
        CancellationToken cancellationToken = default
    );
}