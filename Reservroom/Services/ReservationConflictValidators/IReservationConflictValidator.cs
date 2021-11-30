using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservroom.Models;

namespace Reservroom.Services.ReservationConflictValidators;

public interface IReservationConflictValidator
{
    public Task<Reservation?> GetConflictingReservation(Reservation reservation);
}
