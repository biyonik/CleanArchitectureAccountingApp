using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitectureAccountingApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CompanyEntityfieldedited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Companies",
                newName: "ServerUserId");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Companies",
                newName: "ServerPassword");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServerUserId",
                table: "Companies",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ServerPassword",
                table: "Companies",
                newName: "Password");
        }
    }
}
