using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinemania.Migrations
{
    /// <inheritdoc />
    public partial class notebook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "id", "duracion", "nombre", "poster", "sinopsis" },
                values: new object[,]
                {
                    { 1, 120, "Mario 1", "peaches peaches", "una re peli" },
                    { 2, 230, "Barbie", "Ryan Gosling", "amo a ken" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "id", "capacidad", "ubicacion" },
                values: new object[,]
                {
                    { 1, 35, "sala 1" },
                    { 2, 35, "sala 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Salas",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Salas",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
