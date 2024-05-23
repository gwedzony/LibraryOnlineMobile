namespace MauiApp1.Pages;

[QueryProperty(nameof(bookId), "id")]
public partial class DetailsPage : ContentPage
{
    int bookId;
    public int BookId
    {
        get => bookId;
        set
        {
            bookId= value;
            OnPropertyChanged();
        }
    }
    public DetailsPage()
    {
        InitializeComponent();
    }

   
}