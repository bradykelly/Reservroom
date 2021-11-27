using System.Collections.Generic;

namespace Reservroom.Models;

public class Hotel
{
    private readonly ReservationBook _reservationBook = new();

    public string Name { get; }

    public Hotel(string name)
    {
        Name = name;
    }

    public IEnumerable<Reservation> GetReservationsForUser(string username)
    {
        return _reservationBook.GetReservationsForUser(username);
    }

    public IEnumerable<Reservation> GetAllReservations()
    {
        return _reservationBook.GetAllReservations();
    }

    public void MakeReservation(Reservation reservation)
    {
        _reservationBook.AddReservation(reservation);
    }
}
