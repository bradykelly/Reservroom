using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservroom.Models;
using Reservroom.ViewModels;

namespace Reservroom.Commands;

public class LoadReservationsCommand : AsyncCommandBase
{
    private readonly Hotel _hotel;
    private readonly ReservationListingViewModel _viewModel;

    public LoadReservationsCommand(Hotel hotel, ReservationListingViewModel viewModel)
    {
        _hotel = hotel;
        _viewModel = viewModel;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        try
        {
            IEnumerable<Reservation> reservations = await _hotel.GetAllReservations();
            _viewModel.UpdateReservations(reservations);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to load reservations: {ex.GetBaseException().Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
