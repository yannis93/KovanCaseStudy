using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovanCaseStudy.Infrastructure.EfCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    TotalBooking = table.Column<int>(type: "int", nullable: false),
                    Lat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lon = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { "1", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Bike" });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Scooter" });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "IsDisabled", "IsReserved", "Lat", "Lon", "TotalBooking", "VehicleTypeId" },
                values: new object[,]
                {
                    { "2NP1R", false, false, 39.9244125486328m, 32.8643810105882m, 5, 1 },
                    { "FBGXO", false, false, 39.9244125486328m, 32.8643810105882m, 5, 1 },
                    { "FV2FO", false, false, 39.9244125486328m, 32.8643810105882m, 5, 2 },
                    { "INZPG", false, false, 39.9244125486328m, 32.8643810105882m, 5, 1 },
                    { "LT3RT", false, false, 39.9244125486328m, 32.8643810105882m, 5, 1 },
                    { "OS7VA", true, true, 39.9244125486328m, 32.8643810105882m, 8, 1 },
                    { "Q2RLQ", false, false, 39.9244125486328m, 32.8643810105882m, 5, 2 },
                    { "T2ZX9", false, false, 39.9244125486328m, 32.8643810105882m, 5, 2 },
                    { "WZKOU", false, false, 39.9244125486328m, 32.8643810105882m, 5, 1 },
                    { "Z2LBF", false, false, 39.9244125486328m, 32.8643810105882m, 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
