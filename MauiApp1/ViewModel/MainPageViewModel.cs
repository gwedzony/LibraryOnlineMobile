using System.Collections.ObjectModel;
using MauiApp1.Model;
using MauiApp1.Model.DTO;
using MauiApp1.Services;

namespace MauiApp1.ViewModel;

public class MainPageViewModel: BaseViewModel
{
    private ObservableCollection<MobileBookPreview> _mobileBooksPreviews;
    
    private readonly MobileBooksPreviewsService _service;
    public ObservableCollection<MobileBookPreview> MobileBookPreviews
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

    }

    private async Task GetPreviewsFromAPI()
    {
        var response = await _service.GetMobileBooksPreviews();
        if (response != null)
        {
            _mobileBooksPreviews = new ObservableCollection<MobileBookPreview>();
           
        }
    }
    
}