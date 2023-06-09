using Microsoft.EntityFrameworkCore;
using OffsureAssessment.Context;
using OffsureAssessment.Model;

namespace OffsureAssessment.Services
{
    public class ListingRepository<T> : IListingRepository<T> where T : class, IListing
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbEntitySet;

        public ListingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbEntitySet = dbContext.Set<T>();
        }

        public virtual async void AddListing(T newListing)
        {
            await _dbEntitySet.AddAsync(newListing);
        }

        public virtual IEnumerable<T> GetAllListings()
        {
            return _dbEntitySet.Include(cl => cl.NonDealerDetails)
                                .Include(cl => cl.DealerDetails)
                                .ToList();
        }

        public virtual async Task<T> FindListing(int id)
        {
            return await _dbEntitySet.Include(cl => cl.NonDealerDetails).Include(cl => cl.DealerDetails).FirstOrDefaultAsync(cl => cl.Id == id);
        }

        public void UpdateListing(T entityToUpdate)
        {
            _dbContext.Update(entityToUpdate);
        }

        public async Task RemoveListing(int id)
        {
            var entity = await _dbEntitySet.FirstOrDefaultAsync(cl => cl.Id == id);
            if (entity != null)
            {
                _dbEntitySet.Remove(entity);
            }
        }
    }
}
