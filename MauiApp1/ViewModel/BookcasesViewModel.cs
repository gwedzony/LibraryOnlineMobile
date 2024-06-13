using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Database.Data.BookStructure;
using Database.Data.MobileApp;
using MauiApp1.Model.DTO;
using MauiApp1.Pages;
using MauiApp1.Services;
using BookStructure_Book = Database.Data.BookStructure.Book;

namespace MauiApp1.ViewModel;

public partial class BookcasesViewModel : ObservableObject
{
    private Bookcase? _bookcases;
    private readonly BookcaseService _bookcaseService;
    private readonly BooksService _booksService;
    private string? _bookcaseName;

    public string? BookcaseName
    {
        get => _bookcaseName;
        set
        {
            _bookcaseName = value;
            OnPropertyChanged();
        }
    }
    public Bookcase? Bookcases
    {
        get => _bookcases;
        set
        {
            if (_bookcases != value)
            {
                _bookcases = value;
                OnPropertyChanged();
                GetItems();
            }
        }
    }

    public BookcasesViewModel()
    {
        _bookcaseService = new BookcaseService();
        _booksService = new BooksService();
        _bookcases = new Bookcase();
        GetItems();
    }

    private async Task GetItems()
    {
         var test  = await _bookcaseService.GetItem();
        _bookcases.Id = test.Id;
        _bookcases.Name = test.Name;
        _bookcases.Books = test.Books;
    }

    [RelayCommand]
    private async Task AddToBookcase(int id)
    {
        var list = await _booksService.GetItems();

        foreach (var item in list)
        {
            if (item.Id == id)
            {
               
               if(!_bookcases.Books.Contains(_bookcases.Books.FirstOrDefault(x=>x.Id == id)))
               {
                   _bookcases.Books.Add(item);
                   await _bookcaseService.SaveToBookcaseAsync(_bookcases);
               }
            }
        }

        foreach (var book in _bookcases.Books)
        {
            Debug.WriteLine(book.Title);
        }
        
    }
}