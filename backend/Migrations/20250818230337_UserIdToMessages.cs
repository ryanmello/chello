using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UserIdToMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "text",
                table: "UserMessages",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "ChelloMessages",
                newName: "Text");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserMessages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ChelloMessages",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserMessages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChelloMessages");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "UserMessages",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "ChelloMessages",
                newName: "text");
        }
    }
}
