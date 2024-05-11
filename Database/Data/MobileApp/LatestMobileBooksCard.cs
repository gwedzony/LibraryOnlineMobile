using System.ComponentModel.DataAnnotations;
using Database.Data.BookStructure;

namespace Database.Data.MobileApp;

public class LatestMobileBooksCard
{
    [Key] 
    public int Id { get; set; }
    
    // foreignkeys
    public Book? Book { get; set; }
}