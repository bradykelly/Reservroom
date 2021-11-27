using Reservroom.Models;
using Reservroom.Stores;

namespace Reservroom.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;

    public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        _navigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
    }

    private void CurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
