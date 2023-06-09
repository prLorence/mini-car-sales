using Microsoft.EntityFrameworkCore;
using OffsureAssessment.Model;

namespace OffsureAssessment.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<CarListing> CarListings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarListing>()
                .HasOne(cl => cl.NonDealerDetails)
                .WithOne(p => p.CarListing)
                .HasForeignKey<NonDealerDetails>(p => p.ListingId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired(false);


            modelBuilder.Entity<CarListing>()
                .HasOne(cl => cl.DealerDetails)
                .WithOne(p => p.CarListing)
                .HasForeignKey<DealerDetails>(p => p.ListingId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired(false);

            // Seed data
            modelBuilder.Entity<CarListing>().HasData(
                new CarListing
                {
                    Id = 1,
                    Year = "2002",
                    Make = "Toyota",
                    Model = "Vios",
                    Comments = "This is a reliable car.",
                    DriveAwayPrice = 2000.50,
                    ExcludingGovernmentCharges = 0,
                },
                new CarListing
                {
                    Id = 2,
                    Year = "2018",
                    Make = "Honda",
                    Model = "City",
                    Comments = "Bought this one 2 years ago.",
                    DriveAwayPrice = 0,
                    ExcludingGovernmentCharges = 2005.12
                },
                new CarListing
                {
                    Id = 3,
                    Year = "2023",
                    Make = "Ford",
                    Model = "Raptor",
                    Comments = "Condition's 10/10'",
                    DriveAwayPrice = 5000.10,
                    ExcludingGovernmentCharges = 0,
                },
                new CarListing
                {
                    Id = 4,
                    Year = "2023",
                    Make = "Toyota",
                    Model = "Corolla Altis",
                    Comments = "Used for work commutes",
                    DriveAwayPrice = 0,
                    ExcludingGovernmentCharges = 1500.50,
                },
                new CarListing
                {
                    Id = 5,
                    Year = "2017",
                    Make = "Honda",
                    Model = "Civic",
                    Comments = "Contact me for more details",
                    DriveAwayPrice = 1750.50,
                    ExcludingGovernmentCharges = 0,
                }
            );

            modelBuilder.Entity<DealerDetails>().HasData(
                new DealerDetails
                {
                    DealerPropertyId = 1,
                    ListingId = 1,
                    Name = "John Doe",
                    ContactNumber = "12321421",
                    Email = "john@doe.com",
                    ABN = "12321411"
                },
                new DealerDetails
                {
                    DealerPropertyId = 2,
                    ListingId = 3,
                    Name = "Alice Doe",
                    ContactNumber = "150912312",
                    Email = "alicedoe@deals.com",
                    ABN = "12321521"
                }
            );

            modelBuilder.Entity<NonDealerDetails>().HasData(
                new NonDealerDetails
                {
                    NonDealerPropertyId = 1,
                    ListingId = 2,
                    Name = "Bob Keen",
                    ContactNumber = "124521090",
                },
                new NonDealerDetails
                {
                    NonDealerPropertyId = 2,
                    ListingId = 4,
                    Name = "Jane Doe",
                    ContactNumber = "124520912",
                },
                new NonDealerDetails
                {
                    NonDealerPropertyId = 3,
                    ListingId = 5,
                    Name = "Kim Larwin",
                    ContactNumber = "124098213",
                }
            );
        }
    }
}
