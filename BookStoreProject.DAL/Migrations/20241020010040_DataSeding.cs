using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DataSeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedDate",
                value: new DateTime(2024, 10, 20, 4, 0, 38, 217, DateTimeKind.Local).AddTicks(2900));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "booker" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedDate",
                value: new DateTime(2024, 10, 20, 3, 41, 1, 74, DateTimeKind.Local).AddTicks(9714));
        }
    }
}
