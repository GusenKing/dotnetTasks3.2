using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lesson1.GraphQL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Job = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Name", "Age", "Job" },
                values: new object[,]
                {
                    { "Person 1", 21, "Job 1" },
                    { "Person 10", 100, "Job 1" },
                    { "Person 2", 21, "Job 1" },
                    { "Person 3", 31, "Job 1" },
                    { "Person 4", 41, "Job 2" },
                    { "Person 5", 20, "Job 2" },
                    { "Person 6", 30, "Job 2" },
                    { "Person 7", 40, "Job 3" },
                    { "Person 8", 19, "Job 3" },
                    { "Person 9", 18, "Job 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
