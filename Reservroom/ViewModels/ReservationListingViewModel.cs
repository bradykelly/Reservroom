using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Reservroom.Models;

namespace Reservroom.ViewModels;

public class ReservationListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<ReservationViewModel> _reservations;

    public IEnumerable<ReservationViewModel> Reservations => _reservations;

    public ICommand MakeReservationCommand { get; }

    public ReservationListingViewModel()
    {
        _reservations = new ObservableCollection<ReservationViewModel>();

        _reservations.Add(new ReservationViewModel(new Reservation(new RoomId(1, 2), "BradyKelly", DateTime.Now, DateTime.Now)));
        _reservations.Add(new ReservationViewModel(new Reservation(new RoomId(3, 2), "BradyKelly", DateTime.Now, DateTime.Now)));
        _reservations.Add(new ReservationViewModel(new Reservation(new RoomId(2, 4), "BradyKelly", DateTime.Now, DateTime.Now)));
    }
}
