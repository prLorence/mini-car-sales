namespace OffsureAssessment.Model
{
    public interface IListing
    {
        public int Id { get; set; }
        public NonDealerDetails? NonDealerDetails { get; set; }
        public DealerDetails? DealerDetails { get; set; }
    }
}
