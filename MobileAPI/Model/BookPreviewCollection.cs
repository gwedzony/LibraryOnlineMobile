using System;
using System.Collections.Generic;

namespace MobileAPI.Model;

public partial class BookPreviewCollection
{
    public int PreviewId { get; set; }

    public string? AudioUrl { get; set; }

    public int? BookId { get; set; }

    public string? PdfUrl { get; set; }

    public string? SmallCoverImg { get; set; }

    public virtual Book? Book { get; set; }
}
