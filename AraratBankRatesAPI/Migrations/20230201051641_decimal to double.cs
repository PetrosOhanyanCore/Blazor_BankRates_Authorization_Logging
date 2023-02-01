using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraratBankRatesAPI.Migrations
{
    public partial class decimaltodouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ReceivedAmount",
                table: "Transactions",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "GivenAmount",
                table: "Transactions",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "ExchangeRate",
                table: "Transactions",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ReceivedAmount",
                table: "Transactions",
                type: "double(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "GivenAmount",
                table: "Transactions",
                type: "double(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "ExchangeRate",
                table: "Transactions",
                type: "double(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
