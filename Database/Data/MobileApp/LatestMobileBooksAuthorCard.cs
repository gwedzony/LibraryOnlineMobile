using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Data.BookStructure;

namespace Database.Data.MobileApp;

public class LatestMobileBooksAuthorCard
{
    [Key] 
    public int Id { get; set; }
    
    // foreignkeys
    public int BookId { get; set; }
    [ForeignKey("BookId")]
    public Author? Book { get; set; }
}