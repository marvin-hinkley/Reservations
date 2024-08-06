using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Reservations.Models;
using Reservations.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Reservations API",
            Description = "Manages appointment reservations"
        });
    });

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(
    options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

// Update available reservations
app.MapPost("/reservations/available/{providerId:guid}",
    async ([FromRoute] Guid providerId, [FromBody] IEnumerable<Reservation> reservations, IReservationService reservationService) =>
    {
        await reservationService.UpdateReservations(reservations, providerId);
    })
    .WithName("UpdateAvailableReservations")
    .WithSummary("Update available reservations")
    .WithDescription("Allows provider to update their availability");

// Get available reservations. optionally within range, optionally with specific provider
app.MapGet("/reservations/available/{providerId:guid?}",
    async ([FromRoute] Guid? providerId, [FromBody] TimeRange? timeRange, IReservationService reservationService) =>
    {
        var available = await reservationService.GetAvailableReservations(timeRange, providerId);
        return available;
    })
    .WithName("GetAvailableReservations")
    .WithSummary("Get available reservations")
    .WithDescription("Optionally based upon time range and specific provider");

// Schedule against an available reservation
app.MapPut("/reservations/schedule",
    async ([FromBody] Reservation reservation, IReservationService reservationService) =>
    {
        await reservationService.ScheduleReservation(reservation);
    })
    .WithName("ScheduleReservation")
    .WithSummary("Schedule a new appointment");

// Confirm an existing reservation
app.MapPut("/reservations/confirm/{id:guid}",
    async ([FromRoute] Guid id, IReservationService reservationService) =>
    {
        await reservationService.ConfirmReservation(id);
    })
    .WithName("ConfirmReservation")
    .WithSummary("Confirm scheduled appointment");

app.Run();