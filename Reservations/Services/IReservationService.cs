﻿using Reservations.Models;

namespace Reservations.Services;

public interface IReservationService
{
    // Retrieves list of available reservations
    Task<IEnumerable<Reservation>> GetAvailableReservations(
        TimeRange? timeRange = null,
        CancellationToken cancellationToken = default
    );

    // Updates available reservations for a provider
    Task UpdateReservations(
        IEnumerable<Reservation> reservations,
        CancellationToken cancellationToken = default
    );

    // Schedule a reservation for a particular time
    Task ScheduleReservation(
        Guid reservationId,
        Guid clientId,
        CancellationToken cancellationToken = default
    );
    
    // Confirm a scheduled reservation
    Task ConfirmReservation(
        Guid id,
        CancellationToken cancellationToken = default
    );
}