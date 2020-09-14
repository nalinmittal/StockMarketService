using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.UserService.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CompanyId = table.Column<long>(nullable: false),
                    StockExchangeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sectorname = table.Column<string>(nullable: false),
                    Brief = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockExchanges",
                columns: table => new
                {
                    Stockexchange = table.Column<string>(nullable: false),
                    Brief = table.Column<string>(nullable: false),
                    Contactaddress = table.Column<string>(nullable: false),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchanges", x => x.Stockexchange);
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
                    CompanyId = table.Column<long>(nullable: false),
                    StockExchangeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Mobile = table.Column<long>(nullable: false),
                    Confirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    Boardofdirectors = table.Column<string>(nullable: true),
                    Company = table.Column<int>(nullable: true),
                    Brief = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_company_Sectors_Company",
                        column: x => x.Company,
                        principalTable: "Sectors",
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
                        principalColumn: "Stockexchange",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_company_Company",
                table: "company",
                column: "Company");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyStockExchanges_StockExchangeId",
                table: "CompanyStockExchanges",
                column: "StockExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyStockExchanges");

            migrationBuilder.DropTable(
                name: "Ipos");

            migrationBuilder.DropTable(
                name: "StockPrices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "StockExchanges");

            migrationBuilder.DropTable(
                name: "Sectors");
        }
    }
}
