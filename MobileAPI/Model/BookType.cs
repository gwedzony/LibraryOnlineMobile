using System;
using System.Collections.Generic;

namespace MobileAPI.Model;

public partial class BookType
{
    public int BookTypeId { get; set; }

    public string BookTypeName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
