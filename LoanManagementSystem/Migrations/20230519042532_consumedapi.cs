using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagementSystem.Migrations
{
    public partial class consumedapi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a73053f-78c6-41c2-94fc-d897ccc8b33c",
                column: "ConcurrencyStamp",
                value: "41a85081-0849-4851-a89c-2be078e70c73");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "705c9705-c8a8-44af-99a3-e33b13856856",
                column: "ConcurrencyStamp",
                value: "f122c3ce-2698-4500-8f1a-e3e5fff0d515");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a12711ce-51a9-4066-9981-4d747c4ba553", new DateTime(2023, 5, 19, 12, 25, 32, 169, DateTimeKind.Local).AddTicks(9061), "AQAAAAEAACcQAAAAEFuOmrkZxMwTJJ7wkRORc5V5owsyXf9Abyrdz1A2nXE/CH9v7qg4sULm+2tfM0mHpQ==", "c60e82e0-0cde-4f8a-85d9-b8e8e271a9f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cba87ff8-bb15-442f-8a47-0e65a93cab8c",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25c4e91d-fbdf-4480-b51f-e78d60bd2008", new DateTime(2023, 5, 19, 12, 25, 32, 171, DateTimeKind.Local).AddTicks(2094), "AQAAAAEAACcQAAAAEOQ3lCKp6yr3rD2ZtHADfEeVZ4qf3NvtlX76lT6zQFCKJQY2zea2SramyewZ0bN3eA==", "b8328802-9f12-4538-81f1-79fb746e95da" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a73053f-78c6-41c2-94fc-d897ccc8b33c",
                column: "ConcurrencyStamp",
                value: "0eaac597-2742-44fb-9686-8479d70998c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "705c9705-c8a8-44af-99a3-e33b13856856",
                column: "ConcurrencyStamp",
                value: "2b3f1462-1572-4b05-9715-35b9022e84d3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f082d249-e4cb-4672-8352-876eded1586b", new DateTime(2023, 5, 18, 16, 29, 47, 469, DateTimeKind.Local).AddTicks(1804), "AQAAAAEAACcQAAAAEObeuL0wfZRSvAU8F4nsfd8b4Gfz9NM+11Gx4LZI62MOGxC5S458lykaAv2DMDUMMQ==", "83dc6f10-c079-48f5-a392-e6157c63afc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cba87ff8-bb15-442f-8a47-0e65a93cab8c",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "baa733d4-5a0b-4da2-b6cd-cea55d182b44", new DateTime(2023, 5, 18, 16, 29, 47, 470, DateTimeKind.Local).AddTicks(3528), "AQAAAAEAACcQAAAAEPxEy8ckL4fYq+v4Wf6JDS6vwsV2r997v6G36Weoy+wJPIHMwkZRCcJjcX+pgsGspg==", "62b09795-df7e-468f-b8e5-cb905dc9aa36" });
        }
    }
}
