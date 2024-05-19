using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class _2nd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobileBooksAuthorCard_Authors_BookId",
                table: "MobileBooksAuthorCard");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "MobileBooksAuthorCard",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_MobileBooksAuthorCard_BookId",
                table: "MobileBooksAuthorCard",
                newName: "IX_MobileBooksAuthorCard_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MobileBooksAuthorCard_Authors_AuthorId",
                table: "MobileBooksAuthorCard",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobileBooksAuthorCard_Authors_AuthorId",
                table: "MobileBooksAuthorCard");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "MobileBooksAuthorCard",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_MobileBooksAuthorCard_AuthorId",
                table: "MobileBooksAuthorCard",
                newName: "IX_MobileBooksAuthorCard_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_MobileBooksAuthorCard_Authors_BookId",
                table: "MobileBooksAuthorCard",
                column: "BookId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
