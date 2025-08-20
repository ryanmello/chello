using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class TextToPrompt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "UserMessages",
                newName: "Prompt");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "ChelloMessages",
                newName: "Prompt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prompt",
                table: "UserMessages",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Prompt",
                table: "ChelloMessages",
                newName: "Text");
        }
    }
}
