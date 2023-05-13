using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArenaGestor.DataAccess.Migrations
{
    public partial class snacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Snack",
                columns: table => new
                {
                    SnackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snack", x => x.SnackId);
                });

            migrationBuilder.CreateTable(
                name: "SnackPurchase",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackPurchase", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "SnackPurchaseItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SnackId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    SnackPurchaseTicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackPurchaseItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SnackPurchaseItem_Snack_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snack",
                        principalColumn: "SnackId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SnackPurchaseItem_SnackPurchase_SnackPurchaseTicketId",
                        column: x => x.SnackPurchaseTicketId,
                        principalTable: "SnackPurchase",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SnackPurchaseItem_SnackId",
                table: "SnackPurchaseItem",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_SnackPurchaseItem_SnackPurchaseTicketId",
                table: "SnackPurchaseItem",
                column: "SnackPurchaseTicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SnackPurchaseItem");

            migrationBuilder.DropTable(
                name: "Snack");

            migrationBuilder.DropTable(
                name: "SnackPurchase");
        }
    }
}
