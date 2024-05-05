using System;
using System.Collections.Generic;

namespace MobileAPI.Model;

public partial class MobileBookPage
{
    public int MobileBookPageId { get; set; }

    public string? MobileBigCoverImg { get; set; }

    public string? PdfUrl { get; set; }

    public string? AudioBookUrl { get; set; }

    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }
}
