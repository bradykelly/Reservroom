using System.Windows;
using Reservroom.Models;
using Reservroom.Services;
using Reservroom.Stores;
using Reservroom.ViewModels;

namespace Reservroom;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly Hotel _hotel = new Hotel("Kelly Suites");
    private readonly NavigationStore _navigationStore = new NavigationStore();

    protected override void OnStartup(StartupEventArgs e)
    {
        _navigationStore.CurrentViewModel = CreateReservationListingViewModel();

        MainWindow = new MainWindow
        {
            DataContext = new MainViewModel(_navigationStore)
        };

        MainWindow.Show();

        base.OnStartup(e);
    }

    private MakeReservationViewModel CreateMakeReservationViewModel()
    {
        return new MakeReservationViewModel(_hotel, new NavigationService(_navigationStore, CreateReservationListingViewModel));
    }

    private ReservationListingViewModel CreateReservationListingViewModel()
    {
        return new ReservationListingViewModel(_hotel, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
    }
}
