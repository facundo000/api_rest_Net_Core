using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcialWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Criptomonedas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    simbolo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    valor_actual = table.Column<double>(type: "float", nullable: false),
                    ultima_actualizacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    categoria = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criptomonedas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Criptomonedas_Categorias",
                        column: x => x.categoria,
                        principalTable: "Categorias",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Criptomonedas_categoria",
                table: "Criptomonedas",
                column: "categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Criptomonedas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
