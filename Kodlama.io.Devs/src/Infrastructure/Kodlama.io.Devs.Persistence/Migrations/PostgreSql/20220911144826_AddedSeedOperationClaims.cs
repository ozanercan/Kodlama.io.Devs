using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations.PostgreSql
{
    public partial class AddedSeedOperationClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OperationClaim",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Unknown" },
                    { 2, "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaim",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OperationClaim",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
