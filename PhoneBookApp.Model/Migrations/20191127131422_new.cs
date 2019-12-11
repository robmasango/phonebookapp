using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBookApp.Model.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "PHB_PhoneBook",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHB_PhoneBook", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_Error",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(maxLength: 100, nullable: false),
                    StackTrace = table.Column<string>(maxLength: 8000, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_Error", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PHB_PhoneNumber",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phonebookid = table.Column<int>(nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    number = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHB_PhoneNumber", x => x.id);
                    table.ForeignKey(
                        name: "FK_PHB_PhoneNumber_PHB_PhoneBook_phonebookid",
                        column: x => x.phonebookid,
                        principalSchema: "dbo",
                        principalTable: "PHB_PhoneBook",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PHB_PhoneNumber_phonebookid",
                schema: "dbo",
                table: "PHB_PhoneNumber",
                column: "phonebookid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PHB_PhoneNumber",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SYS_Error",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PHB_PhoneBook",
                schema: "dbo");
        }
    }
}
