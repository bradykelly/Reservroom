using Reservroom.Models;

namespace Reservroom.ViewModels;

public class ReservationViewModel : ViewModelBase
{
    public readonly Reservation _reservation;

    public string RoomId => _reservation.RoomId.ToString();
    public string Username => _reservation.UserName;
    public string StartDate => _reservation.StartTime.ToString("dd/MM/yyyy");
    public string EndDate => _reservation.EndTime.ToString("dd/MM/yyyy");

    public ReservationViewModel(Reservation reservation)
    {
        _reservation = reservation;
    }
}
