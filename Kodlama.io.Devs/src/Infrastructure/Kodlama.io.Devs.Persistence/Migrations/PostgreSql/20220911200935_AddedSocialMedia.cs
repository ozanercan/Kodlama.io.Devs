using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations.PostgreSql
{
    public partial class AddedSocialMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialPlatforms",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialPlatforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSocialAccounts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SocialPlatformId = table.Column<int>(type: "integer", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocialAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSocialAccounts_SocialPlatforms_SocialPlatformId",
                        column: x => x.SocialPlatformId,
                        principalTable: "SocialPlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSocialAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Github", "https://github.com/" },
                    { 2, "Facebook", "https://facebook.com/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSocialAccounts_SocialPlatformId",
                table: "UserSocialAccounts",
                column: "SocialPlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSocialAccounts_UserId",
                table: "UserSocialAccounts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSocialAccounts");

            migrationBuilder.DropTable(
                name: "SocialPlatforms");
        }
    }
}
