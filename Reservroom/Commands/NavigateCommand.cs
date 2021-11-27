using System;
using Reservroom.Models;
using Reservroom.Services;
using Reservroom.Stores;
using Reservroom.ViewModels;

namespace Reservroom.Commands;

internal class NavigateCommand : CommandBase
{
    private readonly NavigationService _navigationService;

    public NavigateCommand(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object? parameter)
    {
        _navigationService.Navigate();
    }
}
