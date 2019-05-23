using Microsoft.EntityFrameworkCore.Migrations;

namespace LoggingCodefirst.Migrations
{
    public partial class UpdateUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "10000:iBSOy74HViTRvKRNt9rK3tiFJaW7N1wEsbkW/kW+KrxxMSpO", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "10000:8uR8dX7otUjX4l0GtYSSZ5zF1Aw0lZZc6oBSuQYzFIwp1cG1");
        }
    }
}
