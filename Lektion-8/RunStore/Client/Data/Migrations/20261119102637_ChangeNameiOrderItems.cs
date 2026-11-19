using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Client.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameiOrderItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "orderitems",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "orderitems",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "orderitems",
                newName: "discount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "orderitems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "orderitems",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "discount",
                table: "orderitems",
                newName: "Discount");
        }
    }
}
