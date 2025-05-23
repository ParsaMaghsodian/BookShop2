﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop2.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingDatatbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RatingData",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TimeCreation = table.Column<DateTime>(type: "date", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingData", x => new { x.OrderId, x.BookId });
                    table.ForeignKey(
                        name: "FK_RatingData_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RatingData_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RatingData_BookId",
                table: "RatingData",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingData_OrderId",
                table: "RatingData",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingData");
        }
    }
}
