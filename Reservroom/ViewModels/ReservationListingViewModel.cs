﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using Reservroom.Commands;
using Reservroom.Models;
using Reservroom.Services;

namespace Reservroom.ViewModels;

public class ReservationListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<ReservationViewModel> _reservations;

    public IEnumerable<ReservationViewModel> Reservations => _reservations;

    public ICommand LoadReservationsCommand { get; }
    public ICommand MakeReservationCommand { get; }

    public ReservationListingViewModel(Hotel hotel, NavigationService makeReservationNavigationService)
    {
        _reservations = new ObservableCollection<ReservationViewModel>();

        LoadReservationsCommand = new LoadReservationsCommand(hotel, this);
        MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);
    }

    public static ReservationListingViewModel LoadViewModel(Hotel hotel, NavigationService makeReservationNavigationService)
    {
        var viewModel = new ReservationListingViewModel(hotel, makeReservationNavigationService);

        viewModel.LoadReservationsCommand.Execute(null);

        return viewModel;
    }

    public void UpdateReservations(IEnumerable<Reservation> reservations)
    {
        _reservations.Clear();

        foreach (var item in reservations)
        {
            var viewModel = new ReservationViewModel(item);
            _reservations.Add(viewModel);
        }
    }
}
