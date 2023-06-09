using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OffsureAssessment.Model
{
    public class NonDealerDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NonDealerPropertyId { get; set; }

        public string? Name { get; set; } = string.Empty;
        public string? ContactNumber { get; set; } = string.Empty;

        public int? ListingId { get; set; }
        public CarListing? CarListing { get; set; }
    }
}
