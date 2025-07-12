using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignCakesApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removingdependencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Customers_customerId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Labels_LabelsId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_LovedOnes_Customers_CustomerId",
                table: "LovedOnes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_customerid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_customerid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_LovedOnes_CustomerId",
                table: "LovedOnes");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LabelsId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_customerId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "LabelsId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "DOB",
                table: "LovedOnes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "LovedOnes");

            migrationBuilder.AddColumn<int>(
                name: "LabelsId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerid",
                table: "Orders",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_LovedOnes_CustomerId",
                table: "LovedOnes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LabelsId",
                table: "Customers",
                column: "LabelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_customerId",
                table: "Complaints",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Customers_customerId",
                table: "Complaints",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Labels_LabelsId",
                table: "Customers",
                column: "LabelsId",
                principalTable: "Labels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LovedOnes_Customers_CustomerId",
                table: "LovedOnes",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_customerid",
                table: "Orders",
                column: "customerid",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
