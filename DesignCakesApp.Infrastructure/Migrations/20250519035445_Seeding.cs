using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignCakesApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ProductSizes",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductSizes",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "size",
                table: "ProductSizes",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductSizes",
                newName: "Id");
        }
    }
}
