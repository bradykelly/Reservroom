using System.Windows;
using Reservroom.Models;
using Reservroom.ViewModels;

namespace Reservroom;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly Hotel _hotel = new Hotel("Kelly Suites");

    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow
        {
            DataContext = new MainViewModel(_hotel)
        };

        MainWindow.Show();

        base.OnStartup(e);
    }
}
