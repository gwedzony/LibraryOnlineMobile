using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Database.Data.MobileApp;
using MauiApp1.Model.DTO;
using MauiApp1.Services;

namespace MauiApp1.ViewModel;

public partial class DetailPageViewModel: ObservableObject
{
   private readonly DetailPageService _service;
   
    private string _image;
    private string _title;
    private string _author;
    private string _description;
    public string Image
    {
        get => _image;
        set
        {
                _image = value;
                OnPropertyChanged(nameof(Image));
        }
    }
    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged(nameof(Title));
        }
    }
    public string Author
    {
        get => _author;
        set
        {
            _author = value;
            OnPropertyChanged(nameof(Author));
        }
    }
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged(nameof(Description));
        }
    }
    
    public DetailPageViewModel()
    {
        _service = new DetailPageService();
    }

    public async Task GetItem(int id)
    {
        DetailBookMobilePage? item = await _service.GetItem(id);

        Image = item.Book.Image;
        Title = item.Book.Title;
        Author = $"{item.Book.Author.Name} {item.Book.Author.Surname}";
        Description = item.Book.Description;

    }
   
}