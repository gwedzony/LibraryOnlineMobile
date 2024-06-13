using System.ComponentModel.DataAnnotations;
using Database.Data.BookStructure;

namespace Database.Data.MobileApp;

public class Bookcase
{
    [Key] 
    public int Id { get; set; }
    
    public string? Name{ get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();

}