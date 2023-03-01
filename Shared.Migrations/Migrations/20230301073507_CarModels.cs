using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shared.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class CarModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarModelId",
                schema: "public",
                table: "Cars",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Make",
                schema: "public",
                table: "Cars",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarModels",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Make = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateById = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                schema: "public",
                table: "Cars",
                column: "CarModelId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                schema: "public",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarModels",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarModelId",
                schema: "public",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                schema: "public",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Make",
                schema: "public",
                table: "Cars");
        }
    }
}
