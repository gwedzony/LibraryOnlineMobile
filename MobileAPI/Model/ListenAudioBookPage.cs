using System;
using System.Collections.Generic;

namespace MobileAPI.Model;

public partial class ListenAudioBookPage
{
    public int AudioPageId { get; set; }

    public int? BookId { get; set; }

    public string? AudioUrl { get; set; }

    public virtual Book? Book { get; set; }
}
