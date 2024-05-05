using System;
using System.Collections.Generic;

namespace MobileAPI.Model;

public partial class MobileBookCollectionPreview
{
    public int CollectionPreviewId { get; set; }

    public string? SmallCoverImg { get; set; }

    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }
}
