using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOtherTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    idle = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "technology",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    idle = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technology", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    idArea = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    idLeader = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    idCompany = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    idle = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    title = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    show = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    showTeam = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    showLeader = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    endDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.id);
                    table.ForeignKey(
                        name: "FK_project_area",
                        column: x => x.idArea,
                        principalTable: "area",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_project_company",
                        column: x => x.idCompany,
                        principalTable: "company",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_project_userLeader",
                        column: x => x.idLeader,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projectTeamMember",
                columns: table => new
                {
                    idArea = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    idTeamMember = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectTeamMember", x => new { x.idArea, x.idTeamMember });
                    table.ForeignKey(
                        name: "FK_projectTeamMember_project",
                        column: x => x.idArea,
                        principalTable: "project",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_projectTeamMember_user",
                        column: x => x.idTeamMember,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projectTechnology",
                columns: table => new
                {
                    idProject = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    idCompany = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectTechnology", x => new { x.idProject, x.idCompany });
                    table.ForeignKey(
                        name: "FK_projectTechnology_project",
                        column: x => x.idProject,
                        principalTable: "project",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_projectTechnology_technology",
                        column: x => x.idCompany,
                        principalTable: "technology",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_project_idArea",
                table: "project",
                column: "idArea");

            migrationBuilder.CreateIndex(
                name: "IX_project_idCompany",
                table: "project",
                column: "idCompany");

            migrationBuilder.CreateIndex(
                name: "IX_project_idLeader",
                table: "project",
                column: "idLeader");

            migrationBuilder.CreateIndex(
                name: "IX_projectTeamMember_idTeamMember",
                table: "projectTeamMember",
                column: "idTeamMember");

            migrationBuilder.CreateIndex(
                name: "IX_projectTechnology_idCompany",
                table: "projectTechnology",
                column: "idCompany");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projectTeamMember");

            migrationBuilder.DropTable(
                name: "projectTechnology");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "technology");

            migrationBuilder.DropTable(
                name: "area");
        }
    }
}
