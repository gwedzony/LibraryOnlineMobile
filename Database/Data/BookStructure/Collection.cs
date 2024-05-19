using System.ComponentModel.DataAnnotations;
using Database.Data.MobileApp;

namespace Database.Data.BookStructure;

public class Collection
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Musisz podać nazwę dla kolekcji")]
    [Display(Name = "Nazwa kolekcji (np. Nowoczesne, starożytne)")]
    public required string CollectionName { get; set; }
    
    [Required(ErrorMessage = "Musisz podać adres url dla loga kolekcji")]
    [Display(Name = "Adres url:")]
    public required string CollectionImage { get; set; }
    
    
   // Foreign Keys
   
   public List<BookCollection> BookCollections { get; } = [];
   public List<Book> Books { get; } = [];
   
   #region OneToOne
   
   public int? RandomCollectionsMobilePageId { get; set; }
   public RandomMCollectionCard? RandomCollectionsMobilePage { get; set; }
   #endregion
}