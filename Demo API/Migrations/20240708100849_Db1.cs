using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_API.Migrations
{
    /// <inheritdoc />
    public partial class Db1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACC_TRANSACTION",
                columns: table => new
                {
                    TXN_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMOUNT = table.Column<float>(type: "real", nullable: false),
                    FUNDS_AVAIL_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TXN_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TXN_TYPE_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ACCOUNT_ID = table.Column<int>(type: "int", nullable: true),
                    EXCUTION_BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    TELLER_EMP_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_TRANSACTION", x => x.TXN_ID);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    ACCOUNT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AVAIL_BALANCE = table.Column<float>(type: "real", nullable: true),
                    CLOSE_DATE = table.Column<DateOnly>(type: "date", nullable: true),
                    LAST_ACTIVITY_DATE = table.Column<DateOnly>(type: "date", nullable: true),
                    OPEN_DATE = table.Column<DateOnly>(type: "date", nullable: false),
                    PENDING_BALANCE = table.Column<float>(type: "real", nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    OPEN_EMP_ID = table.Column<int>(type: "int", nullable: false),
                    OPEN_BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT", x => x.ACCOUNT_ID);
                });

            migrationBuilder.CreateTable(
                name: "BRANCH",
                columns: table => new
                {
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDRESS = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CITY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    STATE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ZIP_CODE = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCH", x => x.BRANCH_ID);
                });

            migrationBuilder.CreateTable(
                name: "BUSINESS",
                columns: table => new
                {
                    CUST_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INCORP_DATE = table.Column<DateOnly>(type: "date", nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    STATE_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUSINESS", x => x.CUST_ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    CUST_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDRESS = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CITY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CUST_TYPE_CD = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    FED_ID = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    POSTAL_CODE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    STATE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.CUST_ID);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    DEPT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENT", x => x.DEPT_ID);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    EMP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LAST_NAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    START_DAY = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DEPT_ID = table.Column<int>(type: "int", nullable: true),
                    SUPERIOR_EMP_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.EMP_ID);
                });

            migrationBuilder.CreateTable(
                name: "INDIVIDUAL",
                columns: table => new
                {
                    CUST_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BIRTH_DAY = table.Column<DateOnly>(type: "date", nullable: false),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LAST_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INDIVIDUAL", x => x.CUST_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    PRODUCT_CD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DATE_OFFERED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATE_RETIRED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.PRODUCT_CD);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_TYPE",
                columns: table => new
                {
                    PRODUCT_TYPE_CD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_TYPE", x => x.PRODUCT_TYPE_CD);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACC_TRANSACTION");

            migrationBuilder.DropTable(
                name: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "BRANCH");

            migrationBuilder.DropTable(
                name: "BUSINESS");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "INDIVIDUAL");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "PRODUCT_TYPE");
        }
    }
}
