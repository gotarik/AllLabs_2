using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllLabs_2.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalSystems",
                columns: table => new
                {
                    RentalSystemIdPK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalSystems", x => x.RentalSystemIdPK);
                });

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdministratorIdPK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalSystemIdFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrators_RentalSystems_RentalSystemIdFK",
                        column: x => x.RentalSystemIdFK,
                        principalTable: "RentalSystems",
                        principalColumn: "RentalSystemIdPK");
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarIdPK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalSystemIdFK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarIdPK);
                    table.ForeignKey(
                        name: "FK_Cars_RentalSystems_RentalSystemIdFK",
                        column: x => x.RentalSystemIdFK,
                        principalTable: "RentalSystems",
                        principalColumn: "RentalSystemIdPK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientIdPk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalSystemIdFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_RentalSystems_RentalSystemIdFK",
                        column: x => x.RentalSystemIdFK,
                        principalTable: "RentalSystems",
                        principalColumn: "RentalSystemIdPK");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderIdPK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentalPeriod = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DamageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientIdFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarIdFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentalSystemIdPK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderIdPK);
                    table.ForeignKey(
                        name: "FK_Orders_Cars_CarIdFK",
                        column: x => x.CarIdFK,
                        principalTable: "Cars",
                        principalColumn: "CarIdPK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientIdFK",
                        column: x => x.ClientIdFK,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_RentalSystems_RentalSystemIdPK",
                        column: x => x.RentalSystemIdPK,
                        principalTable: "RentalSystems",
                        principalColumn: "RentalSystemIdPK");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_RentalSystemIdFK",
                table: "Administrators",
                column: "RentalSystemIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RentalSystemIdFK",
                table: "Cars",
                column: "RentalSystemIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_RentalSystemIdFK",
                table: "Clients",
                column: "RentalSystemIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarIdFK",
                table: "Orders",
                column: "CarIdFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientIdFK",
                table: "Orders",
                column: "ClientIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RentalSystemIdPK",
                table: "Orders",
                column: "RentalSystemIdPK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "RentalSystems");
        }
    }
}
