﻿// <auto-generated />
using System;
using Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("BookCollection", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CollectionsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BooksId", "CollectionsId");

                    b.HasIndex("CollectionsId");

                    b.ToTable("BookCollection");
                });

            modelBuilder.Entity("Database.Data.BookStructure.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LatestMobileBooksAuthorCardId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LatestMobileBooksAuthorCardId")
                        .IsUnique();

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Database.Data.BookStructure.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookGenreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("DetailBookMobilePageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LatestMobileBooksCardId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ReadCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookGenreId");

                    b.HasIndex("DetailBookMobilePageId")
                        .IsUnique();

                    b.HasIndex("LatestMobileBooksCardId")
                        .IsUnique();

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Database.Data.BookStructure.BookCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CollectionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CollectionId");

                    b.ToTable("BooksCollections");
                });

            modelBuilder.Entity("Database.Data.BookStructure.BookGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Database.Data.BookStructure.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CollectionImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CollectionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RandomCollectionsMobilePageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RandomCollectionsMobilePageId")
                        .IsUnique();

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("Database.Data.MobileApp.DetailBookMobilePage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DetailBookMobilePages");
                });

            modelBuilder.Entity("Database.Data.MobileApp.LatestMobileBooksAuthorCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("LatestMobileBooksAuthorCard");
                });

            modelBuilder.Entity("Database.Data.MobileApp.LatestMobileBooksCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("LatestMobileBooksCard");
                });

            modelBuilder.Entity("Database.Data.MobileApp.RandomMobileBooksCollectionCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("RandomMobileBooksCollectionCards");
                });

            modelBuilder.Entity("BookCollection", b =>
                {
                    b.HasOne("Database.Data.BookStructure.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Data.BookStructure.Collection", null)
                        .WithMany()
                        .HasForeignKey("CollectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Data.BookStructure.Author", b =>
                {
                    b.HasOne("Database.Data.MobileApp.LatestMobileBooksAuthorCard", "LatestMobileBooksAuthorCard")
                        .WithOne("Book")
                        .HasForeignKey("Database.Data.BookStructure.Author", "LatestMobileBooksAuthorCardId");

                    b.Navigation("LatestMobileBooksAuthorCard");
                });

            modelBuilder.Entity("Database.Data.BookStructure.Book", b =>
                {
                    b.HasOne("Database.Data.BookStructure.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Data.BookStructure.BookGenre", "BookGenre")
                        .WithMany("Books")
                        .HasForeignKey("BookGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Data.MobileApp.DetailBookMobilePage", "DetailBookMobilePages")
                        .WithOne("Book")
                        .HasForeignKey("Database.Data.BookStructure.Book", "DetailBookMobilePageId");

                    b.HasOne("Database.Data.MobileApp.LatestMobileBooksCard", "LatestMobileBooksCard")
                        .WithOne("Book")
                        .HasForeignKey("Database.Data.BookStructure.Book", "LatestMobileBooksCardId");

                    b.Navigation("Author");

                    b.Navigation("BookGenre");

                    b.Navigation("DetailBookMobilePages");

                    b.Navigation("LatestMobileBooksCard");
                });

            modelBuilder.Entity("Database.Data.BookStructure.BookCollection", b =>
                {
                    b.HasOne("Database.Data.BookStructure.Book", "Book")
                        .WithMany("BookCollections")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Data.BookStructure.Collection", "Collection")
                        .WithMany("BookCollections")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Database.Data.BookStructure.Collection", b =>
                {
                    b.HasOne("Database.Data.MobileApp.RandomMobileBooksCollectionCard", "RandomCollectionsMobilePage")
                        .WithOne("Collection")
                        .HasForeignKey("Database.Data.BookStructure.Collection", "RandomCollectionsMobilePageId");

                    b.Navigation("RandomCollectionsMobilePage");
                });

            modelBuilder.Entity("Database.Data.BookStructure.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Database.Data.BookStructure.Book", b =>
                {
                    b.Navigation("BookCollections");
                });

            modelBuilder.Entity("Database.Data.BookStructure.BookGenre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Database.Data.BookStructure.Collection", b =>
                {
                    b.Navigation("BookCollections");
                });

            modelBuilder.Entity("Database.Data.MobileApp.DetailBookMobilePage", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.Data.MobileApp.LatestMobileBooksAuthorCard", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.Data.MobileApp.LatestMobileBooksCard", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.Data.MobileApp.RandomMobileBooksCollectionCard", b =>
                {
                    b.Navigation("Collection");
                });
#pragma warning restore 612, 618
        }
    }
}
