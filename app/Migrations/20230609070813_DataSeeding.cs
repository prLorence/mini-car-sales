using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OffsureAssessment.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarListings",
                columns: new[] { "Id", "Comments", "DriveAwayPrice", "ExcludingGovernmentCharges", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 1, "This is a reliable car.", 2000.5, 0.0, "Toyota", "Vios", "2002" },
                    { 2, "Bought this one 2 years ago.", 0.0, 2005.1199999999999, "Honda", "City", "2018" },
                    { 3, "Condition's 10/10'", 5000.1000000000004, 0.0, "Ford", "Raptor", "2023" },
                    { 4, "Used for work commutes", 0.0, 1500.5, "Toyota", "Corolla Altis", "2023" },
                    { 5, "Contact me for more details", 1750.5, 0.0, "Honda", "Civic", "2017" }
                });

            migrationBuilder.InsertData(
                table: "DealerDetails",
                columns: new[] { "DealerPropertyId", "ABN", "ContactNumber", "Email", "ListingId", "Name" },
                values: new object[,]
                {
                    { 1, "12321411", "12321421", "john@doe.com", 1, "John Doe" },
                    { 2, "12321521", "150912312", "alicedoe@deals.com", 3, "Alice Doe" }
                });

            migrationBuilder.InsertData(
                table: "NonDealerDetails",
                columns: new[] { "NonDealerPropertyId", "ContactNumber", "ListingId", "Name" },
                values: new object[,]
                {
                    { 1, "124521090", 2, "Bob Keen" },
                    { 2, "124520912", 4, "Jane Doe" },
                    { 3, "124098213", 5, "Kim Larwin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DealerDetails",
                keyColumn: "DealerPropertyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DealerDetails",
                keyColumn: "DealerPropertyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NonDealerDetails",
                keyColumn: "NonDealerPropertyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NonDealerDetails",
                keyColumn: "NonDealerPropertyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NonDealerDetails",
                keyColumn: "NonDealerPropertyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarListings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarListings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarListings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarListings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarListings",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
