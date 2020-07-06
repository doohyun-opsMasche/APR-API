using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APPROVAL.Migrations
{
    public partial class approvers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Approvers",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    userName = table.Column<string>(nullable: true),
                    passwordhash = table.Column<byte[]>(nullable: true),
                    passwordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approvers");
        }
    }
}
