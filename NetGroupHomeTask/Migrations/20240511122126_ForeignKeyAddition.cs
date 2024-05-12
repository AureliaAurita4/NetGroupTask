using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetGroupHomeTask.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Users");
        }
    }
}
