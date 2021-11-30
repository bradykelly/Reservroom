using System.ComponentModel;
using Reservroom.Exceptions;
using Reservroom.Models;
using Reservroom.Services;
using Reservroom.ViewModels;

namespace Reservroom.Commands;

public class MakeReservationCommand : AsyncCommandBase
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

    public override async Task ExecuteAsync(object? parameter)
    {
        var reservation = new Reservation(
            new RoomId(_viewModel.FloorNumber, _viewModel.RoomNumber),
            _viewModel.Username,
            _viewModel.StartDate,
            _viewModel.EndDate);

        try
        {
            await _hotel.MakeReservation(reservation);

            MessageBox.Show("Room successfully reserved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            _navigationService.Navigate();
        }
        catch (ReservationConflictException)
        {
            MessageBox.Show("This room is already taken.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to make reservation: {ex.GetBaseException().Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
