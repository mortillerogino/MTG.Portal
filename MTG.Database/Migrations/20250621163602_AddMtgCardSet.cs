using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTG.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMtgCardSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Set",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Set",
                table: "Cards");
        }
    }
}
