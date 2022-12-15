using Microsoft.EntityFrameworkCore.Migrations;

namespace ApoioConsultorio.Migrations
{
    public partial class addcampoespecial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "especial",
                table: "Procedimentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "especial",
                table: "Procedimentos");
        }
    }
}
