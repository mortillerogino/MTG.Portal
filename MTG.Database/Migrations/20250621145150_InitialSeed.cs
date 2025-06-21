using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MTG.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Binders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Binders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MtgColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtgColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MtgTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtgTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Page = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BinderId = table.Column<int>(type: "int", nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Binders_BinderId",
                        column: x => x.BinderId,
                        principalTable: "Binders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MtgCardColors",
                columns: table => new
                {
                    MtgCardId = table.Column<int>(type: "int", nullable: false),
                    MtgColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtgCardColors", x => new { x.MtgCardId, x.MtgColorId });
                    table.ForeignKey(
                        name: "FK_MtgCardColors_Cards_MtgCardId",
                        column: x => x.MtgCardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtgCardColors_MtgColors_MtgColorId",
                        column: x => x.MtgColorId,
                        principalTable: "MtgColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MtgCardTypes",
                columns: table => new
                {
                    MtgCardId = table.Column<int>(type: "int", nullable: false),
                    MtgTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtgCardTypes", x => new { x.MtgCardId, x.MtgTypeId });
                    table.ForeignKey(
                        name: "FK_MtgCardTypes_Cards_MtgCardId",
                        column: x => x.MtgCardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtgCardTypes_MtgTypes_MtgTypeId",
                        column: x => x.MtgTypeId,
                        principalTable: "MtgTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MtgColors",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "White mana", "White" },
                    { 2, "Green mana", "Green" },
                    { 3, "Red mana", "Red" },
                    { 4, "Blue mana", "Blue" },
                    { 5, "Black mana", "Black" }
                });

            migrationBuilder.InsertData(
                table: "MtgTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Land card", "Land" },
                    { 2, "Creature card", "Creature" },
                    { 3, "Enchantment card", "Enchantment" },
                    { 4, "Sorcery card", "Sorcery" },
                    { 5, "Instant card", "Instant" },
                    { 6, "Artifact card", "Artifact" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BinderId",
                table: "Cards",
                column: "BinderId");

            migrationBuilder.CreateIndex(
                name: "IX_MtgCardColors_MtgColorId",
                table: "MtgCardColors",
                column: "MtgColorId");

            migrationBuilder.CreateIndex(
                name: "IX_MtgCardTypes_MtgTypeId",
                table: "MtgCardTypes",
                column: "MtgTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MtgCardColors");

            migrationBuilder.DropTable(
                name: "MtgCardTypes");

            migrationBuilder.DropTable(
                name: "MtgColors");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "MtgTypes");

            migrationBuilder.DropTable(
                name: "Binders");
        }
    }
}
