using System.Collections.ObjectModel;
using System.Diagnostics;
using Database.Data.MobileApp;
using MauiApp1.Model.DTO;
using MauiApp1.Services;

namespace MauiApp1.ViewModel;

public class DetailPageViewModel: BaseViewModel
{
    private ObservableCollection<DetailPageDTO> _detailPages;
    
    private readonly DetailPageService _service;
    public ObservableCollection<DetailPageDTO> DetailPages
    {
        get => _detailPages;
        set
        {
            if (_detailPages == value) return;
            _detailPages = value;
            OnPropertyChanged(nameof(DetailPages));
        }
    }
    
    public DetailPageViewModel()
    {
        _service = new DetailPageService();
        _detailPages = new ObservableCollection<DetailPageDTO>();
        GetAll();
    }
    
    
    private async Task GetAll()
    {
        
        List<DetailBookMobilePage> list = await _service.GetItems();

        
        foreach (var item in list)
        {
           
            _detailPages.Add(new DetailPageDTO()
            {
                Id = item.Id,
                SmallCoverImg = item.Book!.Image,
                BookTitle = item.Book.Title,
                BookDescription= item.Book.Description,
                Author = $"{item.Book.Author.Name} {item.Book.Author.Surname}",
            });
        }
    }


}