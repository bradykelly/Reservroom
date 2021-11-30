using Reservroom.Exceptions;
using Reservroom.Services.ReservationConflictValidators;
using Reservroom.Services.ReservationCreators;
using Reservroom.Services.ReservationProviders;

namespace Reservroom.Models;

public class ReservationBook
{
    private IReservationProvider _reservationProvider;
    private IReservationCreator _reservationCreator;
    private IReservationConflictValidator _reservationConflictValidator;

    public ReservationBook(IReservationProvider reservationProvider, IReservationCreator reservationCreator, IReservationConflictValidator reservationConflictValidator)
    {
        _reservationProvider = reservationProvider;
        _reservationCreator = reservationCreator;
        _reservationConflictValidator = reservationConflictValidator;
    }

    public async Task<IEnumerable<Reservation>> GetAllReservations()
    {
        return await _reservationProvider.GetAllReservations();
    }

    public async Task AddReservation(Reservation reservation)
    {
        var conflictingReservation = await _reservationConflictValidator.GetConflictingReservation(reservation);

        if (conflictingReservation is not null)
        {
            throw new ReservationConflictException(conflictingReservation, reservation);
        }

        await _reservationCreator.CreateReservation(reservation);
    }
}
