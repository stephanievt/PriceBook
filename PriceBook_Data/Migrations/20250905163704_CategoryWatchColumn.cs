using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceBook_Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryWatchColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Watch",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Category_Watch_Name",
                table: "Category",
                columns: new[] { "Watch", "Name" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Category_Watch_Name",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Watch",
                table: "Category");
        }
    }
}
