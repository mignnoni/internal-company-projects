using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIdCompanyToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Idle",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdCompany",
                table: "AspNetUsers",
                column: "IdCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_user_company",
                table: "AspNetUsers",
                column: "IdCompany",
                principalTable: "company",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_company",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdCompany",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Idle",
                table: "AspNetUsers");
        }
    }
}
