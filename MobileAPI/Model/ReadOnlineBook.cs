using System;
using System.Collections.Generic;

namespace MobileAPI.Model;

public partial class ReadOnlineBook
{
    public int ReadOnlineId { get; set; }

    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }
}
