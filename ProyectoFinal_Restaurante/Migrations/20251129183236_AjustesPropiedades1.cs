using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal_Restaurante.Migrations
{
    /// <inheritdoc />
    public partial class AjustesPropiedades1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Agotado",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agotado",
                table: "Products");
        }
    }
}
