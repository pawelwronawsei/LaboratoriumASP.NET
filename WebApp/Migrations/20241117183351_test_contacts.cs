using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class test_contacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 17, 19, 33, 51, 15, DateTimeKind.Local).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 17, 19, 33, 51, 15, DateTimeKind.Local).AddTicks(8859));

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth", "Created", "Email", "FirstName", "LastName", "OrganizationId", "PhoneNumber" },
                values: new object[] { 3, new DateOnly(1990, 7, 5), new DateTime(2024, 11, 17, 19, 33, 51, 15, DateTimeKind.Local).AddTicks(8862), "test.test@mail.com", "test", "test", 102, "555222333" });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "Id", "NIP", "Name", "REGON" },
                values: new object[] { 103, "124536363", "test", "1436548564474" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "organizations",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 17, 13, 25, 28, 297, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 17, 13, 25, 28, 297, DateTimeKind.Local).AddTicks(3338));
        }
    }
}
