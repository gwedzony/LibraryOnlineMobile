using MauiApp1.Model.DTO;

namespace MauiApp1;

public partial class App : Application
{
    public App()
    {
        
        
        InitializeComponent();
       
        MainPage = new AppShell();
    }
}