using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Database.Data.MobileApp;
using MauiApp1.Model;
using MauiApp1.Model.DTO;
using MauiApp1.Services;

namespace MauiApp1.ViewModel;

public partial class MainPageViewModel: ObservableObject
{
    private ObservableCollection<MobileBookPreviewDTO> _mobileBooksPreviews;
    
    private readonly MobileBookCardsService _service;
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
        _service= new MobileBookCardsService();
        _mobileBooksPreviews = new ObservableCollection<MobileBookPreviewDTO>();
        Debug.WriteLine("Jestem w glownym vmie");
        GetPreviewsFromApi();
    }

   public async Task GetPreviewsFromApi()
    {
        Debug.WriteLine("Zaczynam pobierac dane..");
        List<LatestMobileBooksCard> list = await _service.GetItems();
        
        Debug.WriteLine($"Lista pobraniu danych ma : {list.Count} liczbe kart");
        foreach (var item in list)
        {
       
            _mobileBooksPreviews.Add(new MobileBookPreviewDTO()
            {
                MobileBookPreviewId = item.Id,
                BookTitle = item.Book.Title,
                BookDescription = item.Book.Description,
                SmallCoverImg = item.Book.Image,
                BookId = item.BookId,
                Author = $"{item.Book.Author.Name} {item.Book.Author.Surname}",
                AuthorImage = $"{item.Book.Author.PhotoUrl}"
            });
           
        }
    }
    
    [RelayCommand]
    private async Task Tap(int id)
    {
       
       await Shell.Current.GoToAsync($"DetailsPage?BookId={id}");
    }
}