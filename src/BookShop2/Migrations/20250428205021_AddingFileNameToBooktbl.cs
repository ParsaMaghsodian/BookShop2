using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop2.Migrations
{
    /// <inheritdoc />
    public partial class AddingFileNameToBooktbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Books",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Books");
        }
    }
}
