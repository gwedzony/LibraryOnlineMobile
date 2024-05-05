using System;
using System.Collections.Generic;

namespace MobileAPI.Model;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Description { get; set; }

    public string? PhotoUrl { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
