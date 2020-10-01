using Microsoft.EntityFrameworkCore.Migrations;

namespace GNG_v0._2.Migrations
{
    public partial class AddingPhotoUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsportPlayer",
                table: "EximiusParticipantTable");

            migrationBuilder.DropColumn(
                name: "Join",
                table: "EximiusParticipantTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsportPlayer",
                table: "EximiusParticipantTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Join",
                table: "EximiusParticipantTable",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
