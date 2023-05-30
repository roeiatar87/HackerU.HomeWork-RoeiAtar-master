using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demos.HackerU.HomeWork.Migrations.Managing
{
    /// <inheritdoc />
    public partial class HW19Q2_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeManager",
                columns: table => new
                {
                    employeesListId = table.Column<int>(type: "int", nullable: false),
                    managerssId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeManager", x => new { x.employeesListId, x.managerssId });
                    table.ForeignKey(
                        name: "FK_EmployeeManager_employees_employeesListId",
                        column: x => x.employeesListId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeManager_managers_managerssId",
                        column: x => x.managerssId,
                        principalTable: "managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeManager_managerssId",
                table: "EmployeeManager",
                column: "managerssId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeManager");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "managers");
        }
    }
}
