using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_cw13.Migrations
{
    public partial class SweetShopMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confectionary",
                columns: table => new
                {
                    IdConfectionary = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    PricePerIte = table.Column<float>(nullable: false),
                    Type = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionary", x => x.IdConfectionary);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    IdClient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAccepted = table.Column<DateTime>(nullable: false),
                    DateFinished = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: true),
                    IdClient = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Customer",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Confectionary_Order",
                columns: table => new
                {
                    IdConfection = table.Column<int>(nullable: false),
                    IdOrder = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionary_Order", x => new { x.IdConfection, x.IdOrder });
                    table.ForeignKey(
                        name: "FK_Confectionary_Order_Confectionary_IdConfection",
                        column: x => x.IdConfection,
                        principalTable: "Confectionary",
                        principalColumn: "IdConfectionary",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confectionary_Order_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Confectionary",
                columns: new[] { "IdConfectionary", "Name", "PricePerIte", "Type" },
                values: new object[,]
                {
                    { 1, "Chocolate", 100f, "food" },
                    { 2, "Makowiec", 200f, "ciasto" },
                    { 3, "baklawa", 150f, "food" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "IdClient", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Andrzej", "Kowalski" },
                    { 2, "Jan", "Nowak" },
                    { 3, "Ola", "Gruszewska" },
                    { 4, "Jan", "Kazimierz" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "IdEmployee", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Ala", "Kotowska" },
                    { 2, "Dogumil", "Januszewski" },
                    { 3, "Julian", "Gruszka" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "IdOrder", "DateAccepted", "DateFinished", "IdClient", "IdEmployee", "Notes" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, "Wszystko ok" },
                    { 3, new DateTime(1998, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Fajny personel!" },
                    { 2, new DateTime(1998, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, "Wszystko ok" },
                    { 4, new DateTime(1998, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, "Nie smakowalo :(" }
                });

            migrationBuilder.InsertData(
                table: "Confectionary_Order",
                columns: new[] { "IdConfection", "IdOrder", "Notes", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Bardzo dobre slodycze", 2 },
                    { 2, 1, "Bardzo dobre", 4 },
                    { 3, 3, "Bardzo dobre", 14 },
                    { 2, 3, "Bardzo dobre", 25 },
                    { 3, 2, "Smakowalo", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confectionary_Order_IdOrder",
                table: "Confectionary_Order",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdClient",
                table: "Orders",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdEmployee",
                table: "Orders",
                column: "IdEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionary_Order");

            migrationBuilder.DropTable(
                name: "Confectionary");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
