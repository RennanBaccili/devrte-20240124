using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Gestão_de_Colaboradores.Migrations
{
    public partial class AddEmployeeUserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_tab_Units_tab_UnitId",
                table: "Employees_tab");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_tab_Users_tab_UserId",
                table: "Employees_tab");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_tab_Units_tab_UnitId",
                table: "Employees_tab",
                column: "UnitId",
                principalTable: "Units_tab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_tab_Users_tab_UserId",
                table: "Employees_tab",
                column: "UserId",
                principalTable: "Users_tab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_tab_Units_tab_UnitId",
                table: "Employees_tab");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_tab_Users_tab_UserId",
                table: "Employees_tab");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_tab_Units_tab_UnitId",
                table: "Employees_tab",
                column: "UnitId",
                principalTable: "Units_tab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_tab_Users_tab_UserId",
                table: "Employees_tab",
                column: "UserId",
                principalTable: "Users_tab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
