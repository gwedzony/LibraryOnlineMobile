using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.DATA.BookScheme;

namespace Database.DATA.CMS;

public class MobileBookCollectionPreview
{
    [Key]
    public int CollectionPreviewId
    {
        get;
        set;
    }
    [Display(Name = "Link do zdjecia kolekcji")]
    public string? SmallCoverImg{ get; set; }
   
    
    [ForeignKey("Books")]
    public int? BookId { get; set; }
    public Book? Book { get; set; }
}