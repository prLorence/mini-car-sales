using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OffsureAssessment.Migrations
{
    /// <inheritdoc />
    public partial class ContactDetailsRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealerProperties");

            migrationBuilder.DropTable(
                name: "NonDealerProperties");

            migrationBuilder.CreateTable(
                name: "DealerDetails",
                columns: table => new
                {
                    DealerPropertyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ABN = table.Column<string>(type: "text", nullable: true),
                    ListingId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerDetails", x => x.DealerPropertyId);
                    table.ForeignKey(
                        name: "FK_DealerDetails_CarListings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "CarListings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NonDealerDetails",
                columns: table => new
                {
                    NonDealerPropertyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    ListingId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonDealerDetails", x => x.NonDealerPropertyId);
                    table.ForeignKey(
                        name: "FK_NonDealerDetails_CarListings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "CarListings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DealerDetails_ListingId",
                table: "DealerDetails",
                column: "ListingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NonDealerDetails_ListingId",
                table: "NonDealerDetails",
                column: "ListingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealerDetails");

            migrationBuilder.DropTable(
                name: "NonDealerDetails");

            migrationBuilder.CreateTable(
                name: "DealerProperties",
                columns: table => new
                {
                    DealerPropertyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListingId = table.Column<int>(type: "integer", nullable: true),
                    ABN = table.Column<string>(type: "text", nullable: true)
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
                    ListingId = table.Column<int>(type: "integer", nullable: false),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
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
    }
}
