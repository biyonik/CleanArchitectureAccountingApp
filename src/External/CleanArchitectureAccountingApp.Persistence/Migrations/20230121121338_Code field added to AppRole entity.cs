using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitectureAccountingApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CodefieldaddedtoAppRoleentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Roles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Roles");
        }
    }
}
