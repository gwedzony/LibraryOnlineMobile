using Database.Data.BookStructure;
using Database.Data.MobileApp;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public class DatabaseContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<BookGenre> Genres { get; set; }
    public DbSet<BookCollection> BooksCollections { get; set; }
    public DbSet<DetailBookMobilePage> DetailBookMobilePages { get; set; }
    public DbSet<LatestMobileBooksCard> LatestMobileBooksCard { get; set; }
    public DbSet<LatestMobileBooksAuthorCard> LatestMobileBooksAuthorCard { get; set; }
    public DbSet<RandomMobileBooksCollectionCard> RandomMobileBooksCollectionCards{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetailBookMobilePage>()
            .HasOne(d => d.Book)
            .WithOne(b => b.DetailBookMobilePages)
            .HasForeignKey<DetailBookMobilePage>(d => d.BookId);
        
        modelBuilder.Entity<LatestMobileBooksCard>()
            .HasOne(l => l.Book)
            .WithOne(b => b.LatestMobileBooksCard)
            .HasForeignKey<LatestMobileBooksCard>(l => l.BookId);
        
        modelBuilder.Entity<LatestMobileBooksAuthorCard>()
            .HasOne(l => l.Book)
            .WithOne(b => b.LatestMobileBooksAuthorCard)
            .HasForeignKey<LatestMobileBooksAuthorCard>(l => l.BookId);
        
        modelBuilder.Entity<RandomMobileBooksCollectionCard>()
            .HasOne(r => r.Collection)
            .WithOne(c => c.RandomCollectionsMobilePage)
            .HasForeignKey<RandomMobileBooksCollectionCard>(r => r.CollectionId);
        
        modelBuilder.Entity<Book>()
            .HasOne(b => b.BookGenre)
            .WithMany(b => b.Books)
            .HasForeignKey(b => b.BookGenreId);
        
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books);
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Collections)
            .WithMany(c => c.Books);


    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=/Users/grzesiek/RiderProjects/ProjektMobilne/Database/identifier.sqlite");
    }
}