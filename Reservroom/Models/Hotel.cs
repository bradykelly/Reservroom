﻿namespace Reservroom.Models;

public class Hotel
{
    private readonly ReservationBook _reservationBook;

    public string Name { get; }

    public Hotel(string name, ReservationBook reservationBook)
    {
        _reservationBook = reservationBook;
        Name = name;
    }

    public async Task<IEnumerable<Reservation>> GetAllReservations()
    {
        return await _reservationBook.GetAllReservations();
    }

    public async Task MakeReservation(Reservation reservation)
    {
        await _reservationBook.AddReservation(reservation);
    }
}
