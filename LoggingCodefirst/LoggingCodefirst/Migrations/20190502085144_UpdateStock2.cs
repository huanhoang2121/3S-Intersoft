using Microsoft.EntityFrameworkCore.Migrations;

namespace LoggingCodefirst.Migrations
{
    public partial class UpdateStock2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Stock_StockProductId_StockStoreId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_StockProductId_StockStoreId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StockProductId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StockStoreId",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "10000:Eab/O9Xi0QcTahzzLKtC5AKGw0QId+BnTndyJSzZ/pP8zfG8");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Product_ProductId",
                table: "Stock",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Product_ProductId",
                table: "Stock");

            migrationBuilder.AddColumn<int>(
                name: "StockProductId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockStoreId",
                table: "Product",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "10000:8hFR2+G3LNBPdHeacN1Y1NPUIKz1SNZMc4LoNxW/q9xNaUkq");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StockProductId_StockStoreId",
                table: "Product",
                columns: new[] { "StockProductId", "StockStoreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Stock_StockProductId_StockStoreId",
                table: "Product",
                columns: new[] { "StockProductId", "StockStoreId" },
                principalTable: "Stock",
                principalColumns: new[] { "ProductId", "StoreId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
