using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.DATA.BookScheme;

namespace Database.DATA.Library;

public class MobileBookPage
{
    [Key]
    public int MobileBookPageId { get; set; }
   
    [Display(Name = "Link do zdjecia okładki")]
    public string? MobileBigCoverImg{ get; set; }
   
    [Display(Name = "Link do książki")]
    public string? PdfUrl{ get; set; }
    
    [Display(Name = "Link do audiobooka")]
    public string? AudioBookUrl { get; set; }
   
    [ForeignKey("Books")]
    public int? BookId { get; set; }

    public Book? Book { get; set; } = null!; 
}