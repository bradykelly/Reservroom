using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservroom.Stores;
using Reservroom.ViewModels;

namespace Reservroom.Services;

public class NavigationService
{
    private readonly NavigationStore _navigationStore;
    private readonly Func<ViewModelBase> _createViewModel;

    public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
    {
        _navigationStore = navigationStore;
        this._createViewModel = createViewModel;
    }

    public void Navigate()
    {
        _navigationStore.CurrentViewModel = _createViewModel();
    }
}
