using Microsoft.EntityFrameworkCore;
using Reservroom.Database;
using Reservroom.Models;

namespace Reservroom.Services.ReservationConflictValidators;

public class SqliteReservationConflictValidator : IReservationConflictValidator
{
    private readonly ReservroomDbContextFactory _dbContextFactory;

    public SqliteReservationConflictValidator(ReservroomDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<Reservation?> GetConflictingReservation(Reservation reservation)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        var dto = await context.Reservations!
            .Where(r => r.FloorNumber == reservation.RoomId.FloorNumber)
            .Where(r => r.RoomNumber == reservation.RoomId.RoomNumber)
            .Where(r => r.EndTime > reservation.StartTime)
            .Where(r => r.StartTime < reservation.EndTime )
            .FirstOrDefaultAsync();

        return dto is null ? null : ToReservation(dto);
    }

    private static Reservation ToReservation(ReservationDto dto)
    {
        return new Reservation(new RoomId(dto.FloorNumber, dto.RoomNumber), dto.UserName!, dto.StartTime, dto.EndTime);
    }
}
