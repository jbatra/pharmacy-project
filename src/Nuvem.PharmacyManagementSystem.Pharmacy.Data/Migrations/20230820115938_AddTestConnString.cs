using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTestConnString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConnStringWorking",
                table: "Pharmacy",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConnStringWorking",
                table: "Pharmacy");
        }
    }
}
