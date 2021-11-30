using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reservroom.Database;
using Reservroom.Models;

namespace Reservroom.Services.ReservationProviders;

public class SqliteReservationProvider : IReservationProvider
{
    private readonly ReservroomDbContextFactory _dbContextFactory;

    public SqliteReservationProvider(ReservroomDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<Reservation>> GetAllReservations()
    {
        await using var context = _dbContextFactory.CreateDbContext();
        var dtos = await context.Reservations!.ToListAsync();

        return dtos.Select(ToReservation);
    }

    private static Reservation ToReservation(ReservationDto dto)
    {
        return new Reservation(new RoomId(dto.FloorNumber, dto.RoomNumber), dto.UserName!, dto.StartTime, dto.EndTime);
    }
}
