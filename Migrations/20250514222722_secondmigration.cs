using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IP_Manager.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IP_Assigned_Device_deviceID",
                table: "IP_Assigned");

            migrationBuilder.DropForeignKey(
                name: "FK_IP_Assigned_Subnet_subnetID",
                table: "IP_Assigned");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Clients_clientID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subnet_Projects_projectID",
                table: "Subnet");

            migrationBuilder.DropIndex(
                name: "IX_IP_Assigned_deviceID",
                table: "IP_Assigned");

            migrationBuilder.DropIndex(
                name: "IX_IP_Assigned_subnetID",
                table: "IP_Assigned");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Device",
                table: "Device");

            migrationBuilder.RenameTable(
                name: "Device",
                newName: "Devices");

            migrationBuilder.RenameColumn(
                name: "musk",
                table: "Subnet",
                newName: "mask");

            migrationBuilder.RenameColumn(
                name: "ipAddress",
                table: "IP_Assigned",
                newName: "IpAddress");

            migrationBuilder.AlterColumn<int>(
                name: "projectID",
                table: "Subnet",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IPV4",
                table: "Subnet",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "clientID",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "subnetID",
                table: "IP_Assigned",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IpAddress",
                table: "IP_Assigned",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "deviceID",
                table: "IP_Assigned",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "deviceID");

            migrationBuilder.CreateIndex(
                name: "IX_IP_Assigned_deviceID",
                table: "IP_Assigned",
                column: "deviceID",
                unique: true,
                filter: "[deviceID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IP_Assigned_subnetID_IpAddress",
                table: "IP_Assigned",
                columns: new[] { "subnetID", "IpAddress" },
                unique: true,
                filter: "[subnetID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_IP_Assigned_Devices_deviceID",
                table: "IP_Assigned",
                column: "deviceID",
                principalTable: "Devices",
                principalColumn: "deviceID");

            migrationBuilder.AddForeignKey(
                name: "FK_IP_Assigned_Subnet_subnetID",
                table: "IP_Assigned",
                column: "subnetID",
                principalTable: "Subnet",
                principalColumn: "subnetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Clients_clientID",
                table: "Projects",
                column: "clientID",
                principalTable: "Clients",
                principalColumn: "clientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subnet_Projects_projectID",
                table: "Subnet",
                column: "projectID",
                principalTable: "Projects",
                principalColumn: "projectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IP_Assigned_Devices_deviceID",
                table: "IP_Assigned");

            migrationBuilder.DropForeignKey(
                name: "FK_IP_Assigned_Subnet_subnetID",
                table: "IP_Assigned");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Clients_clientID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subnet_Projects_projectID",
                table: "Subnet");

            migrationBuilder.DropIndex(
                name: "IX_IP_Assigned_deviceID",
                table: "IP_Assigned");

            migrationBuilder.DropIndex(
                name: "IX_IP_Assigned_subnetID_IpAddress",
                table: "IP_Assigned");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Device");

            migrationBuilder.RenameColumn(
                name: "mask",
                table: "Subnet",
                newName: "musk");

            migrationBuilder.RenameColumn(
                name: "IpAddress",
                table: "IP_Assigned",
                newName: "ipAddress");

            migrationBuilder.AlterColumn<int>(
                name: "projectID",
                table: "Subnet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IPV4",
                table: "Subnet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "clientID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "subnetID",
                table: "IP_Assigned",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "deviceID",
                table: "IP_Assigned",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ipAddress",
                table: "IP_Assigned",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Device",
                table: "Device",
                column: "deviceID");

            migrationBuilder.CreateIndex(
                name: "IX_IP_Assigned_deviceID",
                table: "IP_Assigned",
                column: "deviceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IP_Assigned_subnetID",
                table: "IP_Assigned",
                column: "subnetID");

            migrationBuilder.AddForeignKey(
                name: "FK_IP_Assigned_Device_deviceID",
                table: "IP_Assigned",
                column: "deviceID",
                principalTable: "Device",
                principalColumn: "deviceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IP_Assigned_Subnet_subnetID",
                table: "IP_Assigned",
                column: "subnetID",
                principalTable: "Subnet",
                principalColumn: "subnetID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Clients_clientID",
                table: "Projects",
                column: "clientID",
                principalTable: "Clients",
                principalColumn: "clientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subnet_Projects_projectID",
                table: "Subnet",
                column: "projectID",
                principalTable: "Projects",
                principalColumn: "projectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
