
using System.ComponentModel.DataAnnotations;
using Database.Data.MobileApp;


namespace Database.Data.BookStructure;

public class Author
{
    [Key]
    public int Id{ get; set; }
    
    [Required(ErrorMessage = "Imie autora jest wymagane")]
    [Display(Name = "Imie")]
    public required string Name{ get; set; }
    
    [Required(ErrorMessage = "Nazwisko autora jest wymagane")]
    [Display(Name= "Nazwisko")]
    public required string Surname{ get; set; }
    
    [Required(ErrorMessage = "Krotki opis o autorze")]
    [Display(Name= "Opis")]
    public string? Description{ get; set; }
    
    [Display(Name ="URL do zdjecia autora")]
    public string? PhotoUrl{ get; set; }

    // Foreign Keys

    public ICollection<Book> Books { get; } = new List<Book>();
    
    #region OneToOne
   
    public int? LatestMobileBooksAuthorCardId { get; set; }
    public LatestMobileBooksAuthorCard ? LatestMobileBooksAuthorCard { get; set; }
    #endregion
   
}