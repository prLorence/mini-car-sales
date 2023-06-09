using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OffsureAssessment.Model
{
    public class CarListing : IListing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Year { get; set; } = string.Empty;
        public string? Make { get; set; } = string.Empty;
        public string? Model { get; set; } = string.Empty;
        public string? Comments { get; set; } = string.Empty;

        public double DriveAwayPrice { get; set; }
        public double ExcludingGovernmentCharges { get; set; }

        public NonDealerDetails? NonDealerDetails { get; set; }
        public DealerDetails? DealerDetails { get; set; }
    }
}
