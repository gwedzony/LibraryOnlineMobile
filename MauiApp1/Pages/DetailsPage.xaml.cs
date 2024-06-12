using MauiApp1.ViewModel;


namespace MauiApp1.Pages;

[QueryProperty(nameof(BookId), "BookId")]
public partial class DetailsPage : ContentPage
{
    private int _bookId;
    private DetailPageViewModel vm;
    private BookcasesViewModel _bookcasesViewModel;
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
    public DetailsPage(BookcasesViewModel bookcasesViewModel)
    {
        InitializeComponent();
        _bookcasesViewModel = bookcasesViewModel;
        BindingContext = vm = new DetailPageViewModel();
        
    }
    private void setProperPage(int id)
    {
        vm.GetItem(id);
    }
    
}