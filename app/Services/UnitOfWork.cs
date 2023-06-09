using Microsoft.EntityFrameworkCore;
using OffsureAssessment.Context;
using OffsureAssessment.Model;

namespace OffsureAssessment.Services
{
    public class UnitOfWork : IDisposable
    {
        private IDbContextFactory<ApplicationDbContext>? _contextFactory;
        private ApplicationDbContext? _context;
        private ListingRepository<CarListing>? _carListingRepository;

        public UnitOfWork(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
            EnsureContextInitialized();
        }

        public ListingRepository<CarListing> CarListingRepository
        {
            get
            {
                EnsureContextInitialized();
                return _carListingRepository ?? throw new InvalidOperationException("UnitOfWork has not been properly initialized.");
            }
        }

        public void Save()
        {
            EnsureContextInitialized();
            _context.SaveChanges();
        }

        private bool _disposed;

        private void EnsureContextInitialized()
        {
            if (_context == null)
            {
                _context = _contextFactory.CreateDbContext();
                _carListingRepository = new ListingRepository<CarListing>(_context);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
