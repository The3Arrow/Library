using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "EditionYear", "Title" },
                values: new object[] { "A witty romantic drama by Jane Austen exploring love, social class, and misunderstandings in 19th-century England.", "1813", "Pride and Prejudice" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "EditionYear", "Title" },
                values: new object[] { 1, "Herman Melville's epic tale of Captain Ahab's obsessive quest to hunt the elusive white whale, Moby Dick.", "1851", "Moby-Dick" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "Description", "EditionYear", "Title" },
                values: new object[,]
                {
                    { 3, 2, "Hans Christian Andersen's poignant fairy tale about a mermaid who dreams of life on land and sacrifices everything for love.", "1837", "The Little Mermaid" },
                    { 4, 2, "From the Brothers Grimm, this classic tale tells the story of a princess, her wicked stepmother, and seven helpful dwarfs.", "1812", "Snow White" },
                    { 5, 3, "Samuel Taylor Coleridge's haunting lyrical ballad about a mariner cursed after killing an albatross at sea.", "1798", "The Rime of the Ancient Mariner" }
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Novel");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Fairy tale");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Ballad");

            migrationBuilder.InsertData(
                table: "Copies",
                columns: new[] { "CopyId", "BookId", "IsAvailable" },
                values: new object[,]
                {
                    { 1, 1, true },
                    { 2, 1, true },
                    { 3, 2, true },
                    { 4, 3, true },
                    { 5, 4, true },
                    { 6, 5, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "CopyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "CopyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "CopyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "CopyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "CopyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "CopyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "EditionYear", "Title" },
                values: new object[] { "Opis 1", "2024", "Book 1" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "EditionYear", "Title" },
                values: new object[] { 2, "Opis 2", "2023", "Film 2" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Komedia");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Akcja");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Dramat");
        }
    }
}
