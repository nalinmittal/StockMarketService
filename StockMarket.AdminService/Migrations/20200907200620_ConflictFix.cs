using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.AdminService.Migrations
{
    public partial class ConflictFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_company_Sector_SectorId",
                table: "company");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyStockExchanges_StockExchanges_StockExchangeId",
                table: "CompanyStockExchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_CompanyStockExchanges_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeId",
                table: "StockPrices");

            migrationBuilder.DropIndex(
                name: "IX_StockPrices_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeId",
                table: "StockPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockExchanges",
                table: "StockExchanges");

            migrationBuilder.DropIndex(
                name: "IX_company_SectorId",
                table: "company");

            migrationBuilder.DropColumn(
                name: "CompanyStockExchangeCompanyId",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "CompanyStockExchangeStockExchangeId",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StockExchanges");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "company");

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "StockPrices",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "StockExchangeId",
                table: "StockPrices",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Stockexchange",
                table: "StockExchanges",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Boardofdirectors",
                table: "company",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "company",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockExchanges",
                table: "StockExchanges",
                column: "Stockexchange");

            migrationBuilder.CreateIndex(
                name: "IX_company_Company",
                table: "company",
                column: "Company");

            migrationBuilder.AddForeignKey(
                name: "FK_company_Sector_Company",
                table: "company",
                column: "Company",
                principalTable: "Sector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyStockExchanges_StockExchanges_StockExchangeId",
                table: "CompanyStockExchanges",
                column: "StockExchangeId",
                principalTable: "StockExchanges",
                principalColumn: "Stockexchange",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_company_Sector_Company",
                table: "company");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyStockExchanges_StockExchanges_StockExchangeId",
                table: "CompanyStockExchanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockExchanges",
                table: "StockExchanges");

            migrationBuilder.DropIndex(
                name: "IX_company_Company",
                table: "company");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "StockExchangeId",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "company");

            migrationBuilder.AddColumn<long>(
                name: "CompanyStockExchangeCompanyId",
                table: "StockPrices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CompanyStockExchangeStockExchangeId",
                table: "StockPrices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Stockexchange",
                table: "StockExchanges",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "StockExchanges",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Boardofdirectors",
                table: "company",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "company",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockExchanges",
                table: "StockExchanges",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeId",
                table: "StockPrices",
                columns: new[] { "CompanyStockExchangeCompanyId", "CompanyStockExchangeStockExchangeId" });

            migrationBuilder.CreateIndex(
                name: "IX_company_SectorId",
                table: "company",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_company_Sector_SectorId",
                table: "company",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyStockExchanges_StockExchanges_StockExchangeId",
                table: "CompanyStockExchanges",
                column: "StockExchangeId",
                principalTable: "StockExchanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_CompanyStockExchanges_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeId",
                table: "StockPrices",
                columns: new[] { "CompanyStockExchangeCompanyId", "CompanyStockExchangeStockExchangeId" },
                principalTable: "CompanyStockExchanges",
                principalColumns: new[] { "CompanyId", "StockExchangeId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
