using System;
using System.Windows.Input;
using Reservroom.Commands;
using Reservroom.Models;

namespace Reservroom.ViewModels;

public class MakeReservationViewModel : ViewModelBase
{
    private string _username = string.Empty;

    public string Username
    {
        get => _username;
        set
        {
            if (_username != value)
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
    }

    private int _floorNumber;

    public int FloorNumber
    {
        get => _floorNumber;
        set
        {
            if (_floorNumber != value)
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }
    }

    private int _roomNumber;

    public int RoomNumber
    {
        get => _roomNumber;
        set
        {
            if (_roomNumber != value)
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }
    }

    private DateTime _startDate = new(2021, 11, 22);

    public DateTime StartDate
    {
        get => _startDate;
        set
        {
            if (_startDate != value)
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
    }

    private DateTime _endDate = new(2021, 11, 27);

    public DateTime EndDate
    {
        get => _endDate;
        set
        {
            if (_endDate != value)
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }
    }

    public ICommand SubmitCommand { get; }

    public ICommand CancelCommand { get; }

    public MakeReservationViewModel(Hotel hotel)
    {
        SubmitCommand = new MakeReservationCommand(this, hotel);
        CancelCommand = new CancelMakeReservationCommand();
    }
}
