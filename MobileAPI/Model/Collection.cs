using System;
using System.Collections.Generic;

namespace MobileAPI.Model;

public partial class Collection
{
    public int CollectionId { get; set; }

    public string CollectionName { get; set; } = null!;

    public virtual ICollection<Book> BooksBooks { get; set; } = new List<Book>();
}
