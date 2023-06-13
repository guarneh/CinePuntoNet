using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinemania.Migrations
{
    /// <inheritdoc />
    public partial class pc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "sinopsis",
                table: "Peliculas",
                newName: "Sinopsis");

            migrationBuilder.RenameColumn(
                name: "poster",
                table: "Peliculas",
                newName: "Poster");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Peliculas",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "duracion",
                table: "Peliculas",
                newName: "Duracion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sinopsis",
                table: "Peliculas",
                newName: "sinopsis");

            migrationBuilder.RenameColumn(
                name: "Poster",
                table: "Peliculas",
                newName: "poster");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Peliculas",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Duracion",
                table: "Peliculas",
                newName: "duracion");

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
    }
}
