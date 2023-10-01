using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewLab1_MinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvaliabel = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "IsAvaliabel", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Jules Verne", null, "Äventyrsroman", true, 1873, "Around the World in Eighty Days" },
                    { 2, "Jules Verne", null, "Science fiction", true, 1870, "Twenty Thousand Leagues Under the Seas" },
                    { 3, "Alexandre Dumas", null, "Historical novel", false, 1995, "The Count of Monte Cristo" },
                    { 4, "Richard Dawkins", null, "Fact", true, 1995, "The God Delusion" },
                    { 5, "Unknown / King James Bible", null, "Religious Text", true, 0, "The Holy Bible" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
