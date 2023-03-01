using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shared.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class CarModelsRemoveFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarBrands_CarBrandEntityId",
                schema: "public",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                schema: "public",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarBrandEntityId",
                schema: "public",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarModelId",
                schema: "public",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarBrandEntityId",
                schema: "public",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                schema: "public",
                table: "Cars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarBrandEntityId",
                schema: "public",
                table: "Cars",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CarModelId",
                schema: "public",
                table: "Cars",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBrandEntityId",
                schema: "public",
                table: "Cars",
                column: "CarBrandEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                schema: "public",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarBrands_CarBrandEntityId",
                schema: "public",
                table: "Cars",
                column: "CarBrandEntityId",
                principalSchema: "public",
                principalTable: "CarBrands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                schema: "public",
                table: "Cars",
                column: "CarModelId",
                principalSchema: "public",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
