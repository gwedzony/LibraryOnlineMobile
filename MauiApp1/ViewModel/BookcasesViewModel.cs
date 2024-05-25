using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Database.Data.BookStructure;
using Database.Data.MobileApp;
using MauiApp1.Model.DTO;
using MauiApp1.Pages.Shared;
using MauiApp1.Services;
using BookStructure_Book = Database.Data.BookStructure.Book;

namespace MauiApp1.ViewModel;

public partial class BookcasesViewModel : ObservableObject
{
    
    private ObservableCollection<BookcasesDTO> _bookcases;
    private ObservableCollection<Book> _books;
    private string _name;

    public String Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
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
        _books = new ObservableCollection<Book>();
        _bookcases = new ObservableCollection<BookcasesDTO>();
        GetItems();
    }

    public void GetItems()
    {
       
       Books.Add(book1);
       Books.Add(book2);
       Books.Add(book3);
        
        
        for (var i = 0; i < 1; i++)
        {
            BookcasesDtos.Add(new BookcasesDTO()
            {
                Name = $"Biblioteczka numer: {i}",
                Book = Books
            });
        }
    }
    [RelayCommand]
    private void Delete(int id)
    {
        var book = Books.FirstOrDefault(b=>b.Id == id);        
        Books.Remove(book);
        Debug.WriteLine($"Usuniete {id}");
    }
    
   
}