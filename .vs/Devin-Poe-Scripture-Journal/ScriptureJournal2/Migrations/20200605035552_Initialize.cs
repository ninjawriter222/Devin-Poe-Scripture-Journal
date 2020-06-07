using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScriptureJournal2.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scripture",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book = table.Column<string>(nullable: true),
                    Chapter = table.Column<int>(nullable: false),
                    Verse = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    JournalEntry = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripture", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scripture");
        }
    }
}
