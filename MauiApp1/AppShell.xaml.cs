using MauiApp1.Model.DTO;

namespace MauiApp1;

public partial class AppShell : Shell
{
    public AppShell()
    {
        var test = new MobileBookPreviewDTO();
        test.MobileBookPreviewId = 1;
        test.BookTitle = "Grzechy grzechy";
        test.SmallCoverImg = "adres url";
        test.BookDescription = " krotki opis ksiazki";
        
        
        
        InitializeComponent();
    }
}