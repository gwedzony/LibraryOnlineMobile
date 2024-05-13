using MauiApp1.Pages;
using MauiApp1.ViewModel;
using Microsoft.Maui.Handlers;



namespace MauiApp1;

public partial class MainPage : ContentPage
{
   
    
    public MainPage()
    {
        InitializeComponent();
      
    }
    

    private async void OnDetailsClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetailsPage());
    }

    private async void OnHomeClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void OnViewAllClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewAll());
    }
}