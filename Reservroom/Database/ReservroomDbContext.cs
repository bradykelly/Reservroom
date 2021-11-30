using Microsoft.EntityFrameworkCore;

namespace Reservroom.Database;

public class ReservroomDbContext: DbContext
{
    public ReservroomDbContext(DbContextOptions options): base(options)
    {
    }

    public DbSet<ReservationDto>? Reservations { get; set; }
}
