using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SudApi.Migrations
{
    /// <inheritdoc />
    public partial class CreatingFarmersDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    Custid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    FirstBreed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FB_Price = table.Column<double>(type: "float", nullable: false),
                    FB_Pieces = table.Column<double>(type: "float", nullable: false),
                    SecondBreed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SB_Price = table.Column<double>(type: "float", nullable: true),
                    SB_Pieces = table.Column<double>(type: "float", nullable: true),
                    ThirdBreed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TB_Price = table.Column<double>(type: "float", nullable: true),
                    TB_Pieces = table.Column<double>(type: "float", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.Custid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Farmers");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    C_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.C_Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    P_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    P_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.P_Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "C_Id", "C_Description", "C_Name" },
                values: new object[,]
                {
                    { 1, "Monitors, Laptops", "Hardware" },
                    { 2, "Eye lashes, Mascara etc", "Beauty" },
                    { 3, "Brush, Paste etc", "Household" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "P_Id", "CategoryId", "P_Description", "P_Name", "P_Price" },
                values: new object[,]
                {
                    { 101, 1, "Computer Monitor", "Monitor", 250.5 },
                    { 102, 3, "Household", "Brush", 260.5 },
                    { 103, 2, "Beauty", "Mascara", 270.5 },
                    { 104, 3, "Household", "Paste", 280.5 },
                    { 105, 2, "Beauty", "Eye Lashes", 290.5 },
                    { 106, 1, "Computer Monitor", "Laptop", 300.5 },
                    { 107, 2, "Beauty", "foundation", 350.5 },
                    { 108, 3, "Household", "dustbin", 550.5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }
    }
}
