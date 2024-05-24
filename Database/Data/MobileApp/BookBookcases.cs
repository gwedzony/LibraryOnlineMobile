using Database.Data.BookStructure;

namespace Database.Data.MobileApp;

public class BookBookcases
{
    public int Id { get; set; }
    
    public int BookId { get; set; }
    public int BookcasesId { get; set; }

    public Book Book { get; set; } = null!;
    public Bookcase Bookcases { get; set; } = null!;
    
}