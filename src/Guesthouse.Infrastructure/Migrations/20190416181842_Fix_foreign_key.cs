using Microsoft.EntityFrameworkCore.Migrations;

namespace Guesthouse.Infrastructure.Migrations
{
    public partial class Fix_foreign_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conveniences_Reservations_Id",
                table: "Conveniences");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_Id",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ReservationId",
                table: "Rooms",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Conveniences_ReservationId",
                table: "Conveniences",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conveniences_Reservations_ReservationId",
                table: "Conveniences",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservations_ReservationId",
                table: "Rooms",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conveniences_Reservations_ReservationId",
                table: "Conveniences");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_ReservationId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ReservationId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Conveniences_ReservationId",
                table: "Conveniences");

            migrationBuilder.AddForeignKey(
                name: "FK_Conveniences_Reservations_Id",
                table: "Conveniences",
                column: "Id",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservations_Id",
                table: "Rooms",
                column: "Id",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
