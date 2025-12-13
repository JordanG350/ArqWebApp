using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArqWebApp.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class cambioCarsProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
