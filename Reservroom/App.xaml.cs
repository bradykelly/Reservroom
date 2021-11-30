using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Reservroom.Database;
using Reservroom.Models;
using Reservroom.Services;
using Reservroom.Services.ReservationConflictValidators;
using Reservroom.Services.ReservationCreators;
using Reservroom.Services.ReservationProviders;
using Reservroom.Stores;
using Reservroom.ViewModels;

namespace Reservroom;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    private const string CONNECTION_STRING = "data source=reservroom.db";

    private readonly Hotel _hotel;
    private readonly NavigationStore _navigationStore;
    private readonly ReservroomDbContextFactory _reservroomDbContextFactory;

    public App()
    {
        _reservroomDbContextFactory = new ReservroomDbContextFactory(CONNECTION_STRING);
        IReservationProvider? reservationProvider = new SqliteReservationProvider(_reservroomDbContextFactory);
        IReservationCreator? reservationCreator = new SqliteReservationCreator(_reservroomDbContextFactory);
        IReservationConflictValidator? reservationConflictValidator = new SqliteReservationConflictValidator(_reservroomDbContextFactory);
        var reservationBook = new ReservationBook(reservationProvider, reservationCreator, reservationConflictValidator);
        _hotel = new Hotel("Kelly Suites", reservationBook);
        _navigationStore = new NavigationStore();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        using var dbcontext = _reservroomDbContextFactory.CreateDbContext();
        dbcontext.Database.Migrate();

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
        return ReservationListingViewModel.LoadViewModel(_hotel, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
    }
}
