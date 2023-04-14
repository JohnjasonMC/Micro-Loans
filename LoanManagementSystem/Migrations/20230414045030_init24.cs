using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagementSystem.Migrations
{
    public partial class init24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a73053f-78c6-41c2-94fc-d897ccc8b33c",
                column: "ConcurrencyStamp",
                value: "da3deb3e-6f8c-454f-9136-38729c33cea4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "705c9705-c8a8-44af-99a3-e33b13856856",
                column: "ConcurrencyStamp",
                value: "33befcc1-931a-4d4f-aa19-f4557c998d5e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67be0e64-c90d-4e7a-b377-6574d88ec14d", new DateTime(2023, 4, 14, 12, 50, 30, 359, DateTimeKind.Local).AddTicks(9227), "AQAAAAEAACcQAAAAECz6WJCBEb6AqwHX7ETfEv8PFwZ1bXOaVvAUtWI/C1otTwTNwm+16BHTsEvKdzfKqw==", "1546486d-909e-4091-8d78-c0a121d15f36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cba87ff8-bb15-442f-8a47-0e65a93cab8c",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16699e66-6843-4abd-a9f6-2f97e3f9ed17", new DateTime(2023, 4, 14, 12, 50, 30, 361, DateTimeKind.Local).AddTicks(7941), "AQAAAAEAACcQAAAAECiJFHW7fT3LE7gXBXqmup4+uuFmae7963GSWJAT2TnNuPMsV14ZaPa0FARR1sQxBw==", "d13e9bb3-6d05-4a87-a283-f688a35f9968" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a73053f-78c6-41c2-94fc-d897ccc8b33c",
                column: "ConcurrencyStamp",
                value: "9e38319b-37ea-4951-b4d1-9ef613634640");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "705c9705-c8a8-44af-99a3-e33b13856856",
                column: "ConcurrencyStamp",
                value: "2b09716b-9537-4d1d-b8e4-3dfd60ce0fde");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8393b003-b5a9-40d3-9c81-6c2fb9827e5f", new DateTime(2023, 4, 13, 18, 53, 3, 790, DateTimeKind.Local).AddTicks(7488), "AQAAAAEAACcQAAAAEInMRT6D9S3VezE7p3xcz+GpU4cRg5QSCh7OVoHFGSrdqi9HRO6yGmZI9O9ep6FaEg==", "0975968a-740e-4759-8fb2-7a0f3c5548f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cba87ff8-bb15-442f-8a47-0e65a93cab8c",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f27e253f-eb68-496d-af48-45083ccb6e16", new DateTime(2023, 4, 13, 18, 53, 3, 794, DateTimeKind.Local).AddTicks(3092), "AQAAAAEAACcQAAAAENPlapEj7D/PJyPnekidtA4jPrkb4SPXIw3ejRqVmEDPzld+w0LKgAUc2bgHXbSlnQ==", "6bc9e80f-9cbc-4613-ba79-ba414ab72d49" });
        }
    }
}
