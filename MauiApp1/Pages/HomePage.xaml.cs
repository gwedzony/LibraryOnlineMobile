using MauiApp1.ViewModel;

namespace MauiApp1.Pages;

public partial class HomePage : ContentPage
{
    
    public HomePage(MainPageViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
        //Navigation.PushAsync(new MainPage());
    }
}