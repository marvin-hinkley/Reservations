using Reservations.Models;

namespace Reservations.Services;

public class ReservationService : IReservationService
{
    public Task<IEnumerable<Reservation>> GetAvailableReservations(TimeRange? timeRange = null, Guid? providerId = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateReservations(IEnumerable<Reservation> reservations, Guid providerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task ScheduleReservation(Reservation reservation, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task ConfirmReservation(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}