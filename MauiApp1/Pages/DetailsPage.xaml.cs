using MauiApp1.ViewModel;


namespace MauiApp1.Pages;

[QueryProperty(nameof(BookId), "BookId")]
public partial class DetailsPage : ContentPage
{
    private int _bookId;
    private DetailPageViewModel vm;
    public int BookId
    {
        get => _bookId;
        set
        {
            _bookId = value;
            OnPropertyChanged();
            setProperPage(_bookId);
        }
       
    }
    public DetailsPage()
    {
        InitializeComponent();
        BindingContext = vm = new DetailPageViewModel();
        
    }
    private void setProperPage(int id)
    {
        vm.GetItem(id);
    }
    
}