﻿using System;
using System.Collections.Generic;

namespace MobileAPI.Model;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
