using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShop2.Migrations
{
    /// <inheritdoc />
    public partial class AddingBookCategorytbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Technical" },
                    { 2, "Fiction" },
                    { 3, "Children" },
                    { 4, "Novel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverImage", "Date", "Description", "Language", "Name", "Pages", "Price" },
                values: new object[,]
                {
                    { 1, "Andrew Lock", null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Build professional-grade full-stack web applications using C# and ASP.NET Core. In ASP.NET Core in Action, Third Edition", 0, "ASP.NET Core in Action", 984, 50 },
                    { 2, "Adam Freeman", null, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Now in its tenth edition, this industry-leading guide to ASP.NET Core teaches everything you need to know to create easy, extensible, and cloud-native web applications", 0, "Pro ASP.NET Core 7", 1256, 65 }
                });
        }
    }
}
