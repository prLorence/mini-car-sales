namespace OffsureAssessment.Services
{
    public interface IListingRepository<T> where T : class
    {
        void AddListing(T newListing);
        IEnumerable<T> GetAllListings();
        Task<T> FindListing(int id);
        void UpdateListing(T entityToUpdate);
        Task RemoveListing(int id);
    }
}
