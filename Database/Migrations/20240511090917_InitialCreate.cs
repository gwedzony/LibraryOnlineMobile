using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailBookMobilePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailBookMobilePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LatestMobileBooksAuthorCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatestMobileBooksAuthorCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LatestMobileBooksCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatestMobileBooksCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RandomMobileBooksCollectionCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomMobileBooksCollectionCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: true),
                    LatestMobileBooksAuthorCardId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_LatestMobileBooksAuthorCard_LatestMobileBooksAuthorCardId",
                        column: x => x.LatestMobileBooksAuthorCardId,
                        principalTable: "LatestMobileBooksAuthorCard",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CollectionName = table.Column<string>(type: "TEXT", nullable: false),
                    CollectionImage = table.Column<string>(type: "TEXT", nullable: false),
                    RandomCollectionsMobilePageId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_RandomMobileBooksCollectionCards_RandomCollectionsMobilePageId",
                        column: x => x.RandomCollectionsMobilePageId,
                        principalTable: "RandomMobileBooksCollectionCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    ReadCount = table.Column<long>(type: "INTEGER", nullable: false),
                    AddDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookGenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    LatestMobileBooksCardId = table.Column<int>(type: "INTEGER", nullable: true),
                    DetailBookMobilePageId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_DetailBookMobilePages_DetailBookMobilePageId",
                        column: x => x.DetailBookMobilePageId,
                        principalTable: "DetailBookMobilePages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_Genres_BookGenreId",
                        column: x => x.BookGenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_LatestMobileBooksCard_LatestMobileBooksCardId",
                        column: x => x.LatestMobileBooksCardId,
                        principalTable: "LatestMobileBooksCard",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookCollection",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "INTEGER", nullable: false),
                    CollectionsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCollection", x => new { x.BooksId, x.CollectionsId });
                    table.ForeignKey(
                        name: "FK_BookCollection_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCollection_Collections_CollectionsId",
                        column: x => x.CollectionsId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksCollections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    CollectionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksCollections_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksCollections_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_LatestMobileBooksAuthorCardId",
                table: "Authors",
                column: "LatestMobileBooksAuthorCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookCollection_CollectionsId",
                table: "BookCollection",
                column: "CollectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookGenreId",
                table: "Books",
                column: "BookGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_DetailBookMobilePageId",
                table: "Books",
                column: "DetailBookMobilePageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_LatestMobileBooksCardId",
                table: "Books",
                column: "LatestMobileBooksCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksCollections_BookId",
                table: "BooksCollections",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksCollections_CollectionId",
                table: "BooksCollections",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_RandomCollectionsMobilePageId",
                table: "Collections",
                column: "RandomCollectionsMobilePageId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCollection");

            migrationBuilder.DropTable(
                name: "BooksCollections");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "DetailBookMobilePages");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "LatestMobileBooksCard");

            migrationBuilder.DropTable(
                name: "RandomMobileBooksCollectionCards");

            migrationBuilder.DropTable(
                name: "LatestMobileBooksAuthorCard");
        }
    }
}
