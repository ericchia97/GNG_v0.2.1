using Microsoft.EntityFrameworkCore.Migrations;

namespace GNG_v0._2.Migrations
{
    public partial class AddingPhotopath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "EximiusParticipantTable",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "EximiusParticipantTable");
        }
    }
}
