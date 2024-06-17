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

sealed partial class BookcasesViewModel : ObservableObject
{
    private Bookcase? _bookcases;
    private readonly BookcaseService _bookcaseService;
    private readonly BooksService _booksService;
    private string _name;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }
    public Bookcase? Bookcases
    {
        get => _bookcases;
        set => SetProperty(ref _bookcases, value);
    }

    public BookcasesViewModel()
    {
        _bookcases = new Bookcase();
        _bookcaseService = new BookcaseService();
        _booksService = new BooksService();
        GetItems();
    }

    [RelayCommand]
    private async Task GetItems()
    {
        
        Debug.WriteLine($"Liczba ksiazek w VM GetItems: {_bookcases.Books.Count}");
        Bookcases = await _bookcaseService.GetItem();
    }

    [RelayCommand]
    private async Task EditBookcaseName()
    {
        if (_name != null)
        {
            _bookcases.Name = _name;
            await _bookcaseService.SaveToBookcaseAsync(_bookcases);
            await GetItems();
        }
      
    }
    [RelayCommand]
    private async Task AddToBookcase(int id)
    {
        var list = await _booksService.GetItems();

        Debug.WriteLine($"Current books in Bookcase Adding: {Bookcases.Books.Count}");

        foreach (var item in list)
        {
            if (item.Id == id)
            {
                if (!Bookcases.Books.Contains(Bookcases.Books.FirstOrDefault(x => x.Id == id)))
                {
                    Bookcases.Books.Add(item);
                    await _bookcaseService.SaveToBookcaseAsync(Bookcases);
                    await GetItems();
                }
            }
        }
    }

    [RelayCommand]
    private async Task DeleteFromBookcase(int id)
    {
        var book = _bookcases.Books.First(x => x.Id == id);
        Debug.WriteLine($"Current books in Bookcase Deleting {Bookcases.Books.Count}");

        _bookcases.Books.Remove(book);
        Debug.WriteLine($"Current books in Bookcase after remove {Bookcases.Books.Count}");
        await _bookcaseService.DeleteTodoItemAsync(id);
        await GetItems();
        Debug.WriteLine($"Current books in Bookcase after GETITEMS {Bookcases.Books.Count}");
    }
}