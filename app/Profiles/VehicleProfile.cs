using AutoMapper;
using OffsureAssessment.DTO;
using OffsureAssessment.Model;

namespace OffsureAssessment.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<CarListing, CarListingDTO>().PreserveReferences();
            CreateMap<CarListingDTO, CarListing>().PreserveReferences();

            CreateMap<NonDealerDetails, NonDealerDetailsDTO>().PreserveReferences();
            CreateMap<NonDealerDetailsDTO, NonDealerDetails>().PreserveReferences();

            CreateMap<DealerDetails, DealerDetailsDTO>().PreserveReferences();
            CreateMap<DealerDetailsDTO, DealerDetails>().PreserveReferences();

            // CreateMap<CarListing, CarListingUpdateDTO>().PreserveReferences()
            // public string? Comments { get; set; } = string.Empty;

            // public double? DriveAwayPrice { get; set; }
            // public double? ExcludingGovernmentCharges { get; set; }

            CreateMap<CarListingUpdateDTO, CarListing>().PreserveReferences()
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
            .ForMember(dest => dest.DriveAwayPrice, opt => opt.MapFrom(src => src.DriveAwayPrice))
            .ForMember(dest => dest.ExcludingGovernmentCharges, opt => opt.MapFrom(src => src.ExcludingGovernmentCharges));

        }
    }
}
