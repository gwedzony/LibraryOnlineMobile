using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MobileAPI.Model;

public partial class IdentifierContext : DbContext
{
    public IdentifierContext()
    {
    }

    public IdentifierContext(DbContextOptions<IdentifierContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookPage> BookPages { get; set; }

    public virtual DbSet<BookPreviewCollection> BookPreviewCollections { get; set; }

    public virtual DbSet<BookPreviewNewest> BookPreviewNewests { get; set; }

    public virtual DbSet<BookType> BookTypes { get; set; }

    public virtual DbSet<Collection> Collections { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<ListenAudioBookPage> ListenAudioBookPages { get; set; }

    public virtual DbSet<MobileBookCollectionPreview> MobileBookCollectionPreviews { get; set; }

    public virtual DbSet<MobileBookPage> MobileBookPages { get; set; }

    public virtual DbSet<MobileBookPreview> MobileBookPreviews { get; set; }

    public virtual DbSet<ReadOnlineBook> ReadOnlineBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Name=ConnectionStrings:DatabaseContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasIndex(e => e.IdAuthor, "IX_Books_IdAuthor");

            entity.HasIndex(e => e.IdBookType, "IX_Books_IdBookType");

            entity.HasIndex(e => e.IdGenre, "IX_Books_IdGenre");

            entity.Property(e => e.AddDateTime).HasDefaultValue("0001-01-01 00:00:00");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Books).HasForeignKey(d => d.IdAuthor);

            entity.HasOne(d => d.IdBookTypeNavigation).WithMany(p => p.Books).HasForeignKey(d => d.IdBookType);

            entity.HasOne(d => d.IdGenreNavigation).WithMany(p => p.Books).HasForeignKey(d => d.IdGenre);

            entity.HasMany(d => d.CollectionsCollections).WithMany(p => p.BooksBooks)
                .UsingEntity<Dictionary<string, object>>(
                    "BookCollection",
                    r => r.HasOne<Collection>().WithMany().HasForeignKey("CollectionsCollectionId"),
                    l => l.HasOne<Book>().WithMany().HasForeignKey("BooksBookId"),
                    j =>
                    {
                        j.HasKey("BooksBookId", "CollectionsCollectionId");
                        j.ToTable("BookCollections");
                        j.HasIndex(new[] { "CollectionsCollectionId" }, "IX_BookCollections_CollectionsCollectionId");
                    });
        });

        modelBuilder.Entity<BookPage>(entity =>
        {
            entity.HasIndex(e => e.BookId, "IX_BookPages_BookId").IsUnique();

            entity.HasOne(d => d.Book).WithOne(p => p.BookPage).HasForeignKey<BookPage>(d => d.BookId);
        });

        modelBuilder.Entity<BookPreviewCollection>(entity =>
        {
            entity.HasKey(e => e.PreviewId);

            entity.HasIndex(e => e.BookId, "IX_BookPreviewCollections_BookId").IsUnique();

            entity.HasOne(d => d.Book).WithOne(p => p.BookPreviewCollection).HasForeignKey<BookPreviewCollection>(d => d.BookId);
        });

        modelBuilder.Entity<BookPreviewNewest>(entity =>
        {
            entity.HasKey(e => e.NewestBookId);

            entity.HasIndex(e => e.BookId, "IX_BookPreviewNewests_BookId");

            entity.HasOne(d => d.Book).WithMany(p => p.BookPreviewNewests).HasForeignKey(d => d.BookId);
        });

        modelBuilder.Entity<Collection>(entity =>
        {
            entity.HasKey(e => e.CollectionId);

            entity.Property(e => e.CollectionName).HasDefaultValue("");
        });

        modelBuilder.Entity<ListenAudioBookPage>(entity =>
        {
            entity.HasKey(e => e.AudioPageId);

            entity.HasIndex(e => e.BookId, "IX_ListenAudioBookPages_BookId").IsUnique();

            entity.HasOne(d => d.Book).WithOne(p => p.ListenAudioBookPage).HasForeignKey<ListenAudioBookPage>(d => d.BookId);
        });

        modelBuilder.Entity<MobileBookCollectionPreview>(entity =>
        {
            entity.HasKey(e => e.CollectionPreviewId);

            entity.HasIndex(e => e.BookId, "IX_MobileBookCollectionPreviews_BookId");

            entity.HasOne(d => d.Book).WithMany(p => p.MobileBookCollectionPreviews).HasForeignKey(d => d.BookId);
        });

        modelBuilder.Entity<MobileBookPage>(entity =>
        {
            entity.HasIndex(e => e.BookId, "IX_MobileBookPages_BookId");

            entity.HasOne(d => d.Book).WithMany(p => p.MobileBookPages).HasForeignKey(d => d.BookId);
        });

        modelBuilder.Entity<MobileBookPreview>(entity =>
        {
            entity.HasIndex(e => e.BookId, "IX_MobileBookPreviews_BookId");

            entity.HasOne(d => d.Book).WithMany(p => p.MobileBookPreviews).HasForeignKey(d => d.BookId);
        });

        modelBuilder.Entity<ReadOnlineBook>(entity =>
        {
            entity.HasKey(e => e.ReadOnlineId);

            entity.HasIndex(e => e.BookId, "IX_ReadOnlineBooks_BookId").IsUnique();

            entity.HasOne(d => d.Book).WithOne(p => p.ReadOnlineBook).HasForeignKey<ReadOnlineBook>(d => d.BookId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
