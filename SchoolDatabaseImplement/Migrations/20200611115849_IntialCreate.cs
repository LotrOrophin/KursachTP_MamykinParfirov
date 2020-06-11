using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDatabaseImplement.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Circles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CircleName = table.Column<string>(nullable: false),
                    PricePerHour = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolSupplieName = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSupplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierFIO = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Sum = table.Column<decimal>(nullable: false),
                    CompletionDate = table.Column<DateTime>(nullable: true),
                    OrderStatus = table.Column<int>(nullable: false),
                    CircleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CircleSchoolSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    SchoolSupplieId = table.Column<int>(nullable: false),
                    CircleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircleSchoolSupplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CircleSchoolSupplies_Circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CircleSchoolSupplies_SchoolSupplies_SchoolSupplieId",
                        column: x => x.SchoolSupplieId,
                        principalTable: "SchoolSupplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompletionDate = table.Column<DateTime>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Sum = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WareHouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHouseName = table.Column<string>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    SupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WareHouses_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestsSchoolSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(nullable: false),
                    SchoolSupplieId = table.Column<int>(nullable: false),
                    Inres = table.Column<bool>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    CircleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsSchoolSupplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestsSchoolSupplies_Circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestsSchoolSupplies_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestsSchoolSupplies_SchoolSupplies_SchoolSupplieId",
                        column: x => x.SchoolSupplieId,
                        principalTable: "SchoolSupplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WareHouseSchoolSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHouseId = table.Column<int>(nullable: false),
                    SchoolSupplieId = table.Column<int>(nullable: false),
                    Free = table.Column<int>(nullable: false),
                    IsReserved = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouseSchoolSupplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WareHouseSchoolSupplies_SchoolSupplies_SchoolSupplieId",
                        column: x => x.SchoolSupplieId,
                        principalTable: "SchoolSupplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WareHouseSchoolSupplies_WareHouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CircleSchoolSupplies_CircleId",
                table: "CircleSchoolSupplies",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_CircleSchoolSupplies_SchoolSupplieId",
                table: "CircleSchoolSupplies",
                column: "SchoolSupplieId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CircleId",
                table: "Orders",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SupplierId",
                table: "Requests",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsSchoolSupplies_CircleId",
                table: "RequestsSchoolSupplies",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsSchoolSupplies_RequestId",
                table: "RequestsSchoolSupplies",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsSchoolSupplies_SchoolSupplieId",
                table: "RequestsSchoolSupplies",
                column: "SchoolSupplieId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouses_SupplierId",
                table: "WareHouses",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouseSchoolSupplies_SchoolSupplieId",
                table: "WareHouseSchoolSupplies",
                column: "SchoolSupplieId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouseSchoolSupplies_WareHouseId",
                table: "WareHouseSchoolSupplies",
                column: "WareHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CircleSchoolSupplies");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RequestsSchoolSupplies");

            migrationBuilder.DropTable(
                name: "WareHouseSchoolSupplies");

            migrationBuilder.DropTable(
                name: "Circles");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "SchoolSupplies");

            migrationBuilder.DropTable(
                name: "WareHouses");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
