using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHomeContentToDog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HomeContent",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeContent",
                table: "Dogs");
        }
    }
}
