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
    
    private ObservableCollection<BookcasesDTO> _bookcases;
    private ObservableCollection<Book> _books;

    private string _newNameFromPrompt;
    private int _idFromPrompt;
    public string NewNameFromPrompt
    {
        get => _newNameFromPrompt;
        set
        {
            _newNameFromPrompt = value;
            OnPropertyChanged(nameof(NewNameFromPrompt));
            Debug.WriteLine($"NewNameFromPrompt: {_newNameFromPrompt}");
        }
    }
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

    private Book book1;
    private Book book2;
    private Book book3;
    public ObservableCollection<Book> Books
    {
        get => _books;
        set
        {
            _books = value;
            OnPropertyChanged(nameof(Books));
        }
    }
    public ObservableCollection<BookcasesDTO> BookcasesDtos
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
       
        _books = new ObservableCollection<Book>();
        _bookcases = new ObservableCollection<BookcasesDTO>();
        GetItems();
    }

    private void GetItems()
    {
        
            book1 = new Book
            {
                Id = 1,
                Title = "Book Title 1",
                Description = "This is a short description of Book 1.",
                Image = "http://example.com/book1.jpg",
                ReadCount = 100,
                AddDateTime = DateTime.Now,
                BookGenreId = 2,
                AuthorId = 1,
         
            };

            book2 = new Book
            {
                Id = 2,
                Title = "Book Title 2",
                Description = "This is a short description of Book 2.",
                Image = "http://example.com/book2.jpg",
                ReadCount = 200,
                AddDateTime = DateTime.Now,
                BookGenreId = 1,
                AuthorId = 3,
            
            };

            book3 = new Book
            {
                Id = 3,
                Title = "Book Title 3",
                Description = "This is a short description of Book 3.",
                Image = "http://example.com/book3.jpg",
                ReadCount = 300,
                AddDateTime = DateTime.Now,
                BookGenreId = 3,
                AuthorId = 2,
            
            };
            
            Books.Add(book1);
            Books.Add(book2);
            Books.Add(book3);
        
        
            for (var i = 0; i < 3; i++)
            {
                BookcasesDtos.Add(new BookcasesDTO()
                {
                    Id= i,
                    Name = $"Biblioteczka numer: {i}",
                    Book = [Books[0],Books[1],Books[2]]
                });
               
            }
    }
    
    [RelayCommand]
    private void Delete(Tuple<int,int> parameters)
    {
        var book = Books.FirstOrDefault(b=>b.Id == parameters.Item1);
        var bookcase = BookcasesDtos.FirstOrDefault(bc => bc.Id == parameters.Item2);
        

        if (bookcase?.Book.Count == 1)
        {
            bookcase?.Book.Remove(book);
            Debug.WriteLine("0000000");
            BookcasesDtos.Remove(bookcase);
        }
        else
        {
            bookcase?.Book.Remove(book);
            Debug.WriteLine(bookcase.Book.Count);
                
        }
       
    }
    
    
    
    [RelayCommand]
    private async void NameChange()
    {
        var bookcase = BookcasesDtos.FirstOrDefault(x => x.Id == IdFromPrompt);
        bookcase.Name = _newNameFromPrompt;

        NewNameFromPrompt = null;
    }
  
}