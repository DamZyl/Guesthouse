using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Guesthouse.Infrastructure.Migrations
{
    public partial class Addtwocolumnstoroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BookedAt",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BookedTo",
                table: "Rooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookedAt",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BookedTo",
                table: "Rooms");
        }
    }
}
