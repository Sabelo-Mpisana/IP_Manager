using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IP_Manager.Migrations
{
    /// <inheritdoc />
    public partial class subnetModelUpgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mask",
                table: "Subnet",
                newName: "Mask");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Mask",
                table: "Subnet",
                type: "BINARY(4)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "IPV4",
                table: "Subnet",
                type: "BINARY(4)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "maskString",
                table: "Subnet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Subnet_IPV4",
                table: "Subnet",
                column: "IPV4",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subnet_IPV4",
                table: "Subnet");

            migrationBuilder.DropColumn(
                name: "maskString",
                table: "Subnet");

            migrationBuilder.RenameColumn(
                name: "Mask",
                table: "Subnet",
                newName: "mask");

            migrationBuilder.AlterColumn<string>(
                name: "mask",
                table: "Subnet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BINARY(4)");

            migrationBuilder.AlterColumn<int>(
                name: "IPV4",
                table: "Subnet",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BINARY(4)");
        }
    }
}
