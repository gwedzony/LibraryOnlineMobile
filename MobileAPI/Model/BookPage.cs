using System;
using System.Collections.Generic;

namespace MobileAPI.Model;

public partial class BookPage
{
    public int BookPageId { get; set; }

    public int? BookId { get; set; }

    public string? BigCoverImg { get; set; }

    public string? PdfUrl { get; set; }

    public virtual Book? Book { get; set; }
}
