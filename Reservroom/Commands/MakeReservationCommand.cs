using System.ComponentModel;
using System.Windows;
using Reservroom.Exceptions;
using Reservroom.Models;
using Reservroom.Services;
using Reservroom.ViewModels;

namespace Reservroom.Commands;

public class MakeReservationCommand : CommandBase
{
    private readonly MakeReservationViewModel _viewModel;
    private readonly Hotel _hotel;
    private readonly NavigationService _navigationService;

    public MakeReservationCommand(
        MakeReservationViewModel makeReservationViewModel, 
        Hotel hotel,
        NavigationService navigationService)
    {
        _viewModel = makeReservationViewModel;
        _hotel = hotel;
        _navigationService = navigationService;
        _viewModel.PropertyChanged += OnViewModelOnPropertyChanged;
    }

    private void OnViewModelOnPropertyChanged(object? sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName == nameof(_viewModel.Username))
        {
            OnCanExecuteChanged();
        }
    }

    public override bool CanExecute(object? parameter)
    {
        return !string.IsNullOrWhiteSpace(_viewModel.Username) && base.CanExecute(parameter);
    }

    public override void Execute(object? parameter)
    {
        var reservation = new Reservation(
            new RoomId(_viewModel.FloorNumber, _viewModel.RoomNumber),
            _viewModel.Username,
            _viewModel.StartDate,
            _viewModel.EndDate);

        try
        {
            _hotel.MakeReservation(reservation);

            MessageBox.Show("Room successfully reserved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            _navigationService.Navigate();
        }
        catch (ReservationConflictException)
        {
            MessageBox.Show("This room is already taken.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
