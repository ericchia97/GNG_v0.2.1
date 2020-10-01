using Microsoft.EntityFrameworkCore.Migrations;

namespace GNG_v0._2.Migrations
{
    public partial class addingPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath1",
                table: "EximiusParticipantTable",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath2",
                table: "EximiusParticipantTable",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath3",
                table: "EximiusParticipantTable",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath4",
                table: "EximiusParticipantTable",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath1",
                table: "EximiusParticipantTable");

            migrationBuilder.DropColumn(
                name: "PhotoPath2",
                table: "EximiusParticipantTable");

            migrationBuilder.DropColumn(
                name: "PhotoPath3",
                table: "EximiusParticipantTable");

            migrationBuilder.DropColumn(
                name: "PhotoPath4",
                table: "EximiusParticipantTable");
        }
    }
}
