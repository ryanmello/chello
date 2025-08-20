using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class MessageConsistency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prompt",
                table: "UserMessages",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "Response",
                table: "ChelloMessages",
                newName: "Message");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "UserMessages",
                newName: "Prompt");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "ChelloMessages",
                newName: "Response");
        }
    }
}
