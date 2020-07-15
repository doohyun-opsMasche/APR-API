using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APPROVAL.Migrations.Maria
{
    public partial class InitialMigration : Migration
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

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    processId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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

            migrationBuilder.CreateTable(
                name: "TB_FORM_CATEGORY",
                columns: table => new
                {
                    FORM_CATEGORY_ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FORM_CATEGORY_NM = table.Column<string>(maxLength: 30, nullable: false),
                    FORM_CATEGORY_LANGUAGE_FLAG = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    FORM_CATEGORY_SORT = table.Column<int>(nullable: false),
                    INS_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FORM_CATEGORY", x => x.FORM_CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_FORM_FILE_GROUP",
                columns: table => new
                {
                    FORM_FILE_GROUP_ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FORM_FILE_GROUP_NM = table.Column<string>(maxLength: 255, nullable: false),
                    FORM_FILE_GROUP_DISPLAY_NM = table.Column<string>(maxLength: 20, nullable: false),
                    FORM_FILE_GROUP_LEVEL = table.Column<int>(maxLength: 300, nullable: false),
                    INS_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FORM_FILE_GROUP", x => x.FORM_FILE_GROUP_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_FORM",
                columns: table => new
                {
                    FORM_ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FORM_CATEGORY_ID = table.Column<int>(nullable: false),
                    FORM_FILE_GROUP_ID = table.Column<int>(nullable: false),
                    FORM_NM = table.Column<string>(maxLength: 30, nullable: false),
                    FORM_DESCRIPTION = table.Column<string>(maxLength: 4000, nullable: true),
                    FORM_SORT = table.Column<int>(nullable: false),
                    USE_FLAG = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    DISPLAY_FLAG = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    FORM_DELAY_ALERT_DAY = table.Column<int>(nullable: false),
                    FORM_DELAY_ALERT_TIME = table.Column<string>(maxLength: 4, nullable: false),
                    FORM_LEGACY_FLAG = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    FORM_LEGACY_TYPE = table.Column<string>(nullable: true),
                    FORM_LEGACY_URL = table.Column<string>(nullable: true),
                    FORM_DOCUMENT_NUMBER_FLAG = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    FORM_DOCUMENT_TRANSFER_FLAG = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    FORM_DIRECTION_FLAG = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    FORM_APPROVAL_LINE_MODIFY_FLAG = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    FORM_DEPARTMENT_BOX_READ_FLAG = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    FORM_MANDATORY_FLAG = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    FORM_DELEGATE_POLICY_ID = table.Column<string>(nullable: true),
                    INS_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FORM", x => x.FORM_ID);
                    table.ForeignKey(
                        name: "FK_TB_FORM_TB_FORM_CATEGORY_FORM_CATEGORY_ID",
                        column: x => x.FORM_CATEGORY_ID,
                        principalTable: "TB_FORM_CATEGORY",
                        principalColumn: "FORM_CATEGORY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_FORM_TB_FORM_FILE_GROUP_FORM_FILE_GROUP_ID",
                        column: x => x.FORM_FILE_GROUP_ID,
                        principalTable: "TB_FORM_FILE_GROUP",
                        principalColumn: "FORM_FILE_GROUP_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_FORM_FILE",
                columns: table => new
                {
                    FORM_FILE_ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FORM_FILE_GROUP_ID = table.Column<int>(nullable: false),
                    FORM_FILE_PATH = table.Column<string>(maxLength: 300, nullable: false),
                    FORM_FILE_TYPE = table.Column<string>(maxLength: 1, nullable: false),
                    FORM_FILE_FOLDER_FLAG = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    INS_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FORM_FILE", x => x.FORM_FILE_ID);
                    table.ForeignKey(
                        name: "FK_TB_FORM_FILE_TB_FORM_FILE_GROUP_FORM_FILE_GROUP_ID",
                        column: x => x.FORM_FILE_GROUP_ID,
                        principalTable: "TB_FORM_FILE_GROUP",
                        principalColumn: "FORM_FILE_GROUP_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_FORM_DISPLAY_AUTH",
                columns: table => new
                {
                    FORM_DISPLAY_AUTH_FORM_ID = table.Column<int>(nullable: false),
                    FORM_DISPLAY_AUTH_ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FORM_DISPLAY_AUTH_RESOURCE = table.Column<string>(maxLength: 20, nullable: false),
                    FORM_DISPLAY_AUTH_TYPE = table.Column<string>(maxLength: 8, nullable: false),
                    INS_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FORM_DISPLAY_AUTH", x => new { x.FORM_DISPLAY_AUTH_ID, x.FORM_DISPLAY_AUTH_FORM_ID });
                    table.ForeignKey(
                        name: "FK_TB_FORM_DISPLAY_AUTH_TB_FORM_FORM_DISPLAY_AUTH_FORM_ID",
                        column: x => x.FORM_DISPLAY_AUTH_FORM_ID,
                        principalTable: "TB_FORM",
                        principalColumn: "FORM_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_FORM_FORM_CATEGORY_ID",
                table: "TB_FORM",
                column: "FORM_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FORM_FORM_FILE_GROUP_ID",
                table: "TB_FORM",
                column: "FORM_FILE_GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FORM_DISPLAY_AUTH_FORM_DISPLAY_AUTH_FORM_ID",
                table: "TB_FORM_DISPLAY_AUTH",
                column: "FORM_DISPLAY_AUTH_FORM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FORM_FILE_FORM_FILE_GROUP_ID",
                table: "TB_FORM_FILE",
                column: "FORM_FILE_GROUP_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approvers");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "TB_FORM_DISPLAY_AUTH");

            migrationBuilder.DropTable(
                name: "TB_FORM_FILE");

            migrationBuilder.DropTable(
                name: "TB_FORM");

            migrationBuilder.DropTable(
                name: "TB_FORM_CATEGORY");

            migrationBuilder.DropTable(
                name: "TB_FORM_FILE_GROUP");
        }
    }
}
