using Reservroom.Models;

namespace Reservroom.Services.ReservationProviders;

public interface IReservationProvider
{
    public Task<IEnumerable<Reservation>> GetAllReservations();
}
