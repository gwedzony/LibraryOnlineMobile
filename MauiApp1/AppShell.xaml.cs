using MauiApp1.Pages;
using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
    }
}