using Reservations.Models;

namespace Reservations.Services;

public interface IReservationService
{
    // Retrieves list of available reservations
    Task<IEnumerable<Reservation>> GetAvailableReservations(
        TimeRange? timeRange = null,
        Guid? providerId = null,
        CancellationToken cancellationToken = default
    );

    Task UpdateReservations(
        IEnumerable<Reservation> reservations,
        Guid providerId,
        CancellationToken cancellationToken = default
    );

    Task ScheduleReservation(
        Reservation reservation,
        CancellationToken cancellationToken = default
    );
    
    Task ConfirmReservation(
        Guid id,
        CancellationToken cancellationToken = default
    );
}