using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demoEmp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "_Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Employees",
                table: "_Employees",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Employees",
                table: "_Employees");

            migrationBuilder.RenameTable(
                name: "_Employees",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");
        }
    }
}
