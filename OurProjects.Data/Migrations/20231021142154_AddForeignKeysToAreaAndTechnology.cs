using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeysToAreaAndTechnology : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "idCompany",
                table: "technology",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "idCompany",
                table: "area",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_technology_idCompany",
                table: "technology",
                column: "idCompany");

            migrationBuilder.CreateIndex(
                name: "IX_area_idCompany",
                table: "area",
                column: "idCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_area_company",
                table: "area",
                column: "idCompany",
                principalTable: "company",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_technology_company",
                table: "technology",
                column: "idCompany",
                principalTable: "company",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_area_company",
                table: "area");

            migrationBuilder.DropForeignKey(
                name: "FK_technology_company",
                table: "technology");

            migrationBuilder.DropIndex(
                name: "IX_technology_idCompany",
                table: "technology");

            migrationBuilder.DropIndex(
                name: "IX_area_idCompany",
                table: "area");

            migrationBuilder.DropColumn(
                name: "idCompany",
                table: "technology");

            migrationBuilder.DropColumn(
                name: "idCompany",
                table: "area");
        }
    }
}
