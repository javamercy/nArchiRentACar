using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fuels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransmissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_Fuels_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Fuels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_Transmissions_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kilometer = table.Column<int>(type: "int", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinFindexScore = table.Column<int>(type: "int", nullable: false),
                    CarState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1caa83b0-b32c-4e94-8e12-03b19fe584bf"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8060), null, "Mercedes", null },
                    { new Guid("20dd0a38-b7fb-4dc1-aa1e-957854a10ad5"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8090), null, "Peugeot", null },
                    { new Guid("32495789-b924-4c2b-8d1f-5a5a7d9b8873"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8080), null, "Renault", null },
                    { new Guid("47f065d2-d009-40fa-a096-bde4b754aee2"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8090), null, "Skoda", null },
                    { new Guid("5929393a-5518-4097-95f7-2b36c3852ba9"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8080), null, "Opel", null },
                    { new Guid("96c517b6-dfac-4eb6-b29e-5c9c7b875bb2"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8090), null, "Fiat", null },
                    { new Guid("a358155a-234c-4525-b33c-de1ea21c1469"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8060), null, "BMW", null },
                    { new Guid("c5450178-921a-46c6-b236-b0e4787604e6"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8060), null, "Volkswagen", null },
                    { new Guid("c62c12fe-5b4b-436f-b2cc-3a8ce337c054"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8060), null, "Ford", null },
                    { new Guid("fa9c7d42-b6cf-43d5-9651-e8c2266e30fa"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8050), null, "Audi", null }
                });

            migrationBuilder.InsertData(
                table: "Fuels",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4e6e6f6b-2d6f-4e6e-6f6b-2d6f4e6e6f6b"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(7940), null, "Electric", null },
                    { new Guid("5fa1c428-304a-4016-9ab2-99560626e1ce"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(7940), null, "LPG", null },
                    { new Guid("7e57d004-2b97-0e7a-b45f-5387362902d2"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(7940), null, "Diesel", null },
                    { new Guid("9f39e21d-2df4-4b5b-abc1-c4d1d3c37588"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(7940), null, "Gasoline", null }
                });

            migrationBuilder.InsertData(
                table: "Transmissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2ae251cf-354e-4c6a-b808-9fb7805b71d3"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8040), null, "Manual", null },
                    { new Guid("9799d776-2a92-4771-a73d-19a381f73cef"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8040), null, "Automatic", null },
                    { new Guid("bd2bb9e7-9f5a-442a-a24d-97bc98f4205f"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8040), null, "Semi-Automatic", null }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "CreatedDate", "DailyPrice", "DeletedDate", "FuelId", "ImageUrl", "Name", "TransmissionId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("47664e1a-3811-4d49-a4e2-85f5db020882"), new Guid("c62c12fe-5b4b-436f-b2cc-3a8ce337c054"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8120), 1100m, null, new Guid("9f39e21d-2df4-4b5b-abc1-c4d1d3c37588"), "images/ford-focus.jpg", "Focus", new Guid("9799d776-2a92-4771-a73d-19a381f73cef"), null },
                    { new Guid("622de90a-9b2f-416f-b355-a2db8700b6a6"), new Guid("a358155a-234c-4525-b33c-de1ea21c1469"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8110), 1450m, null, new Guid("7e57d004-2b97-0e7a-b45f-5387362902d2"), "images/bmw-3-series.jpg", "3 Series", new Guid("2ae251cf-354e-4c6a-b808-9fb7805b71d3"), null },
                    { new Guid("655ee34e-d40c-488a-a730-cdbc9e7938e3"), new Guid("fa9c7d42-b6cf-43d5-9651-e8c2266e30fa"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8110), 1500m, null, new Guid("7e57d004-2b97-0e7a-b45f-5387362902d2"), "images/audi-a3.jpg", "A3", new Guid("2ae251cf-354e-4c6a-b808-9fb7805b71d3"), null },
                    { new Guid("8aa08cdc-6cb5-4279-a521-7201f7ee8f45"), new Guid("1caa83b0-b32c-4e94-8e12-03b19fe584bf"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8110), 1600m, null, new Guid("5fa1c428-304a-4016-9ab2-99560626e1ce"), "images/mercedes-c-class.jpg", "C Class", new Guid("9799d776-2a92-4771-a73d-19a381f73cef"), null },
                    { new Guid("a6b40c9a-2b3d-4dbf-993b-483fb7a855f3"), new Guid("c5450178-921a-46c6-b236-b0e4787604e6"), new DateTime(2023, 12, 7, 12, 24, 37, 951, DateTimeKind.Utc).AddTicks(8120), 1200m, null, new Guid("9f39e21d-2df4-4b5b-abc1-c4d1d3c37588"), "images/volkswagen-golf.jpg", "Golf", new Guid("9799d776-2a92-4771-a73d-19a381f73cef"), null }
                });

            migrationBuilder.CreateIndex(
                name: "UK_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "UK_Fuels_Name",
                table: "Fuels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_FuelId",
                table: "Models",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_TransmissionId",
                table: "Models",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "UK_Models_Name",
                table: "Models",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Transmissions_Name",
                table: "Transmissions",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Fuels");

            migrationBuilder.DropTable(
                name: "Transmissions");
        }
    }
}
