using Microsoft.EntityFrameworkCore.Migrations;

namespace APPROVAL.Migrations
{
    public partial class CreateApprovalDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Commands",
                table: "Commands");

            migrationBuilder.RenameTable(
                name: "Commands",
                newName: "Account");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    processId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyCode = table.Column<string>(nullable: true),
                    companyName = table.Column<string>(nullable: true),
                    creator = table.Column<string>(nullable: true),
                    creatorId = table.Column<string>(nullable: true),
                    creatorDepartment = table.Column<string>(nullable: true),
                    subject = table.Column<string>(nullable: true),
                    formId = table.Column<int>(nullable: false),
                    ruleId = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.processId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Commands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commands",
                table: "Commands",
                column: "id");
        }
    }
}
