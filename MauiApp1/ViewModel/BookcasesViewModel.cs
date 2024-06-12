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
    private BookcasesDTO _bookcases;
    private readonly BookcaseService _bookcaseService;
    private readonly BooksService _booksService;

    private int _idFromPrompt;

    public int IdFromPrompt
    {
        get => _idFromPrompt;
        set
        {
            _idFromPrompt = value;
            OnPropertyChanged(nameof(IdFromPrompt));
            Debug.WriteLine($"IdFromPrompt: {_idFromPrompt}");
        }
    }

    public BookcasesDTO BookcasesDtos
    {
        get => _bookcases;
        set
        {
            _bookcases = value;
            OnPropertyChanged(nameof(BookcasesDtos));
        }
    }

    public BookcasesViewModel()
    {
        _bookcases = new BookcasesDTO();
        _bookcaseService = new BookcaseService();
        _booksService = new BooksService();
        GetItems();
    }

    private async Task GetItems()
    {
        var bookcase = await _bookcaseService.GetItem();
        if (bookcase != null)
        {
            _bookcases.Id = bookcase.Id;
            _bookcases.Name = bookcase.Name;
            _bookcases.Book =  new ObservableCollection<Book>(bookcase.Books);
        }
    }

   [RelayCommand]
   private void AddToBookcase()
    {
        Debug.WriteLine($"Jestem i chce dodawac id książki?");
        
        var bookList = new ObservableCollection<Book>(_booksService.GetItems().Result);
        
        foreach (var item in bookList)
        {
            if (item.Id == 1)
            {
                _bookcases.Book.Add(item);    
            }
            else
            {
                Debug.WriteLine("book is empty list");
            }
        }     
    }
}