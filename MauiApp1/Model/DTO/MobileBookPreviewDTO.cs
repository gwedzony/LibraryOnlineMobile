namespace MauiApp1.Model.DTO;

public class MobileBookPreviewDTO
{
    
    public int MobileBookPreviewId { get; set; }
    public string? SmallCoverImg{ get; set; }
    public string BookTitle { get; set; } 
    public int BookId { get; set; } 
    public string BookDescription { get; set; } 
    public string Author{get; set; }
    public string AuthorImage { get; set; }
}