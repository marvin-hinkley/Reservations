using Microsoft.EntityFrameworkCore;
using Reservations.Models;

namespace Reservations.Services;

public class ReservationRepository(ReservationContext reservationContext) : IReservationRepository
{
    private ReservationContext ReservationContext { get; set; } = reservationContext;

    public async Task<List<Reservation>> GetAvailableReservations(TimeRange? timeRange = null, CancellationToken cancellationToken = default)
    {
        return timeRange != null
            ? await ReservationContext.Reservations.Where(r =>
                timeRange.Start <= r.Time &&
                r.Time <= timeRange.End &&
                r.State == ReservationState.Available
              ).ToListAsync(cancellationToken: cancellationToken)
            : await ReservationContext.Reservations.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task AddAvailableReservations(List<Reservation> reservations, CancellationToken cancellationToken = default)
    {
        await ReservationContext.Reservations.AddRangeAsync(reservations, cancellationToken);
        await ReservationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task ScheduleReservation(Guid reservationId, Guid clientId, CancellationToken cancellationToken = default)
    {
        var availability = await ReservationContext.Reservations.FirstOrDefaultAsync(
            r => r.Id == reservationId,
            cancellationToken: cancellationToken
        );
        if (availability == null)
        {
            return;
        }
        
        availability.ClientId = clientId;
        availability.State = ReservationState.Scheduled;

        await ReservationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task ConfirmReservation(Guid id, CancellationToken cancellationToken = default)
    {
        var reservation = await ReservationContext.Reservations.FirstOrDefaultAsync(
            r => r.Id == id,
            cancellationToken: cancellationToken
        );
        if (reservation == null)
        {
            return;
        }
        
        reservation.State = ReservationState.Confirmed;
        await ReservationContext.SaveChangesAsync(cancellationToken);
    }
}