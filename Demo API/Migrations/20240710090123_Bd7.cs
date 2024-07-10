using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_API.Migrations
{
    /// <inheritdoc />
    public partial class Bd7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PRODUCT_TYPE_CD",
                table: "PRODUCT",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PRODUCT_TYPE_CD",
                table: "PRODUCT");
        }
    }
}
