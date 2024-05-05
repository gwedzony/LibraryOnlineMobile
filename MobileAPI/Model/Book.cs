using System;
using System.Collections.Generic;

namespace MobileAPI.Model;

public partial class Book
{
    public int BookId { get; set; }

    public string Description { get; set; } = null!;

    public int IdAuthor { get; set; }

    public int IdBookType { get; set; }

    public int IdGenre { get; set; }

    public string Title { get; set; } = null!;

    public string AddDateTime { get; set; } = null!;

    public int ReadCount { get; set; }

    public virtual BookPage? BookPage { get; set; }

    public virtual BookPreviewCollection? BookPreviewCollection { get; set; }

    public virtual ICollection<BookPreviewNewest> BookPreviewNewests { get; set; } = new List<BookPreviewNewest>();

    public virtual Author IdAuthorNavigation { get; set; } = null!;

    public virtual BookType IdBookTypeNavigation { get; set; } = null!;

    public virtual Genre IdGenreNavigation { get; set; } = null!;

    public virtual ListenAudioBookPage? ListenAudioBookPage { get; set; }

    public virtual ICollection<MobileBookCollectionPreview> MobileBookCollectionPreviews { get; set; } = new List<MobileBookCollectionPreview>();

    public virtual ICollection<MobileBookPage> MobileBookPages { get; set; } = new List<MobileBookPage>();

    public virtual ICollection<MobileBookPreview> MobileBookPreviews { get; set; } = new List<MobileBookPreview>();

    public virtual ReadOnlineBook? ReadOnlineBook { get; set; }

    public virtual ICollection<Collection> CollectionsCollections { get; set; } = new List<Collection>();
}
