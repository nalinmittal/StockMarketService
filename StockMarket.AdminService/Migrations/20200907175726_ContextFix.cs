using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.AdminService.Migrations
{
    public partial class ContextFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sectorname = table.Column<string>(nullable: false),
                    Brief = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockExchanges",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Stockexchange = table.Column<string>(nullable: false),
                    Brief = table.Column<string>(nullable: false),
                    Contactaddress = table.Column<string>(nullable: false),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Companyname = table.Column<string>(nullable: false),
                    Turnover = table.Column<float>(nullable: false),
                    Ceo = table.Column<string>(nullable: false),
                    Boardofdirectors = table.Column<string>(nullable: false),
                    SectorId = table.Column<int>(nullable: true),
                    Brief = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_company_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyStockExchanges",
                columns: table => new
                {
                    CompanyId = table.Column<long>(nullable: false),
                    StockExchangeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyStockExchanges", x => new { x.CompanyId, x.StockExchangeId });
                    table.ForeignKey(
                        name: "FK_CompanyStockExchanges_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyStockExchanges_StockExchanges_StockExchangeId",
                        column: x => x.StockExchangeId,
                        principalTable: "StockExchanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ipos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pricepershare = table.Column<float>(nullable: false),
                    Totalnumberofshares = table.Column<int>(nullable: false),
                    Opendatetime = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: false),
                    CompanyStockExchangeCompanyId = table.Column<long>(nullable: false),
                    CompanyStockExchangeStockExchangeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ipos_CompanyStockExchanges_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeId",
                        columns: x => new { x.CompanyStockExchangeCompanyId, x.CompanyStockExchangeStockExchangeId },
                        principalTable: "CompanyStockExchanges",
                        principalColumns: new[] { "CompanyId", "StockExchangeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockPrices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentPrice = table.Column<float>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Time = table.Column<string>(nullable: false),
                    CompanyStockExchangeCompanyId = table.Column<long>(nullable: false),
                    CompanyStockExchangeStockExchangeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockPrices_CompanyStockExchanges_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeId",
                        columns: x => new { x.CompanyStockExchangeCompanyId, x.CompanyStockExchangeStockExchangeId },
                        principalTable: "CompanyStockExchanges",
                        principalColumns: new[] { "CompanyId", "StockExchangeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_company_SectorId",
                table: "company",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyStockExchanges_StockExchangeId",
                table: "CompanyStockExchanges",
                column: "StockExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipos_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeId",
                table: "Ipos",
                columns: new[] { "CompanyStockExchangeCompanyId", "CompanyStockExchangeStockExchangeId" });

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeId",
                table: "StockPrices",
                columns: new[] { "CompanyStockExchangeCompanyId", "CompanyStockExchangeStockExchangeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ipos");

            migrationBuilder.DropTable(
                name: "StockPrices");

            migrationBuilder.DropTable(
                name: "CompanyStockExchanges");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "StockExchanges");

            migrationBuilder.DropTable(
                name: "Sector");
        }
    }
}
