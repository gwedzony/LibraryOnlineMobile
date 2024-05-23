using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Database.Data.MobileApp;
using MauiApp1.Model.DTO;
using MauiApp1.Services;

namespace MauiApp1.ViewModel;

public partial class DetailPageViewModel: ObservableObject
{
    private DetailPageDTO _detailPage;
    private readonly DetailPageService _service;
    
    [ObservableProperty]
    private int _bookId;
    
    
    public DetailPageDTO DetailPage
    {
        get => _detailPage;
        set
        {
            if (_detailPage == value) return;
            _detailPage = value;
            OnPropertyChanged(nameof(DetailPage));
        }
    }
    
    public DetailPageViewModel()
    {
        _service = new DetailPageService();
        GetItem(_bookId);
    }

    private async Task GetItem(int id)
    {
        DetailBookMobilePage item = await _service.GetItem(id);
        _detailPage = new DetailPageDTO()
        {
            Id = item.Id,
            Author = $"{item.Book.Author.Name} {item.Book.Author.Surname}",
            BookTitle = item.Book.Title,
            BookDescription = item.Book.Description,
            SmallCoverImg = item.Book.Image
            
        };
        
    }
  
}