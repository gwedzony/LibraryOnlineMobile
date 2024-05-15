using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class fixingrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_LatestMobileBooksAuthorCard_LatestMobileBooksAuthorCardId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_LatestMobileBooksCard_LatestMobileBooksCardId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_RandomMobileBooksCollectionCards_RandomCollectionsMobilePageId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_RandomCollectionsMobilePageId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Books_LatestMobileBooksCardId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_LatestMobileBooksAuthorCardId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "LatestMobileBooksCardId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "RandomMobileBooksCollectionCards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "LatestMobileBooksCard",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "LatestMobileBooksAuthorCard",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RandomMobileBooksCollectionCardId",
                table: "BooksCollections",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RandomMobileBooksCollectionCards_CollectionId",
                table: "RandomMobileBooksCollectionCards",
                column: "CollectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LatestMobileBooksCard_BookId",
                table: "LatestMobileBooksCard",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LatestMobileBooksAuthorCard_BookId",
                table: "LatestMobileBooksAuthorCard",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksCollections_RandomMobileBooksCollectionCardId",
                table: "BooksCollections",
                column: "RandomMobileBooksCollectionCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCollections_RandomMobileBooksCollectionCards_RandomMobileBooksCollectionCardId",
                table: "BooksCollections",
                column: "RandomMobileBooksCollectionCardId",
                principalTable: "RandomMobileBooksCollectionCards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LatestMobileBooksAuthorCard_Authors_BookId",
                table: "LatestMobileBooksAuthorCard",
                column: "BookId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LatestMobileBooksCard_Books_BookId",
                table: "LatestMobileBooksCard",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RandomMobileBooksCollectionCards_Collections_CollectionId",
                table: "RandomMobileBooksCollectionCards",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCollections_RandomMobileBooksCollectionCards_RandomMobileBooksCollectionCardId",
                table: "BooksCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_LatestMobileBooksAuthorCard_Authors_BookId",
                table: "LatestMobileBooksAuthorCard");

            migrationBuilder.DropForeignKey(
                name: "FK_LatestMobileBooksCard_Books_BookId",
                table: "LatestMobileBooksCard");

            migrationBuilder.DropForeignKey(
                name: "FK_RandomMobileBooksCollectionCards_Collections_CollectionId",
                table: "RandomMobileBooksCollectionCards");

            migrationBuilder.DropIndex(
                name: "IX_RandomMobileBooksCollectionCards_CollectionId",
                table: "RandomMobileBooksCollectionCards");

            migrationBuilder.DropIndex(
                name: "IX_LatestMobileBooksCard_BookId",
                table: "LatestMobileBooksCard");

            migrationBuilder.DropIndex(
                name: "IX_LatestMobileBooksAuthorCard_BookId",
                table: "LatestMobileBooksAuthorCard");

            migrationBuilder.DropIndex(
                name: "IX_BooksCollections_RandomMobileBooksCollectionCardId",
                table: "BooksCollections");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "RandomMobileBooksCollectionCards");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "LatestMobileBooksCard");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "LatestMobileBooksAuthorCard");

            migrationBuilder.DropColumn(
                name: "RandomMobileBooksCollectionCardId",
                table: "BooksCollections");

            migrationBuilder.AddColumn<int>(
                name: "LatestMobileBooksCardId",
                table: "Books",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_RandomCollectionsMobilePageId",
                table: "Collections",
                column: "RandomCollectionsMobilePageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_LatestMobileBooksCardId",
                table: "Books",
                column: "LatestMobileBooksCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_LatestMobileBooksAuthorCardId",
                table: "Authors",
                column: "LatestMobileBooksAuthorCardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_LatestMobileBooksAuthorCard_LatestMobileBooksAuthorCardId",
                table: "Authors",
                column: "LatestMobileBooksAuthorCardId",
                principalTable: "LatestMobileBooksAuthorCard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_LatestMobileBooksCard_LatestMobileBooksCardId",
                table: "Books",
                column: "LatestMobileBooksCardId",
                principalTable: "LatestMobileBooksCard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_RandomMobileBooksCollectionCards_RandomCollectionsMobilePageId",
                table: "Collections",
                column: "RandomCollectionsMobilePageId",
                principalTable: "RandomMobileBooksCollectionCards",
                principalColumn: "Id");
        }
    }
}
