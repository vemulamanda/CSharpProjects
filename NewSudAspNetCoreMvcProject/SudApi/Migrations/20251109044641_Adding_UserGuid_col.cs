using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudApi.Migrations
{
    /// <inheritdoc />
    public partial class Adding_UserGuid_col : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserGuid",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Farmers");
        }
    }
}
