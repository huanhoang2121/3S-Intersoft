using Microsoft.EntityFrameworkCore.Migrations;

namespace LoggingCodefirst.Migrations
{
    public partial class UpdateStock3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quanlity",
                table: "Stock",
                newName: "Quantity");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "10000:7WGAlsKwm/65VBDm/cI2a1v+XgPr9bCNr55XuDpkj44SIECd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Stock",
                newName: "Quanlity");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "10000:qvehCF89JW0RjZX1Q3KOKasOPnr0ToRgJKtkfTOr0WMxGa3y");
        }
    }
}
