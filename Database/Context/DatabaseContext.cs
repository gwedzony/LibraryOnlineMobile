using Database.Data.BookStructure;
using Database.Data.MobileApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.EntityFrameworkCore.Extensions;

namespace Database.Context;

public class DatabaseContext() : DbContext
{
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<BookGenre> Genres { get; set; }
    public DbSet<BookCollection> BooksCollections { get; set; }
    public DbSet<Bookcase> Bookcases { get; set; }
    public DbSet<DetailBookMobilePage> DetailBookMobilePages { get; set; }
    public DbSet<LatestMobileBooksCard> LatestMobileBooksCard { get; set; }
    public DbSet<MobileBooksAuthorCard> MobileBooksAuthorCard { get; set; }
    public DbSet<RandomMCollectionCard> RandomMBooksCollectionCards{ get; set; }

    

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
        
        modelBuilder.Entity<MobileBooksAuthorCard>()
            .HasOne(l => l.Author)
            .WithOne(b => b.MobileBooksAuthorCard)
            .HasForeignKey<MobileBooksAuthorCard>(l => l.AuthorId);
        
        modelBuilder.Entity<RandomMCollectionCard>()
            .HasOne(r => r.Collection)
            .WithOne(c => c.RandomCollectionsMobilePage)
            .HasForeignKey<RandomMCollectionCard>(r => r.CollectionId);
        
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

        modelBuilder.Entity<Bookcase>()
            .HasMany(b => b.Books)
            .WithOne(b => b.Bookcase)
            .HasForeignKey(b => b.BookCaseId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       //optionsBuilder.UseSqlite(@"Data Source=/Users/grzesiek/RiderProjects/ProjektMobilne/Database/identifier.sqlite");
       optionsBuilder.UseMySQL(
    "server=mysql-229035fc-mkgw-projektmobilki.h.aivencloud.com;Port=13237;uid=avnadmin;pwd=AVNS_WhD37An18x2d4xxrYYY;database=db;SslMode=Required").LogTo(Console.WriteLine, LogLevel.Information);
    }
}