using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    public partial class createPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Biography", "DateOfBirth", "Name", "Picture" },
                values: new object[,]
                {
                    { 1, "John Doe is a fictional character and the main protagonist of the fictional series The Walking Dead.", new DateTime(1958, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png" },
                    { 2, "Rick Grimes is a fictional character and the main protagonist of the fictional series The Walking Dead.", new DateTime(1958, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rick Grimes", "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png" },
                    { 3, "Michonne is a fictional character and the main protagonist of the fictional series The Walking Dead.", new DateTime(1958, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michonne", "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png" },
                    { 4, "Glenn Rhee is a fictional character and the main protagonist of the fictional series The Walking Dead.", new DateTime(1958, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Glenn Rhee", "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
