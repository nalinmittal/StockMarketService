using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class CreateCompanyContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sectorname = table.Column<string>(nullable: true),
                    Brief = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
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
                        name: "FK_company_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockExchange",
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
                    table.PrimaryKey("PK_StockExchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockExchange_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_company_SectorId",
                table: "company",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_StockExchange_CompanyId",
                table: "StockExchange",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockExchange");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "Sector");
        }
    }
}
