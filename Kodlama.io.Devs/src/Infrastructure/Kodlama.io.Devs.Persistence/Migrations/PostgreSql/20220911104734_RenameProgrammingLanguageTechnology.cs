using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations.PostgreSql
{
    public partial class RenameProgrammingLanguageTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technology_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Technology");

            migrationBuilder.DropIndex(
                name: "IX_Technology_ProgrammingLanguageId",
                table: "Technology");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Technology");

            migrationBuilder.DropColumn(
                name: "ProgrammingLanguageId",
                table: "Technology");

            migrationBuilder.CreateTable(
                name: "ProgrammingLanguageTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ProgrammingLanguageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguageTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingLanguageTechnologies_ProgrammingLanguages_Progra~",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgrammingLanguageTechnologies_Technology_Id",
                        column: x => x.Id,
                        principalTable: "Technology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingLanguageTechnologies_ProgrammingLanguageId",
                table: "ProgrammingLanguageTechnologies",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingLanguageTechnologies");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Technology",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProgrammingLanguageId",
                table: "Technology",
                type: "integer",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.CreateIndex(
                name: "IX_Technology_ProgrammingLanguageId",
                table: "Technology",
                column: "ProgrammingLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technology_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Technology",
                column: "ProgrammingLanguageId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
