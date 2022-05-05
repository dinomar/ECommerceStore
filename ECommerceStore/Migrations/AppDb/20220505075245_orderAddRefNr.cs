using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceStore.Migrations.AppDb
{
    public partial class orderAddRefNr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferenceNr",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceNr",
                table: "Orders");
        }
    }
}
