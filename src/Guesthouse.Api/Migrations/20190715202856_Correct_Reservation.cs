using Microsoft.EntityFrameworkCore.Migrations;

namespace Guesthouse.Infrastructure.Migrations
{
    public partial class Correct_Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayStatus",
                table: "Reservations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReservationStatus",
                table: "Reservations",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PayStatus",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationStatus",
                table: "Reservations");
        }
    }
}
