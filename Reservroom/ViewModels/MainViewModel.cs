using Reservroom.Models;

namespace Reservroom.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ViewModelBase CurrentViewModel { get; }

    public MainViewModel(Hotel hotel)
    {
        CurrentViewModel = new ReservationListingViewModel();
    }
}
