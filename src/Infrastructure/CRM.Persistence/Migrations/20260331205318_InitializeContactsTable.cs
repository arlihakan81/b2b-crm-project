using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitializeContactsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AccountId",
                table: "Contacts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OrganizationId",
                table: "Contacts",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f80a744-cc29-4f8b-a9df-063a76117229"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("88b8be13-21aa-4103-8068-0c33fa809618"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5ea6472-6195-45f1-bce6-8dc77b184c34"));

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("d85582a3-104a-4885-b486-b07cf5e3b4b3"), new DateTime(2026, 3, 30, 22, 56, 14, 374, DateTimeKind.Local).AddTicks(2088), null, "Admin", null },
                    { new Guid("dd2875c1-aa32-4741-96ad-bbfd35f30b31"), new DateTime(2026, 3, 30, 22, 56, 14, 374, DateTimeKind.Local).AddTicks(2090), null, "User", null },
                    { new Guid("dea92ab5-2fba-40e1-80a8-67bce8c36ade"), new DateTime(2026, 3, 30, 22, 56, 14, 374, DateTimeKind.Local).AddTicks(2036), null, "Super Admin", null }
                });
        }
    }
}
