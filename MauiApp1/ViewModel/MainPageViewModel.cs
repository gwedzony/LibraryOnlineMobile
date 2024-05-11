using System.Collections.ObjectModel;
using MauiApp1.Model;
using MauiApp1.Model.DTO;
using MauiApp1.Services;

namespace MauiApp1.ViewModel;

public class MainPageViewModel: BaseViewModel
{
    private ObservableCollection<MobileBookPreviewDTO> _mobileBooksPreviews;
    
    private readonly MobileBooksPreviewsService _service;
    public ObservableCollection<MobileBookPreviewDTO> MobileBookPreviews
    {
        get => _mobileBooksPreviews;
        set
        {
            if (_mobileBooksPreviews != value)
            {
                _mobileBooksPreviews = value;
                OnPropertyChanged(nameof(MobileBookPreviews));
            }
        }
    }


    public MainPageViewModel()
    {
        _service= new MobileBooksPreviewsService();
        GetPreviewsFromAPI();

    }

    private async Task GetPreviewsFromAPI()
    {
        _mobileBooksPreviews = new ObservableCollection<MobileBookPreviewDTO>();
        for (int i = 0; i < 10; i++)
        {
          _mobileBooksPreviews.Add(new MobileBookPreviewDTO()
            {
                MobileBookPreviewId = i,
                SmallCoverImg = "https://visme.co/blog/wp-content/uploads/2021/06/fiction-book-cover-template-visme.jpg",
                BookTitle = $"Another side of the MOON Part {i} ",
                BookDescription = "The book description is the pitch to the reader about why they should buy your book." +
                                  "When done right, it directly drives books sales."
            });
        }
    }
    
}