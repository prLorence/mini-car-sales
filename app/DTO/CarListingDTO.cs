using System.ComponentModel.DataAnnotations;

namespace OffsureAssessment.DTO
{
    public class CarListingDTO
    {
        public int Id { get; set; }

        [Required]
        public string Year { get; set; } = null!;

        [Required]
        public string Make { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;
        public string? Comments { get; set; } = string.Empty;

        public double? DriveAwayPrice { get; set; }
        public double? ExcludingGovernmentCharges { get; set; }

        public NonDealerDetailsDTO? NonDealerDetails { get; set; }

        public DealerDetailsDTO? DealerDetails { get; set; }
    }
}
