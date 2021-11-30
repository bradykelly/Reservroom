using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Reservroom.Database;

public class ReservroomDbContextFactory
{
    private string _connectionString;

    public ReservroomDbContextFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public ReservroomDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

        return new ReservroomDbContext(options);
    }
}
