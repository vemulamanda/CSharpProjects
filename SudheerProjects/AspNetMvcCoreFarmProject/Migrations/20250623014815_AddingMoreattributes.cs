using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetMvcCoreFarmProject.Migrations
{
    /// <inheritdoc />
    public partial class AddingMoreattributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FB_Pieces",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FB_Price",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FB_Pieces",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FB_Price",
                table: "Customers");
        }
    }
}
