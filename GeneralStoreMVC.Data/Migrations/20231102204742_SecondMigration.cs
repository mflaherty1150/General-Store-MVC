using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneralStoreMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1001,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 2, 16, 47, 42, 484, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1002,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 2, 16, 47, 42, 484, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1003,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 2, 16, 47, 42, 484, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1004,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 2, 16, 47, 42, 484, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1005,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 2, 16, 47, 42, 484, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1006,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 2, 16, 47, 42, 484, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1007,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 2, 16, 47, 42, 484, DateTimeKind.Local).AddTicks(8990));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1001,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 1, 17, 13, 12, 706, DateTimeKind.Local).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1002,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 1, 17, 13, 12, 706, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1003,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 1, 17, 13, 12, 706, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1004,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 1, 17, 13, 12, 706, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1005,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 1, 17, 13, 12, 706, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1006,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 1, 17, 13, 12, 706, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1007,
                column: "DateOfTransaction",
                value: new DateTime(2023, 11, 1, 17, 13, 12, 706, DateTimeKind.Local).AddTicks(2270));
        }
    }
}
