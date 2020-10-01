using Microsoft.EntityFrameworkCore.Migrations;

namespace GNG_v0._2.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UsersTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersTable",
                table: "UsersTable",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EximiusParticipantTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: false),
                    TeamName = table.Column<string>(maxLength: 50, nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    IGN = table.Column<string>(nullable: false),
                    IC = table.Column<string>(nullable: false),
                    Race = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Member1_Name = table.Column<string>(nullable: false),
                    Member1_IGN = table.Column<string>(nullable: false),
                    Member1_IC = table.Column<string>(nullable: false),
                    Member1_ContactNumber = table.Column<string>(nullable: false),
                    Member1_Race = table.Column<string>(nullable: false),
                    Member1_State = table.Column<string>(nullable: false),
                    Member2_Name = table.Column<string>(nullable: false),
                    Member2_IGN = table.Column<string>(nullable: false),
                    Member2_IC = table.Column<string>(nullable: false),
                    Member2_ContactNumber = table.Column<string>(nullable: false),
                    Member2_Race = table.Column<string>(nullable: false),
                    Member2_State = table.Column<string>(nullable: false),
                    Member3_Name = table.Column<string>(nullable: false),
                    Member3_IGN = table.Column<string>(nullable: false),
                    Member3_IC = table.Column<string>(nullable: false),
                    Member3_ContactNumber = table.Column<string>(nullable: false),
                    Member3_Race = table.Column<string>(nullable: false),
                    Member3_State = table.Column<string>(nullable: false),
                    Member4_Name = table.Column<string>(nullable: false),
                    Member4_IGN = table.Column<string>(nullable: false),
                    Member4_IC = table.Column<string>(nullable: false),
                    Member4_ContactNumber = table.Column<string>(nullable: false),
                    Member4_Race = table.Column<string>(nullable: false),
                    Member4_State = table.Column<string>(nullable: false),
                    Join = table.Column<bool>(nullable: false),
                    EsportPlayer = table.Column<bool>(nullable: false),
                    Understand = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EximiusParticipantTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EximiusParticipantTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersTable",
                table: "UsersTable");

            migrationBuilder.RenameTable(
                name: "UsersTable",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
