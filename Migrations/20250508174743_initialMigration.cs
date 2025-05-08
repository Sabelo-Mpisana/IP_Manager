using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IP_Manager.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    clientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    physicalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.clientID);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    deviceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    macAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deviceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.deviceID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    projectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateOnly>(type: "date", nullable: false),
                    endDate = table.Column<DateOnly>(type: "date", nullable: false),
                    clientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.projectID);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_clientID",
                        column: x => x.clientID,
                        principalTable: "Clients",
                        principalColumn: "clientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subnet",
                columns: table => new
                {
                    subnetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IPV4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    musk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateOnly>(type: "date", nullable: false),
                    projectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subnet", x => x.subnetID);
                    table.ForeignKey(
                        name: "FK_Subnet_Projects_projectID",
                        column: x => x.projectID,
                        principalTable: "Projects",
                        principalColumn: "projectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IP_Assigned",
                columns: table => new
                {
                    IPID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ipAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    dateReleased = table.Column<DateOnly>(type: "date", nullable: false),
                    subnetID = table.Column<int>(type: "int", nullable: false),
                    deviceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IP_Assigned", x => x.IPID);
                    table.ForeignKey(
                        name: "FK_IP_Assigned_Device_deviceID",
                        column: x => x.deviceID,
                        principalTable: "Device",
                        principalColumn: "deviceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IP_Assigned_Subnet_subnetID",
                        column: x => x.subnetID,
                        principalTable: "Subnet",
                        principalColumn: "subnetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IP_Assigned_deviceID",
                table: "IP_Assigned",
                column: "deviceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IP_Assigned_subnetID",
                table: "IP_Assigned",
                column: "subnetID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_clientID",
                table: "Projects",
                column: "clientID");

            migrationBuilder.CreateIndex(
                name: "IX_Subnet_projectID",
                table: "Subnet",
                column: "projectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IP_Assigned");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Subnet");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
