using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toshokan.Migrations
{
    /// <inheritdoc />
    public partial class BookRentCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imgURL",
                table: "Book",
                newName: "ImgURL");

            migrationBuilder.AddColumn<double>(
                name: "RentCost",
                table: "Book",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentCost",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "ImgURL",
                table: "Book",
                newName: "imgURL");
        }
    }
}
