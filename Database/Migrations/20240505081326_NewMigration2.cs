using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookpreviews_Books_BookId",
                table: "Bookpreviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookpreviews",
                table: "Bookpreviews");

            migrationBuilder.RenameTable(
                name: "Bookpreviews",
                newName: "BookPreviewCollections");

            migrationBuilder.RenameIndex(
                name: "IX_Bookpreviews_BookId",
                table: "BookPreviewCollections",
                newName: "IX_BookPreviewCollections_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookPreviewCollections",
                table: "BookPreviewCollections",
                column: "PreviewId");

            migrationBuilder.CreateTable(
                name: "BookPreviewNewests",
                columns: table => new
                {
                    NewestBookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SmallCoverImg = table.Column<string>(type: "TEXT", nullable: true),
                    BookLink = table.Column<string>(type: "TEXT", nullable: true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPreviewNewests", x => x.NewestBookId);
                    table.ForeignKey(
                        name: "FK_BookPreviewNewests_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                });

            migrationBuilder.CreateTable(
                name: "MobileBookCollectionPreviews",
                columns: table => new
                {
                    CollectionPreviewId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SmallCoverImg = table.Column<string>(type: "TEXT", nullable: true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileBookCollectionPreviews", x => x.CollectionPreviewId);
                    table.ForeignKey(
                        name: "FK_MobileBookCollectionPreviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                });

            migrationBuilder.CreateTable(
                name: "MobileBookPages",
                columns: table => new
                {
                    MobileBookPageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MobileBigCoverImg = table.Column<string>(type: "TEXT", nullable: true),
                    PdfUrl = table.Column<string>(type: "TEXT", nullable: true),
                    AudioBookUrl = table.Column<string>(type: "TEXT", nullable: true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileBookPages", x => x.MobileBookPageId);
                    table.ForeignKey(
                        name: "FK_MobileBookPages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                });

            migrationBuilder.CreateTable(
                name: "MobileBookPreviews",
                columns: table => new
                {
                    MobileBookPreviewId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SmallCoverImg = table.Column<string>(type: "TEXT", nullable: true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileBookPreviews", x => x.MobileBookPreviewId);
                    table.ForeignKey(
                        name: "FK_MobileBookPreviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPreviewNewests_BookId",
                table: "BookPreviewNewests",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileBookCollectionPreviews_BookId",
                table: "MobileBookCollectionPreviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileBookPages_BookId",
                table: "MobileBookPages",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileBookPreviews_BookId",
                table: "MobileBookPreviews",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPreviewCollections_Books_BookId",
                table: "BookPreviewCollections",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPreviewCollections_Books_BookId",
                table: "BookPreviewCollections");

            migrationBuilder.DropTable(
                name: "BookPreviewNewests");

            migrationBuilder.DropTable(
                name: "MobileBookCollectionPreviews");

            migrationBuilder.DropTable(
                name: "MobileBookPages");

            migrationBuilder.DropTable(
                name: "MobileBookPreviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookPreviewCollections",
                table: "BookPreviewCollections");

            migrationBuilder.RenameTable(
                name: "BookPreviewCollections",
                newName: "Bookpreviews");

            migrationBuilder.RenameIndex(
                name: "IX_BookPreviewCollections_BookId",
                table: "Bookpreviews",
                newName: "IX_Bookpreviews_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookpreviews",
                table: "Bookpreviews",
                column: "PreviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookpreviews_Books_BookId",
                table: "Bookpreviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId");
        }
    }
}
