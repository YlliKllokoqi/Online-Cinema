using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DS.CineLabs.Infrastructure.Migrations
{
    public partial class TicketDetailsDroped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketDetails_TicketDetailsId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketDetails");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketDetailsId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketDetailsId",
                table: "Tickets");

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketDetailsId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TicketDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TicketModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatetAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketDetailsId",
                table: "Tickets",
                column: "TicketDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketDetails_TicketDetailsId",
                table: "Tickets",
                column: "TicketDetailsId",
                principalTable: "TicketDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
