using System.Collections.ObjectModel;
using MauiApp1.Model.DTO;

namespace MauiApp1.ViewModel;

public class MainPageViewModel: BaseViewModel
{
    private ObservableCollection<MobileBookPreviewDTO> _mobileBooksPreviews;

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
        _mobileBooksPreviews = new ObservableCollection<MobileBookPreviewDTO>();
        AddMockData();

    }

    private void AddMockData()
    {
        for (int i = 0; i < 10; i++)
        {
            _mobileBooksPreviews.Add(new MobileBookPreviewDTO
            {
                MobileBookPreviewId = i,
                BookTitle = $"Tytul ksiazki - {i}",
                BookDescription = $"Krotki opis ksiazki {i}",
                SmallCoverImg = "https://aka.ms/campus.jpg"
                
            });
        }
    }
    
}