using Reservroom.ViewModels;

namespace Reservroom.Stores;

public class NavigationStore
{
    private ViewModelBase? _currentViewModel;

    public Action? CurrentViewModelChanged;

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}
