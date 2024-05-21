using System.Collections.ObjectModel;
using System.Diagnostics;
using Database.Data.MobileApp;
using MauiApp1.Model;
using MauiApp1.Model.DTO;
using MauiApp1.Services;

namespace MauiApp1.ViewModel;

public class MainPageViewModel: BaseViewModel
{
    private ObservableCollection<MobileBookPreviewDTO> _mobileBooksPreviews;
    
    private readonly BooksService _service;
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
        _service= new BooksService();
        _mobileBooksPreviews = new ObservableCollection<MobileBookPreviewDTO>();
        
        GetPreviewsFromApi();

    }

    private async Task GetPreviewsFromApi()
    {
        
        List<LatestMobileBooksCard> list = await _service.GetItems();

        
        foreach (var item in list)
        {
           
            _mobileBooksPreviews.Add(new MobileBookPreviewDTO()
            {
                MobileBookPreviewId = item.Id,
                BookTitle = item.Book.Title,
                BookDescription = item.Book.Description,
                SmallCoverImg = item.Book.Image
            });
           
        }
        
    }
    
}