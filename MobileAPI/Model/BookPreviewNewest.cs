using System;
using System.Collections.Generic;

namespace MobileAPI.Model;

public partial class BookPreviewNewest
{
    public int NewestBookId { get; set; }

    public string? SmallCoverImg { get; set; }

    public string? BookLink { get; set; }

    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }
}
