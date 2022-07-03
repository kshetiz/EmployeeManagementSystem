using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementSystem.Migrations
{
    public partial class Alter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Peoples_PeoplePersonId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionsPostionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PeoplePersonId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionsPostionId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PositionsPostionId",
                table: "Employees",
                newName: "PositionId");

            migrationBuilder.RenameColumn(
                name: "PeoplePersonId",
                table: "Employees",
                newName: "PersonId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesEmployeeId",
                table: "Positions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_EmployeesEmployeeId",
                table: "Positions",
                column: "EmployeesEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonId",
                table: "Employees",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Peoples_PersonId",
                table: "Employees",
                column: "PersonId",
                principalTable: "Peoples",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Employees_EmployeesEmployeeId",
                table: "Positions",
                column: "EmployeesEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Peoples_PersonId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Employees_EmployeesEmployeeId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_EmployeesEmployeeId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PersonId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeesEmployeeId",
                table: "Positions");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "Employees",
                newName: "PositionsPostionId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Employees",
                newName: "PeoplePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PeoplePersonId",
                table: "Employees",
                column: "PeoplePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionsPostionId",
                table: "Employees",
                column: "PositionsPostionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Peoples_PeoplePersonId",
                table: "Employees",
                column: "PeoplePersonId",
                principalTable: "Peoples",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionsPostionId",
                table: "Employees",
                column: "PositionsPostionId",
                principalTable: "Positions",
                principalColumn: "PostionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
