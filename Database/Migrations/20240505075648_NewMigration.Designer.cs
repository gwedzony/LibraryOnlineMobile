﻿// <auto-generated />
using System;
using Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240505075648_NewMigration")]
    partial class NewMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("BookCollections", b =>
                {
                    b.Property<int>("BooksBookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CollectionsCollectionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BooksBookId", "CollectionsCollectionId");

                    b.HasIndex("CollectionsCollectionId");

                    b.ToTable("BookCollections");
                });

            modelBuilder.Entity("Database.DATA.BookScheme.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdAuthor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdBookType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdGenre")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ReadCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.HasIndex("IdAuthor");

                    b.HasIndex("IdBookType");

                    b.HasIndex("IdGenre");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Database.DATA.BookScheme.Collections", b =>
                {
                    b.Property<int>("CollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CollectionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CollectionId");

                    b.ToTable("Colections");
                });

            modelBuilder.Entity("Database.DATA.CMS.BookPreviewCollection", b =>
                {
                    b.Property<int>("PreviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AudioUrl")
                        .HasColumnType("TEXT");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PdfUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("SmallCoverImg")
                        .HasColumnType("TEXT");

                    b.HasKey("PreviewId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("Bookpreviews");
                });

            modelBuilder.Entity("Database.DATA.Library.BookPage", b =>
                {
                    b.Property<int>("BookPageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BigCoverImg")
                        .HasColumnType("TEXT");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PdfUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("BookPageId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("BookPages");
                });

            modelBuilder.Entity("Database.DATA.Library.ListenAudioBookPage", b =>
                {
                    b.Property<int>("AudioPageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AudioUrl")
                        .HasColumnType("TEXT");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AudioPageId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("ListenAudioBookPages");
                });

            modelBuilder.Entity("Database.DATA.Library.ReadOnlineBook", b =>
                {
                    b.Property<int>("ReadOnlineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReadOnlineId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("ReadOnlineBooks");
                });

            modelBuilder.Entity("Database.Data.BookScheme.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Database.Data.BookScheme.BookType", b =>
                {
                    b.Property<int>("BookTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookTypeId");

                    b.ToTable("BookTypes");
                });

            modelBuilder.Entity("Database.Data.BookScheme.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BookCollections", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.DATA.BookScheme.Collections", null)
                        .WithMany()
                        .HasForeignKey("CollectionsCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.DATA.BookScheme.Book", b =>
                {
                    b.HasOne("Database.Data.BookScheme.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("IdAuthor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Data.BookScheme.BookType", "BookType")
                        .WithMany("Book")
                        .HasForeignKey("IdBookType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Data.BookScheme.Genre", "Genre")
                        .WithMany("Book")
                        .HasForeignKey("IdGenre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookType");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Database.DATA.CMS.BookPreviewCollection", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", "Book")
                        .WithOne("BookPreview")
                        .HasForeignKey("Database.DATA.CMS.BookPreviewCollection", "BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.DATA.Library.BookPage", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", "Book")
                        .WithOne("BookPage")
                        .HasForeignKey("Database.DATA.Library.BookPage", "BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.DATA.Library.ListenAudioBookPage", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", "Book")
                        .WithOne("ListenAudioBookPage")
                        .HasForeignKey("Database.DATA.Library.ListenAudioBookPage", "BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.DATA.Library.ReadOnlineBook", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", "Book")
                        .WithOne("ReadOnlineBook")
                        .HasForeignKey("Database.DATA.Library.ReadOnlineBook", "BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.DATA.BookScheme.Book", b =>
                {
                    b.Navigation("BookPage");

                    b.Navigation("BookPreview");

                    b.Navigation("ListenAudioBookPage");

                    b.Navigation("ReadOnlineBook");
                });

            modelBuilder.Entity("Database.Data.BookScheme.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Database.Data.BookScheme.BookType", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.Data.BookScheme.Genre", b =>
                {
                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}
