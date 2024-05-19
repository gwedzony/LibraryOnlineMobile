using System.ComponentModel.DataAnnotations.Schema;
using Database.Data.BookStructure;

namespace Database.Data.MobileApp;

public class RandomMCollectionCard
{
    public int Id { get; set; }

    public int CollectionId { get; set; }
    [ForeignKey("CollectionId")]
    public Collection? Collection{ get; set; }
    
    
}