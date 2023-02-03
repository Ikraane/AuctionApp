using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectApp.Migrations
{
    public partial class Initiate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "AuctionDBs");

            migrationBuilder.DropColumn(
                name: "_Status",
                table: "AuctionDBs");

            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "AuctionID",
                keyValue: -1,
                columns: new[] { "CreateDate", "Seller" },
                values: new object[] { new DateTime(2022, 10, 22, 18, 8, 48, 584, DateTimeKind.Local).AddTicks(7613), "idali2@kth.se" });

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "BidID",
                keyValue: -1,
                column: "BidDate",
                value: new DateTime(2022, 10, 22, 18, 8, 48, 584, DateTimeKind.Local).AddTicks(7816));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "AuctionDBs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "_Status",
                table: "AuctionDBs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "AuctionID",
                keyValue: -1,
                columns: new[] { "CreateDate", "Seller", "Winner" },
                values: new object[] { new DateTime(2022, 10, 21, 20, 14, 39, 796, DateTimeKind.Local).AddTicks(2902), "test@kth.se", " " });

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "BidID",
                keyValue: -1,
                column: "BidDate",
                value: new DateTime(2022, 10, 21, 20, 14, 39, 796, DateTimeKind.Local).AddTicks(3091));
        }
    }
}
