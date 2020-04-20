using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GUI_EX2_Buffet.Data.Migrations
{
    public partial class databasetilfojet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckInStatuses",
                columns: table => new
                {
                    Room = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfAdultsCheckedIn = table.Column<int>(nullable: false),
                    NumberOfChildsCheckedIn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckInStatuses", x => x.Room);
                });

            migrationBuilder.CreateTable(
                name: "BreakfastReservations",
                columns: table => new
                {
                    Room = table.Column<int>(nullable: false),
                    NumberOfAdults = table.Column<int>(nullable: false),
                    NumberOfChilds = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastReservations", x => x.Room);
                    table.ForeignKey(
                        name: "FK_BreakfastReservations_CheckInStatuses_Room",
                        column: x => x.Room,
                        principalTable: "CheckInStatuses",
                        principalColumn: "Room",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakfastReservations");

            migrationBuilder.DropTable(
                name: "CheckInStatuses");
        }
    }
}
