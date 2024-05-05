using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.DATA.BookScheme;

namespace Database.DATA.CMS;

public class MobileBookPreview
{
    [Key]
    public int MobileBookPreviewId
    {
        get;
        set;
    }
    [Display(Name = "Link do zdjecia okładki")]
    public string? SmallCoverImg{ get; set; }
    
    [ForeignKey("Books")]
    public int? BookId { get; set; }
    public Book? Book { get; set; }
}