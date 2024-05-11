using System.ComponentModel.DataAnnotations;
using Database.Data.BookStructure;

namespace Database.Data.MobileApp;

public class LatestMobileBooksAuthorCard
{
    [Key] 
    public int Id { get; set; }
    
    // foreignkeys
    public Author? Book { get; set; }
}