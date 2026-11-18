using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Client.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTestdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "email", "firstName", "lastName", "phone" },
                values: new object[,]
                {
                    { 1, "anna.andersson@mail.com", "Anna", "Andersson", "070-123 45 67" },
                    { 2, "erik.johansson@mail.com", "Erik", "Johansson", "073-234 56 78" }
                });

            migrationBuilder.InsertData(
                table: "salesorders",
                columns: new[] { "id", "orderDate", "orderNumber" },
                values: new object[,]
                {
                    { 1, new DateOnly(2026, 10, 1), "1001" },
                    { 2, new DateOnly(2026, 10, 8), "1002" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "salesorders",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "salesorders",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
