using System.ComponentModel.DataAnnotations;
using Database.Data.BookStructure;

namespace Database.Data.MobileApp;

public class Bookcase
{
    [Key] 
    public int Id { get; set; }
    
    public required string Name{ get; set; }
    
    public List<BookBookcases> BookBookcases{ get; } = [];
    public List<Book> Books { get; } = [];

}