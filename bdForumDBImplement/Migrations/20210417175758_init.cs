using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace bdForumDBImplement.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "moderator",
                columns: table => new
                {
                    login = table.Column<string>(maxLength: 255, nullable: false),
                    password_ = table.Column<string>(maxLength: 255, nullable: false),
                    email = table.Column<string>(maxLength: 255, nullable: false),
                    amountofhelp = table.Column<int>(nullable: false),
                    totalTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("moderator_pkey", x => x.login);
                });

            migrationBuilder.CreateTable(
                name: "topic",
                columns: table => new
                {
                    name_ = table.Column<string>(maxLength: 255, nullable: false),
                    numberofvisitors = table.Column<int>(nullable: false),
                    numberofmessages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("topic_pkey", x => x.name_);
                });

            migrationBuilder.CreateTable(
                name: "visitor",
                columns: table => new
                {
                    login = table.Column<string>(maxLength: 255, nullable: false),
                    password_ = table.Column<string>(maxLength: 255, nullable: false),
                    email = table.Column<string>(maxLength: 255, nullable: false),
                    status = table.Column<string>(maxLength: 255, nullable: false),
                    countmessages = table.Column<int>(nullable: false),
                    decency = table.Column<int>(nullable: false),
                    totalTime = table.Column<int>(nullable: false, comment: "Общее время")
                },
                constraints: table =>
                {
                    table.PrimaryKey("visitor_pkey", x => x.login);
                });

            migrationBuilder.CreateTable(
                name: "message_",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(maxLength: 20000, nullable: false),
                    time = table.Column<DateTime>(nullable: false),
                    visitorlogin = table.Column<string>(maxLength: 255, nullable: false),
                    topicname_ = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_", x => x.id);
                    table.ForeignKey(
                        name: "message__topicname__fkey",
                        column: x => x.topicname_,
                        principalTable: "topic",
                        principalColumn: "name_",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "message__visitorlogin_fkey",
                        column: x => x.visitorlogin,
                        principalTable: "visitor",
                        principalColumn: "login",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "like_",
                columns: table => new
                {
                    visitorlogin = table.Column<string>(maxLength: 255, nullable: false),
                    messageid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("like__pkey", x => new { x.visitorlogin, x.messageid });
                    table.ForeignKey(
                        name: "like__messageid_fkey",
                        column: x => x.messageid,
                        principalTable: "message_",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "like__visitorlogin_fkey",
                        column: x => x.visitorlogin,
                        principalTable: "visitor",
                        principalColumn: "login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_like__messageid",
                table: "like_",
                column: "messageid");

            migrationBuilder.CreateIndex(
                name: "IX_message__topicname_",
                table: "message_",
                column: "topicname_");

            migrationBuilder.CreateIndex(
                name: "IX_message__visitorlogin",
                table: "message_",
                column: "visitorlogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "like_");

            migrationBuilder.DropTable(
                name: "moderator");

            migrationBuilder.DropTable(
                name: "message_");

            migrationBuilder.DropTable(
                name: "topic");

            migrationBuilder.DropTable(
                name: "visitor");
        }
    }
}
