using Microsoft.EntityFrameworkCore.Migrations;

namespace coreData.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interns",
                columns: table => new
                {
                    InternID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternNameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternDateofBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternGender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interns", x => x.InternID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjecytStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectEndDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberofStaff = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitID);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PersonelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelNameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    UnitID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelID);
                    table.ForeignKey(
                        name: "FK_Personels_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personels_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "UnitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternPersonel",
                columns: table => new
                {
                    InternsInternID = table.Column<int>(type: "int", nullable: false),
                    PersonelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternPersonel", x => new { x.InternsInternID, x.PersonelID });
                    table.ForeignKey(
                        name: "FK_InternPersonel_Interns_InternsInternID",
                        column: x => x.InternsInternID,
                        principalTable: "Interns",
                        principalColumn: "InternID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternPersonel_Personels_PersonelID",
                        column: x => x.PersonelID,
                        principalTable: "Personels",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonelProject",
                columns: table => new
                {
                    PersonelsPersonelID = table.Column<int>(type: "int", nullable: false),
                    ProjectsProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelProject", x => new { x.PersonelsPersonelID, x.ProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_PersonelProject_Personels_PersonelsPersonelID",
                        column: x => x.PersonelsPersonelID,
                        principalTable: "Personels",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelProject_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternPersonel_PersonelID",
                table: "InternPersonel",
                column: "PersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelProject_ProjectsProjectId",
                table: "PersonelProject",
                column: "ProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_RoleID",
                table: "Personels",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_UnitID",
                table: "Personels",
                column: "UnitID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternPersonel");

            migrationBuilder.DropTable(
                name: "PersonelProject");

            migrationBuilder.DropTable(
                name: "Interns");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
