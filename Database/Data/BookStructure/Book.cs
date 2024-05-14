using System.ComponentModel.DataAnnotations;
using Database.Data.MobileApp;

namespace Database.Data.BookStructure;

public class Book
{
    [Key] 
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Musisz podac tyuł ksiązki")]
    [Display(Name = "Tytuł książki")]
    public required string Title{ get; set; }
    
    [Required(ErrorMessage = "Musisz utworzyć opis ksiązki")]
    [Display(Name = "Krótki opis książki")]
    public required string Description{ get; set; }
    
    [Required(ErrorMessage = "Musisz podac adres url z okładką zdjęcia")]
    [Display(Name = "Adres url okładki:")]
    public required string Image{ get; set; }
    
    
    public long ReadCount { get; set; }
    
    public DateTime AddDateTime { get; set; }
    
    // Foreign Keys

    #region OneToMany
    
    public int BookGenreId { get; set; }
    public BookGenre BookGenre { get; set; } = null!;

    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    
    #endregion
    
    #region OneToOne
    public int? LatestMobileBooksCardId { get; set; }
    public LatestMobileBooksCard? LatestMobileBooksCard { get; set; }

    public DetailBookMobilePage? DetailBookMobilePages { get; set; }
    #endregion

    #region ManyToMany

    public List<BookCollection> BookCollections { get; } = [];
    public List<Collection> Collections { get; } = [];

    #endregion

} 