using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupleNet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityBrands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Valorations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Sales",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SaleDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ProductCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ItemCarts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Galleries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cd82a514-cbda-4e3e-a9ce-e0545898d0ba"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5ed4327-3476-421b-aa66-feb06726f830", "AQAAAAIAAYagAAAAEDYQ7JasX1swRx8fHUVQN14e9OceaHgNmLEwOTZu0Hx7SKkvUbV2r/lJWgzx3WJUJg==", "f58c4255-8f22-4a0c-a023-6aabe66c38a6" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Galleries");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Valorations",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sales",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SaleDetails",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductCategories",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ItemCarts",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Galleries",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "ID");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cd82a514-cbda-4e3e-a9ce-e0545898d0ba"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02f0ff76-49b6-4111-8c48-69f271f2d5e7", "AQAAAAIAAYagAAAAEOtcsnZSlLu9c4i897KP60JHgsMZgXQDKuU741sQzaVPcZfVYcA/gaZiz+GV42sG2w==", "4e1e2b52-697d-42c8-8caf-76e5fed53a0a" });
        }
    }
}
