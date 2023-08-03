using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OperationDistributionApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    OperationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<int>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.OperationID);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    HistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    OperationID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.HistoryID);
                    table.ForeignKey(
                        name: "FK_Histories_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Histories_Operations_OperationID",
                        column: x => x.OperationID,
                        principalTable: "Operations",
                        principalColumn: "OperationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "John", "Smith" },
                    { 2, "Emily", "Johnson" },
                    { 3, "Michael", "Williams" },
                    { 4, "Sarah", "Jones" },
                    { 5, "David", "Brown" },
                    { 6, "Jennifer", "Wilson" }
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "OperationID", "Difficulty", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Welding Chassis" },
                    { 2, 2, "Assembling Engine Blocks" },
                    { 3, 3, "Installing Wiring Harnesses" },
                    { 4, 4, "Attaching Body Panels" },
                    { 5, 5, "Painting Car Bodies" },
                    { 6, 6, "Fitting Interior Components" }
                });

            migrationBuilder.InsertData(
                table: "Histories",
                columns: new[] { "HistoryID", "CreatedAt", "EmployeeID", "IsActive", "OperationID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 1, 22, 46, 57, 102, DateTimeKind.Local).AddTicks(956), 1, true, 1 },
                    { 2, new DateTime(2023, 8, 1, 22, 46, 57, 102, DateTimeKind.Local).AddTicks(998), 2, true, 2 },
                    { 3, new DateTime(2023, 8, 1, 22, 46, 57, 102, DateTimeKind.Local).AddTicks(999), 3, true, 3 },
                    { 4, new DateTime(2023, 8, 1, 22, 46, 57, 102, DateTimeKind.Local).AddTicks(1000), 4, true, 4 },
                    { 5, new DateTime(2023, 8, 1, 22, 46, 57, 102, DateTimeKind.Local).AddTicks(1002), 5, true, 5 },
                    { 6, new DateTime(2023, 8, 1, 22, 46, 57, 102, DateTimeKind.Local).AddTicks(1003), 6, true, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Histories_EmployeeID",
                table: "Histories",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_OperationID",
                table: "Histories",
                column: "OperationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Operations");
        }
    }
}
