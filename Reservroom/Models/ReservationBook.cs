using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservroom.Exceptions;

namespace Reservroom.Models
{
    public class ReservationBook
    {
        private List<Reservation> _reservations = new();

        public IEnumerable<Reservation> GetReservationsForUser(string username)
        {
            return _reservations.Where(r => string.Equals(r.UserName, username, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservations;
        }

        public void AddReservation(Reservation reservation)
        {
            foreach (var existingReservation in _reservations)
            {
                if (existingReservation.Conflicts(reservation))
                {
                    throw new ReservationConflictException(existingReservation, reservation);
                }
            }

            _reservations.Add(reservation);
        }
    }
}
