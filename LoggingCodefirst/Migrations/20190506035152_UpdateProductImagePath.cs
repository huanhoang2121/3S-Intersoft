using Microsoft.EntityFrameworkCore.Migrations;

namespace LoggingCodefirst.Migrations
{
    public partial class UpdateProductImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductImage",
                table: "Product",
                newName: "ImagePath");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "10000:kDsXGtZs1K0Ivw6myygLp3nBbrzOJ06sc2kTgaq0pq2UHXoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Product",
                newName: "ProductImage");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "10000:uUYDuHVmXDQ2y0t7uT4ZEfm/wBnp7PQ+B0vLjkqNO2mNU0e6");
        }
    }
}
