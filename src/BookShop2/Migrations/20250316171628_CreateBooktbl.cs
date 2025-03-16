using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShop2.Migrations
{
    /// <inheritdoc />
    public partial class CreateBooktbl : Migration
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
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.CheckConstraint("CK_BookData_Pages", "[Pages] >=0 AND [Pages]<=10000");
                    table.CheckConstraint("CK_BookData_Price", "[Price] >=0 AND [Price]<=1000");
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Date", "Description", "Name", "Pages", "Price" },
                values: new object[,]
                {
                    { 1, "Andrew Lock", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Build professional-grade full-stack web applications using C# and ASP.NET Core. In ASP.NET Core in Action, Third Edition", "ASP.NET Core in Action", 984, 50 },
                    { 2, "Adam Freeman", new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Now in its tenth edition, this industry-leading guide to ASP.NET Core teaches everything you need to know to create easy, extensible, and cloud-native web applications", "Pro ASP.NET Core 7", 1256, 65 }
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
