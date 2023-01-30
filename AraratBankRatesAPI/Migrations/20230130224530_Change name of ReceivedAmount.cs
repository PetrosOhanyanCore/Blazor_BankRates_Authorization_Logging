using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraratBankRatesAPI.Migrations
{
    public partial class ChangenameofReceivedAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceivenAmount",
                table: "Transactions",
                newName: "ReceivedAmount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceivedAmount",
                table: "Transactions",
                newName: "ReceivenAmount");
        }
    }
}
