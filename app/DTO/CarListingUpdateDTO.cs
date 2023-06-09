namespace OffsureAssessment.DTO
{
    public class CarListingUpdateDTO
    {
        public string? Comments { get; set; } = string.Empty;

        public double? DriveAwayPrice { get; set; }
        public double? ExcludingGovernmentCharges { get; set; }
    }
}
