using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservroom.Models;

namespace Reservroom.Services.ReservationCreators;

public interface IReservationCreator
{
    public Task CreateReservation(Reservation reservation);
}
