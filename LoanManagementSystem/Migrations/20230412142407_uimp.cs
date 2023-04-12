using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagementSystem.Migrations
{
    public partial class uimp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a73053f-78c6-41c2-94fc-d897ccc8b33c",
                column: "ConcurrencyStamp",
                value: "a79f6aaa-22af-415e-81ed-c9944a3d3b26");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "705c9705-c8a8-44af-99a3-e33b13856856",
                column: "ConcurrencyStamp",
                value: "c1927477-853b-4e97-8b15-8d6a41b59b35");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "975cd182-ceaf-4a7b-8a64-3547abe83b25", new DateTime(2023, 4, 12, 22, 24, 7, 388, DateTimeKind.Local).AddTicks(683), "AQAAAAEAACcQAAAAEPvNSsAm97KMQGBG75Nwlr1RMvf/9s3nch91MA8OVOAimFLj4/SixIyJ6L75DTIxRA==", "d5ef9ff6-f7a2-4fb2-b7cc-5067ddb4a956" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cba87ff8-bb15-442f-8a47-0e65a93cab8c",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6399c49d-5856-4b50-9f1f-acefbeb70cb2", new DateTime(2023, 4, 12, 22, 24, 7, 389, DateTimeKind.Local).AddTicks(4932), "AQAAAAEAACcQAAAAEAGpxNZJe53H50efv2jVtHNtLOQ0eV8iYARrcrrgcQjmtFrWaylGrt2QCjVcVhhVVA==", "e2d7652e-3c5c-49b6-ad0e-8db9937bdfdd" });

            migrationBuilder.UpdateData(
                table: "imps",
                keyColumn: "Id",
                keyValue: 2,
                column: "Interest",
                value: 6.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a73053f-78c6-41c2-94fc-d897ccc8b33c",
                column: "ConcurrencyStamp",
                value: "9f758d25-7d0d-4d83-88ab-fe4156177420");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "705c9705-c8a8-44af-99a3-e33b13856856",
                column: "ConcurrencyStamp",
                value: "523ca93d-4981-4928-aaa8-f747693424cd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11373498-e7dc-4b67-903f-2c5a180d57c7", new DateTime(2023, 4, 9, 15, 31, 25, 290, DateTimeKind.Local).AddTicks(4624), "AQAAAAEAACcQAAAAEEGCWTZ7sNaic00JkkTehrnBo0g+YyrD7XPwovxQHzdMeyg1jNVzxGi2Aij42FdSzg==", "afd3f2a0-9c2f-475c-adbb-a95d3dc8ee8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cba87ff8-bb15-442f-8a47-0e65a93cab8c",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55c81825-a9c7-448a-b604-cde02cd557ce", new DateTime(2023, 4, 9, 15, 31, 25, 291, DateTimeKind.Local).AddTicks(8737), "AQAAAAEAACcQAAAAEBtuvMKAQmJ+1UFmxOXKcf6IennPgol4EmnYaQnZOAQd7QhVpzCwivrjvcFkejNnRg==", "845eb157-4352-4777-b724-ebfdf867d86f" });

            migrationBuilder.UpdateData(
                table: "imps",
                keyColumn: "Id",
                keyValue: 2,
                column: "Interest",
                value: 1.0);
        }
    }
}
