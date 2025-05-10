using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop2.Migrations
{
    /// <inheritdoc />
    public partial class AddTwoFieldForAvgInBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AvgRating",
                table: "Books",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingCount",
                table: "Books",
                type: "int",
                nullable: true);
            migrationBuilder.Sql(@"UPDATE Books
SET
    AvgRating = ISNULL(RatingStats.AvgScore, 0),
    RatingCount = ISNULL(RatingStats.TotalCount, 0)
FROM Books
LEFT JOIN (
    SELECT 
        BookId,
        COUNT(*) AS TotalCount,
        AVG(CAST(Score AS FLOAT)) AS AvgScore
    FROM RatingData
    GROUP BY BookId
) AS RatingStats ON Books.Id = RatingStats.BookId;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgRating",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "RatingCount",
                table: "Books");
        }
    }
}
