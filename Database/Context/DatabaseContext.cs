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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=/Users/grzesiek/RiderProjects/ProjektMobilne/Database/identifier.sqlite");
    }
}