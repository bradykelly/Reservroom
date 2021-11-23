using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Reservroom.Exceptions;
using Reservroom.Models;

namespace Reservroom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new("Kelly Suites");

            try
            {
                hotel.MakeReservation(new Reservation(
                    new RoomId(0, 3),
                    "BradyKelly",
                    new DateTime(2000, 1, 1),
                    new DateTime(2000, 1, 2)));
                hotel.MakeReservation(new Reservation(
                    new RoomId(0, 3),
                    "BradyKelly",
                    new DateTime(2000, 1, 1),
                    new DateTime(2000, 1, 4)));
            }
            catch (ReservationConflictException ex)
            {


            }

            var reservations = hotel.GetReservationsForUser("bradykelly");

            base.OnStartup(e);
        }
    }
}
