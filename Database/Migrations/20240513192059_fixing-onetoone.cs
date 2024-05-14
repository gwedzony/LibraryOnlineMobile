using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class fixingonetoone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_DetailBookMobilePages_DetailBookMobilePageId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_DetailBookMobilePageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DetailBookMobilePageId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "DetailBookMobilePages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetailBookMobilePages_BookId",
                table: "DetailBookMobilePages",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailBookMobilePages_Books_BookId",
                table: "DetailBookMobilePages",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailBookMobilePages_Books_BookId",
                table: "DetailBookMobilePages");

            migrationBuilder.DropIndex(
                name: "IX_DetailBookMobilePages_BookId",
                table: "DetailBookMobilePages");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "DetailBookMobilePages");

            migrationBuilder.AddColumn<int>(
                name: "DetailBookMobilePageId",
                table: "Books",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_DetailBookMobilePageId",
                table: "Books",
                column: "DetailBookMobilePageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_DetailBookMobilePages_DetailBookMobilePageId",
                table: "Books",
                column: "DetailBookMobilePageId",
                principalTable: "DetailBookMobilePages",
                principalColumn: "Id");
        }
    }
}
