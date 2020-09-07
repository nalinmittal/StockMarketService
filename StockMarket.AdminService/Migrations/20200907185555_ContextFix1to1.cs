using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.AdminService.Migrations
{
    public partial class ContextFix1to1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ipos_CompanyStockExchanges_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeId",
                table: "Ipos");

            migrationBuilder.DropIndex(
                name: "IX_Ipos_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeId",
                table: "Ipos");

            migrationBuilder.DropColumn(
                name: "CompanyStockExchangeCompanyId",
                table: "Ipos");

            migrationBuilder.DropColumn(
                name: "CompanyStockExchangeStockExchangeId",
                table: "Ipos");

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "Ipos",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "StockExchangeId",
                table: "Ipos",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Ipos");

            migrationBuilder.DropColumn(
                name: "StockExchangeId",
                table: "Ipos");

            migrationBuilder.AddColumn<long>(
                name: "CompanyStockExchangeCompanyId",
                table: "Ipos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CompanyStockExchangeStockExchangeId",
                table: "Ipos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ipos_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeId",
                table: "Ipos",
                columns: new[] { "CompanyStockExchangeCompanyId", "CompanyStockExchangeStockExchangeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ipos_CompanyStockExchanges_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeId",
                table: "Ipos",
                columns: new[] { "CompanyStockExchangeCompanyId", "CompanyStockExchangeStockExchangeId" },
                principalTable: "CompanyStockExchanges",
                principalColumns: new[] { "CompanyId", "StockExchangeId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
