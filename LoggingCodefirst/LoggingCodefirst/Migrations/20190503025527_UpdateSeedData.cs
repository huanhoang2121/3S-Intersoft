using Microsoft.EntityFrameworkCore.Migrations;

namespace LoggingCodefirst.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "BrandName" },
                values: new object[] { 2, "Nike" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 2, "Quần" });

            migrationBuilder.UpdateData(
                table: "Stock",
                keyColumns: new[] { "ProductId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "Quanlity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "StoreName", "Street", "ZipCode" },
                values: new object[] { "hanoistore@3si.com.vn", "3S Hà Nội", "123 Phạm Hùng", "100000" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "City", "Email", "Phone", "State", "StoreName", "Street", "ZipCode" },
                values: new object[] { 2, "Huế", "huestore@3si.com.vn", "0903649741", "Thừa thiên Huế", "3S Huế", "23 Hùng Vương", "530000" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BrandId", "ModelYear", "ProductImage", "ProductName" },
                values: new object[] { 2, 2017, "05-02-2019-09-04-35.jpg", "Áo nike" });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "ProductId", "StoreId", "Quanlity" },
                values: new object[] { 1, 2, 2 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Password", "Phone", "StoreId" },
                values: new object[] { "Huế, Thừa thiên Huế", "10000:uUYDuHVmXDQ2y0t7uT4ZEfm/wBnp7PQ+B0vLjkqNO2mNU0e6", "0964973404", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumns: new[] { "ProductId", "StoreId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BrandId", "ModelYear", "ProductImage", "ProductName" },
                values: new object[] { 1, 1, "en-US.png", "Áo adidas 1" });

            migrationBuilder.UpdateData(
                table: "Stock",
                keyColumns: new[] { "ProductId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "Quanlity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "StoreName", "Street", "ZipCode" },
                values: new object[] { "store@3si.com.vn", "3S Huế", "Phạm Hùng", "HANOI123" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Password", "Phone", "StoreId" },
                values: new object[] { "Thừa thiên Huế", "10000:Eab/O9Xi0QcTahzzLKtC5AKGw0QId+BnTndyJSzZ/pP8zfG8", "0131651234", 1 });
        }
    }
}
