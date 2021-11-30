using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservroom.Database;
using Reservroom.Models;

namespace Reservroom.Services.ReservationCreators;

public class SqliteReservationCreator : IReservationCreator
{
    private readonly ReservroomDbContextFactory _dbContextFactory;

    public SqliteReservationCreator(ReservroomDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task CreateReservation(Reservation reservation)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        var dto = ToReservationDto(reservation);

        context.Reservations!.Add(dto);
        await context.SaveChangesAsync();
    }

    private ReservationDto ToReservationDto(Reservation reservation)
    {
        return new ReservationDto
        {
            FloorNumber = reservation.RoomId.FloorNumber,
            RoomNumber = reservation.RoomId.RoomNumber,
            UserName = reservation.UserName,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime
        };
    }
}
