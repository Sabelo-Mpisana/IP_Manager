using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IP_Manager.Migrations
{
    /// <inheritdoc />
    public partial class newSubnetUpgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maskString",
                table: "Subnet");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Mask",
                table: "Subnet",
                type: "binary(4)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Mask",
                table: "Subnet",
                type: "varbinary(4)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "binary(4)");

            migrationBuilder.AddColumn<string>(
                name: "maskString",
                table: "Subnet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
