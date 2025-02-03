using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StageEs1.Migrations
{
    /// <inheritdoc />
    public partial class address_modified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Indirizzo",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Cap",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Citta",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Via",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cap",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Citta",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Via",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Indirizzo",
                table: "Customers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
