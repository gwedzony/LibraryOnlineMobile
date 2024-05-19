using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Data.BookStructure;

namespace Database.Data.MobileApp;

public class MobileBooksAuthorCard
{
    [Key] 
    public int Id { get; set; }
    
    // foreignkeys
    public int AuthorId { get; set; }
    [ForeignKey("AuthorId")]
    public Author? Author { get; set; }
}