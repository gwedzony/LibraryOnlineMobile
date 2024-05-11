namespace Database.Data.BookStructure;

public class BookCollection
{
    public int Id { get; set; }
    
    public int BookId { get; set; }
    public int CollectionId { get; set; }

    public Book Book { get; set; } = null;
    public Collection Collection { get; set; } = null;
    
    
}