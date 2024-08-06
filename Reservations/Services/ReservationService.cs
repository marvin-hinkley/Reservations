using Reservations.Models;

namespace Reservations.Services;

public class ReservationService(IReservationRepository reservationRepository) : IReservationService
{
    public async Task<IEnumerable<Reservation>> GetAvailableReservations(TimeRange? timeRange = null, CancellationToken cancellationToken = default)
    {
        return await reservationRepository.GetAvailableReservations(timeRange, cancellationToken);
    }

    public async Task UpdateReservations(IEnumerable<Reservation> reservations, CancellationToken cancellationToken = default)
    {
        await reservationRepository.AddAvailableReservations(reservations.ToList(), cancellationToken);
    }

    public async Task ScheduleReservation(Guid reservationId, Guid clientId, CancellationToken cancellationToken = default)
    {
        await reservationRepository.ScheduleReservation(reservationId, clientId, cancellationToken);
    }

    public async Task ConfirmReservation(Guid id, CancellationToken cancellationToken = default)
    {
        await reservationRepository.ConfirmReservation(id, cancellationToken);
    }
}