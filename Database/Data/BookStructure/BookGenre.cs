using System.ComponentModel.DataAnnotations;

namespace Database.Data.BookStructure;

public class BookGenre
{
    [Key]
    
    public int Id{ get; set; }
    
    [Required(ErrorMessage = "Nazwa gatunku jest wymagana")]
    [Display(Name = "Gatunek (np. Horror, Thriller)")]
    public required string Name{ get; set; }
    // Foreign Keys
    public ICollection<Book> Books { get; } = new List<Book>();

   
}