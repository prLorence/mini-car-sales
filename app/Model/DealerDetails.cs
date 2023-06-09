using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OffsureAssessment.Model
{
    public class DealerDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DealerPropertyId { get; set; }

        public string? Name { get; set; } = string.Empty;
        public string? ContactNumber { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? ABN { get; set; } = string.Empty;

        public int? ListingId { get; set; }
        public CarListing? CarListing { get; set; }
    }
}
