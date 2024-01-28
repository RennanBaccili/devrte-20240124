using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sistema_de_Gestão_de_Colaboradores.Migrations
{
    public partial class UnitEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units_tab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnitCode = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units_tab", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees_tab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees_tab", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_tab_Units_tab_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units_tab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_tab_Users_tab_UserId",
                        column: x => x.UserId,
                        principalTable: "Users_tab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_tab_UnitId",
                table: "Employees_tab",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_tab_UserId",
                table: "Employees_tab",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_tab_UnitCode",
                table: "Units_tab",
                column: "UnitCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees_tab");

            migrationBuilder.DropTable(
                name: "Units_tab");
        }
    }
}
