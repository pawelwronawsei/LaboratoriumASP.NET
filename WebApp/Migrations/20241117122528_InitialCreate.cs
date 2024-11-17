using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NIP = table.Column<string>(type: "TEXT", nullable: false),
                    REGON = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    birth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "Id", "Address_City", "Address_Street", "NIP", "Name", "REGON" },
                values: new object[,]
                {
                    { 101, "Kraków", "św. Filipa 17", "98348234", "WSEI", "12313548353" },
                    { 102, "Warszawa", "Dworcowa 8", "53563646", "PKP", "53155134835" }
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth", "Created", "Email", "FirstName", "LastName", "OrganizationId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateOnly(2000, 1, 5), new DateTime(2024, 11, 17, 13, 25, 28, 297, DateTimeKind.Local).AddTicks(3296), "adam.testowy@mail.com", "Adam", "Testowy", 101, "123456789" },
                    { 2, new DateOnly(1990, 7, 5), new DateTime(2024, 11, 17, 13, 25, 28, 297, DateTimeKind.Local).AddTicks(3338), "alan.nowak@mail.com", "Alan", "Nowak", 102, "222333444" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "organizations");
        }
    }
}
