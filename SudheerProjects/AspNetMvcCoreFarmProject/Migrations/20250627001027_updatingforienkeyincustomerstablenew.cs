using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetMvcCoreFarmProject.Migrations
{
    /// <inheritdoc />
    public partial class updatingforienkeyincustomerstablenew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_Identity_userId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Identity_userId",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_Identity_userId",
                table: "Customers",
                newName: "IX_Customers_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_Id",
                table: "Customers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_Id",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "Identity_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_Id",
                table: "Customers",
                newName: "IX_Customers_Identity_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_Identity_userId",
                table: "Customers",
                column: "Identity_userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
