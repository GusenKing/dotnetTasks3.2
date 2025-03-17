using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lesson1.GraphQL.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPersonModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Name",
                keyValue: "Person 1");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Name",
                keyValue: "Person 10");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Name",
                keyValue: "Person 2");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Name",
                keyValue: "Person 3");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Name",
                keyValue: "Person 4");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Name",
                keyValue: "Person 5");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Name",
                keyValue: "Person 6");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Name",
                keyValue: "Person 7");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Name",
                keyValue: "Person 8");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Name",
                keyValue: "Person 9");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "People",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Age", "Job", "Name" },
                values: new object[,]
                {
                    { new Guid("00b3a99c-e647-4427-8f5b-07f56de905d2"), 21, "Job 1", "Person 1" },
                    { new Guid("2cc91448-a121-41ae-9a8c-7ebe975811e7"), 100, "Job 1", "Person 10" },
                    { new Guid("490e0284-bae9-45f4-b680-e69cce13d546"), 40, "Job 3", "Person 7" },
                    { new Guid("718ebe90-41e4-4b00-a3da-5dad0aedae03"), 30, "Job 2", "Person 6" },
                    { new Guid("7c693a57-1142-4d61-a329-9dced10f9788"), 18, "Job 3", "Person 9" },
                    { new Guid("86681787-1f41-4eaf-9139-f64b9db800e8"), 19, "Job 3", "Person 8" },
                    { new Guid("b60fa1de-82c7-4dea-895f-f0f4c89d6a0c"), 21, "Job 1", "Person 2" },
                    { new Guid("c628b519-9875-435e-a8c4-add09561e8bc"), 31, "Job 1", "Person 3" },
                    { new Guid("cf164e63-0ad8-4731-ad38-dc2395190a42"), 20, "Job 2", "Person 5" },
                    { new Guid("fea55368-5857-403e-93b0-c2f14232bc1b"), 41, "Job 2", "Person 4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("00b3a99c-e647-4427-8f5b-07f56de905d2"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("2cc91448-a121-41ae-9a8c-7ebe975811e7"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("490e0284-bae9-45f4-b680-e69cce13d546"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("718ebe90-41e4-4b00-a3da-5dad0aedae03"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("7c693a57-1142-4d61-a329-9dced10f9788"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("86681787-1f41-4eaf-9139-f64b9db800e8"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("b60fa1de-82c7-4dea-895f-f0f4c89d6a0c"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("c628b519-9875-435e-a8c4-add09561e8bc"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("cf164e63-0ad8-4731-ad38-dc2395190a42"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("fea55368-5857-403e-93b0-c2f14232bc1b"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Name");

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
    }
}
