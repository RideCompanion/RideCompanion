using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shared.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class CarBrands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Make",
                schema: "public",
                table: "Cars",
                newName: "Brand");

            migrationBuilder.RenameColumn(
                name: "Make",
                schema: "public",
                table: "CarModels",
                newName: "Brand");

            migrationBuilder.AddColumn<Guid>(
                name: "CarBrandEntityId",
                schema: "public",
                table: "Cars",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarBrands",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateById = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBrandEntityId",
                schema: "public",
                table: "Cars",
                column: "CarBrandEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarBrands_CarBrandEntityId",
                schema: "public",
                table: "Cars",
                column: "CarBrandEntityId",
                principalSchema: "public",
                principalTable: "CarBrands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarBrands_CarBrandEntityId",
                schema: "public",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarBrands",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarBrandEntityId",
                schema: "public",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarBrandEntityId",
                schema: "public",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Brand",
                schema: "public",
                table: "Cars",
                newName: "Make");

            migrationBuilder.RenameColumn(
                name: "Brand",
                schema: "public",
                table: "CarModels",
                newName: "Make");
        }
    }
}
