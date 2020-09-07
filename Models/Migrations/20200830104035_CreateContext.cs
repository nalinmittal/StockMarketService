using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class CreateContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sectorname = table.Column<string>(nullable: true),
                    Brief = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Usertype = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobilenumber = table.Column<long>(nullable: false),
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
                    Ceo = table.Column<string>(nullable: true),
                    Boardofdirectors = table.Column<string>(nullable: true),
                    SectorId = table.Column<int>(nullable: true),
                    Brief = table.Column<string>(nullable: true),
                    Stockcodes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_company_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockExchanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stockexchange = table.Column<string>(nullable: false),
                    Brief = table.Column<string>(nullable: true),
                    Contactaddress = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockExchanges_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ipos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(nullable: false),
                    StockexchangeId = table.Column<long>(nullable: true),
                    Pricepershare = table.Column<float>(nullable: false),
                    Totalnumberofshares = table.Column<int>(nullable: false),
                    Opendatetime = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ipos_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ipos_StockExchanges_StockexchangeId",
                        column: x => x.StockexchangeId,
                        principalTable: "StockExchanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stockprices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(nullable: false),
                    StockexchangeId = table.Column<long>(nullable: true),
                    Currentprice = table.Column<float>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stockprices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stockprices_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stockprices_StockExchanges_StockexchangeId",
                        column: x => x.StockexchangeId,
                        principalTable: "StockExchanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_company_SectorId",
                table: "company",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipos_CompanyId",
                table: "Ipos",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipos_StockexchangeId",
                table: "Ipos",
                column: "StockexchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockExchanges_CompanyId",
                table: "StockExchanges",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Stockprices_CompanyId",
                table: "Stockprices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Stockprices_StockexchangeId",
                table: "Stockprices",
                column: "StockexchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ipos");

            migrationBuilder.DropTable(
                name: "Stockprices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "StockExchanges");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "Sectors");
        }
    }
}
