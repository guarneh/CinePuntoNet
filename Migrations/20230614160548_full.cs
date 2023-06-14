using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinemania.Migrations
{
    /// <inheritdoc />
    public partial class full : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cantEntradas",
                table: "funcionUsuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cantEntradas",
                table: "funcionUsuarios");
        }
    }
}
