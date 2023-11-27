using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencys",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StockClasss",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockClassName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockClasss", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StockTypes",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StockUnits",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockUnitCode = table.Column<long>(type: "bigint", nullable: false),
                    StockUnitName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StockTypeID = table.Column<long>(type: "bigint", nullable: false),
                    AmountUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PurchasePriceCurrencyID = table.Column<long>(type: "bigint", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    SalePriceCurrencyID = table.Column<long>(type: "bigint", nullable: false),
                    PaperWeight = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockUnits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StockUnits_StockTypes_StockTypeID",
                        column: x => x.StockTypeID,
                        principalTable: "StockTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockClassID = table.Column<long>(type: "bigint", nullable: false),
                    StockTypeID = table.Column<long>(type: "bigint", nullable: false),
                    StockUnitID = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShelfInformation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CriticalAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stocks_StockClasss_StockClassID",
                        column: x => x.StockClassID,
                        principalTable: "StockClasss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_StockTypes_StockTypeID",
                        column: x => x.StockTypeID,
                        principalTable: "StockTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_StockUnits_StockUnitID",
                        column: x => x.StockUnitID,
                        principalTable: "StockUnits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currencys_ID",
                table: "Currencys",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_StockClasss_ID",
                table: "StockClasss",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_StockClasss_StockClassName",
                table: "StockClasss",
                column: "StockClassName");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ID",
                table: "Stocks",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_RecordDate",
                table: "Stocks",
                column: "RecordDate");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockClassID",
                table: "Stocks",
                column: "StockClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockTypeID",
                table: "Stocks",
                column: "StockTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockUnitID",
                table: "Stocks",
                column: "StockUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_StockTypes_ID",
                table: "StockTypes",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_StockTypes_StockTypeName",
                table: "StockTypes",
                column: "StockTypeName");

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_ID",
                table: "StockUnits",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_StockTypeID",
                table: "StockUnits",
                column: "StockTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_StockUnitCode",
                table: "StockUnits",
                column: "StockUnitCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencys");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "StockClasss");

            migrationBuilder.DropTable(
                name: "StockUnits");

            migrationBuilder.DropTable(
                name: "StockTypes");
        }
    }
}
