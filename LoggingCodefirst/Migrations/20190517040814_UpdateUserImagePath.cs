using Microsoft.EntityFrameworkCore.Migrations;

namespace LoggingCodefirst.Migrations
{
    public partial class UpdateUserImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "User",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImagePath", "Password" },
                values: new object[] { "05172019110557huan.jpg", "10000:pxptb0cUx+KmYTqq7ziJCgA1/2PYEz/eqiziGEZOs+rydJBJ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "10000:WQlkvGDAvT/Ri+bdJhmZgvO7CLsgbHmt9mvFod7m1Xtx0k1J");
        }
    }
}
