using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_API.Migrations
{
    /// <inheritdoc />
    public partial class Db4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SUPERIOR_EMP_ID",
                table: "EMPLOYEE",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DEPT_ID",
                table: "EMPLOYEE",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ASSIGNED_BRANCH_ID",
                table: "EMPLOYEE",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ASSIGNED_BRANCH_ID",
                table: "EMPLOYEE");

            migrationBuilder.AlterColumn<int>(
                name: "SUPERIOR_EMP_ID",
                table: "EMPLOYEE",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DEPT_ID",
                table: "EMPLOYEE",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
