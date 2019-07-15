using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Guesthouse.Infrastructure.Migrations
{
    public partial class Fix_problem_with_Convenience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReservationId",
                table: "Conveniences",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Conveniences");
        }
    }
}
