using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IP_Manager.Migrations
{
    /// <inheritdoc />
    public partial class migrationfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Mask",
                table: "Subnet",
                type: "varbinary(4)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BINARY(4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Mask",
                table: "Subnet",
                type: "BINARY(4)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(4)");
        }
    }
}
