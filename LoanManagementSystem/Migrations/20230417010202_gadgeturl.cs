using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagementSystem.Migrations
{
    public partial class gadgeturl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GadgetImageURL",
                table: "purchases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a73053f-78c6-41c2-94fc-d897ccc8b33c",
                column: "ConcurrencyStamp",
                value: "9d0c94ea-744e-4285-bfea-e8103d12106d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "705c9705-c8a8-44af-99a3-e33b13856856",
                column: "ConcurrencyStamp",
                value: "e81b11d2-cc9b-40ee-8e54-8b059083f07d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71ac3c4d-cdc9-4afe-ad37-44988bc3ab1d", new DateTime(2023, 4, 17, 9, 2, 2, 168, DateTimeKind.Local).AddTicks(9134), "AQAAAAEAACcQAAAAEDWgGOJQBuhevS6v+R4XuPQqD8V6c7PVtlbTykza2t6uDDHurLHUXRXqpN0vm5m1mw==", "ee87a79d-31fc-4515-bfa0-3954f6075dec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cba87ff8-bb15-442f-8a47-0e65a93cab8c",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f88554f-9e5e-4bbc-96fe-978b5f69b329", new DateTime(2023, 4, 17, 9, 2, 2, 170, DateTimeKind.Local).AddTicks(2838), "AQAAAAEAACcQAAAAEI8K7xVN/F2r8ok6cMDtBcLzcVB+cZ+YdUcXCjsIn8WgjveipvlEW0sP9+viB5ocpg==", "c263dd1c-23b1-4504-8e8c-6c4f29889135" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GadgetImageURL",
                table: "purchases");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a73053f-78c6-41c2-94fc-d897ccc8b33c",
                column: "ConcurrencyStamp",
                value: "890f3ead-f536-44ee-8a1c-4684a3eb8110");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "705c9705-c8a8-44af-99a3-e33b13856856",
                column: "ConcurrencyStamp",
                value: "d594e4be-ffdb-4f0d-9aab-abc740fb5677");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fa4a3dc-d802-49c3-a8b1-7499d08e1958", new DateTime(2023, 4, 16, 22, 5, 31, 896, DateTimeKind.Local).AddTicks(2726), "AQAAAAEAACcQAAAAEAbjJh/AfQsSK5WzE/nJd27MZ2sxoyQKWlqP5PM30vGNUPkbvOSPGqaKMNJQKOwcDQ==", "f0181337-5988-42d9-a1bb-3c9a56706c12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cba87ff8-bb15-442f-8a47-0e65a93cab8c",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2044a70-b011-4235-a556-fc1f252c1aee", new DateTime(2023, 4, 16, 22, 5, 31, 898, DateTimeKind.Local).AddTicks(1126), "AQAAAAEAACcQAAAAEKytiJMXB0zPZBTddttoEilX6dQ3W+q7T6TPkVoqr/lTpJ3/cFNIm5jAMCGbuAqPxg==", "21476e40-4149-408b-b652-a791242757dc" });
        }
    }
}
