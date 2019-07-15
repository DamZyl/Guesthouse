using Microsoft.EntityFrameworkCore.Migrations;

namespace Guesthouse.Infrastructure.Migrations
{
    public partial class Convert_enum_to_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PayType",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PayType",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
