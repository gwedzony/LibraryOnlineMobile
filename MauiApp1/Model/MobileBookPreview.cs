using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MauiApp1.Model;

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
    
    public Book? Book { get; set; }
}