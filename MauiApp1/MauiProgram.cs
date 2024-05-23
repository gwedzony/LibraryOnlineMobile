using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Material.Components.Maui.Extensions;
using MauiIcons.FontAwesome;
using CommunityToolkit.Maui;
using MauiApp1.Pages;
using MauiApp1.ViewModel;
using MauiIcons.Material;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace MauiApp1;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();

        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<HomePage>();
        
        builder.Services.AddTransient<DetailPageViewModel>();
        builder.Services.AddTransient<DetailsPage>();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.UseMaterialComponents();
        return builder.Build();
    }
}