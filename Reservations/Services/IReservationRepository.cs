using Reservations.Models;

namespace Reservations.Services;

public interface IReservationRepository
{
    Task<List<Reservation>> GetAvailableReservations(
        TimeRange? timeRange = null,
        CancellationToken cancellationToken = default
    );

    Task AddAvailableReservations(
        List<Reservation> reservations,
        CancellationToken cancellationToken = default
    );

    Task ScheduleReservation(
        Guid reservationId,
        Guid clientId,
        CancellationToken cancellationToken = default
    );
    
    Task ConfirmReservation(
        Guid id,
        CancellationToken cancellationToken = default
    );
}