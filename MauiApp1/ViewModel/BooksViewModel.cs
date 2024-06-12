using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Model.DTO;
using MauiApp1.Services;

namespace MauiApp1.ViewModel;

public class BooksViewModel : ObservableObject
{
    private ObservableCollection<BookDTO> _books;
    private readonly BooksService _service;

    public ObservableCollection<BookDTO> Books
    {
        get => _books;
        set
        {
            _books = value;
            OnPropertyChanged(nameof(Books));
        }
    }

    public BooksViewModel()
    {
        _service = new BooksService();
        _books = new ObservableCollection<BookDTO>();
        getBooks();
    }


    public async void getBooks()
    {
        var list = await _service.GetItems();

        foreach ( var item in list)
        {
            Books.Add(new BookDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Image = item.Image
            });
        }
    }
    
}