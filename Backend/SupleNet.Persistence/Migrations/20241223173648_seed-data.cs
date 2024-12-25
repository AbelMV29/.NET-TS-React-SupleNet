using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupleNet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SaleId",
                table: "SaleDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("c38c5327-2355-4199-8648-bf6f09097827"), null, "Customer", "Customer" },
                    { new Guid("eea8d50f-bb2f-4ca4-a136-6b399b5856b8"), null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("cd82a514-cbda-4e3e-a9ce-e0545898d0ba"), 0, "02f0ff76-49b6-4111-8c48-69f271f2d5e7", "admin@mail.com", true, "User", false, null, "Admin", "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEOtcsnZSlLu9c4i897KP60JHgsMZgXQDKuU741sQzaVPcZfVYcA/gaZiz+GV42sG2w==", "+549111234123", false, "4e1e2b52-697d-42c8-8caf-76e5fed53a0a", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("eea8d50f-bb2f-4ca4-a136-6b399b5856b8"), new Guid("cd82a514-cbda-4e3e-a9ce-e0545898d0ba") });

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_SaleId",
                table: "SaleDetails",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Sales_SaleId",
                table: "SaleDetails",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Sales_SaleId",
                table: "SaleDetails");

            migrationBuilder.DropIndex(
                name: "IX_SaleDetails_SaleId",
                table: "SaleDetails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c38c5327-2355-4199-8648-bf6f09097827"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("eea8d50f-bb2f-4ca4-a136-6b399b5856b8"), new Guid("cd82a514-cbda-4e3e-a9ce-e0545898d0ba") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eea8d50f-bb2f-4ca4-a136-6b399b5856b8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cd82a514-cbda-4e3e-a9ce-e0545898d0ba"));

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "SaleDetails");
        }
    }
}
