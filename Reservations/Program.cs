using Microsoft.AspNetCore.Mvc;
using Reservations.Models;
using Reservations.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IReservationService>();

var app = builder.Build();

// Update available reservations
app.MapPost("/reservations/available/{providerId:guid}",
    async ([FromRoute] Guid providerId, IEnumerable<Reservation> reservations, IReservationService reservationService) =>
    {
        await reservationService.UpdateReservations(reservations, providerId);
    });
// Get available reservations. optionally within range, optionally with specific provider
app.MapGet("/reservations/available/{providerId:guid?}",
    async ([FromRoute] Guid? providerId, TimeRange? timeRange, IReservationService reservationService) =>
    {
        var available = await reservationService.GetAvailableReservations(timeRange);
        return available;
    });
// Schedule against an available reservation
app.MapPut("/reservations/schedule",
    async (Reservation reservation, IReservationService reservationService) =>
    {
        await reservationService.ScheduleReservation(reservation);
    });
// Confirm an existing reservation
app.MapPut("/reservations/confirm/{id:guid}",
    async ([FromRoute] Guid id, IReservationService reservationService) =>
    {
        await reservationService.ConfirmReservation(id);
    });

app.Run();