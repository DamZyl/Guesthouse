using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Guesthouse.Infrastructure.Migrations
{
    public partial class Simple_change_reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookedAt",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BookedTo",
                table: "Rooms");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookedAt",
                table: "ReservationRooms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BookedTo",
                table: "ReservationRooms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ReservationRooms",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "ReservationConveniences",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookedAt",
                table: "ReservationRooms");

            migrationBuilder.DropColumn(
                name: "BookedTo",
                table: "ReservationRooms");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ReservationRooms");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "ReservationConveniences");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookedAt",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BookedTo",
                table: "Rooms",
                nullable: true);
        }
    }
}
