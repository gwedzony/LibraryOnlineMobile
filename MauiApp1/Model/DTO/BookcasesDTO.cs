using System.Collections.ObjectModel;
using Database.Data.BookStructure;

namespace MauiApp1.Model.DTO;

public class BookcasesDTO
{
    public string Name { get; set; }
    public ObservableCollection<Book> Book { get; set; }
}