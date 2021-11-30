using System.Collections.ObjectModel;
using System.Windows.Input;
using Reservroom.Commands;
using Reservroom.Models;
using Reservroom.Services;

namespace Reservroom.ViewModels;

public class ReservationListingViewModel : ViewModelBase
{
    private readonly Hotel _hotel;
    private readonly ObservableCollection<ReservationViewModel> _reservations;

    public IEnumerable<ReservationViewModel> Reservations => _reservations;

    public ICommand MakeReservationCommand { get; }

    public ReservationListingViewModel(Hotel hotel, NavigationService makeReservationNavigationService)
    {
        _hotel = hotel;
        _reservations = new ObservableCollection<ReservationViewModel>();

        MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);

        UpdateReservations();

    }

    private void UpdateReservations()
    {
        _reservations.Clear();

        foreach (var item in _hotel.GetAllReservations())
        {
            var viewModel = new ReservationViewModel(item);
            _reservations.Add(viewModel);
        }
    }
}
