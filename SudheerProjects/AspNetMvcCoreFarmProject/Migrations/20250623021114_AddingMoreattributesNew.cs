using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetMvcCoreFarmProject.Migrations
{
    /// <inheritdoc />
    public partial class AddingMoreattributesNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SB_Pieces",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SB_Price",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TB_Pieces",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TB_Price",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SB_Pieces",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SB_Price",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TB_Pieces",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TB_Price",
                table: "Customers");
        }
    }
}
