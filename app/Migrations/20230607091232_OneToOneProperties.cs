using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OffsureAssessment.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ABN",
                table: "CarListings");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "CarListings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CarListings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CarListings");

            migrationBuilder.CreateTable(
                name: "DealerProperties",
                columns: table => new
                {
                    DealerPropertyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ABN = table.Column<string>(type: "text", nullable: true),
                    ListingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerProperties", x => x.DealerPropertyId);
                    table.ForeignKey(
                        name: "FK_DealerProperties_CarListings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "CarListings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NonDealerProperties",
                columns: table => new
                {
                    NonDealerPropertyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ListingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonDealerProperties", x => x.NonDealerPropertyId);
                    table.ForeignKey(
                        name: "FK_NonDealerProperties_CarListings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "CarListings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DealerProperties_ListingId",
                table: "DealerProperties",
                column: "ListingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NonDealerProperties_ListingId",
                table: "NonDealerProperties",
                column: "ListingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealerProperties");

            migrationBuilder.DropTable(
                name: "NonDealerProperties");

            migrationBuilder.AddColumn<string>(
                name: "ABN",
                table: "CarListings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "CarListings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CarListings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CarListings",
                type: "text",
                nullable: true);
        }
    }
}
