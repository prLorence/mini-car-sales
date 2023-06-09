using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OffsureAssessment.DTO;
using OffsureAssessment.Model;
using OffsureAssessment.Services;

namespace OffsureAssessment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarListingController : ControllerBase
    {
        private readonly ILogger<CarListingController> _logger;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarListingController(ILogger<CarListingController> logger, UnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ObjectResult All()
        {
            IEnumerable<CarListing> dataStoreEntities = _unitOfWork.CarListingRepository.GetAllListings();
            List<CarListingDTO> dtoCollection = _mapper.Map<List<CarListingDTO>>(dataStoreEntities);
            return StatusCode(200, dtoCollection);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CarListingDTO input)
        {
            if (!ModelState.IsValid)
            {
                ValidationProblemDetails details = new(ModelState)
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    Status = StatusCodes.Status400BadRequest
                };

                _logger.LogInformation(details.Detail);

                return new BadRequestObjectResult(details);
            }

            try
            {
                CarListing newCarListing = _mapper.Map<CarListing>(input);

                _unitOfWork.CarListingRepository.AddListing(newCarListing);
                _unitOfWork.Save();

                _logger.LogInformation("Listing created successfully");

                return StatusCode(201);
            }
            catch (Exception e)
            {
                ProblemDetails exceptionDetails = new()
                {
                    Detail = e.Message,
                    Status = StatusCodes.Status500InternalServerError,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
                };
                _logger.LogInformation(exceptionDetails.Detail);
                return StatusCode(StatusCodes.Status500InternalServerError, exceptionDetails);
            }
        }

        [HttpGet]
        public async Task<CarListing> Find([FromQuery] int id)
        {
            return await _unitOfWork.CarListingRepository.FindListing(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
                [FromQuery] int id,
                [FromBody] CarListingUpdateDTO updateContent)
        {
            try
            {
                var listingFromRepository = await _unitOfWork.CarListingRepository.FindListing(id);
                if (listingFromRepository != null)
                {
                    CarListing updatedListing = _mapper.Map(updateContent, listingFromRepository);
                    _unitOfWork.CarListingRepository.UpdateListing(updatedListing);
                    _unitOfWork.Save();
                    _logger.LogInformation($"Listing with an id {id} updated successfully.");
                    return StatusCode(200);
                }

                _logger.LogInformation($"Listing with an id {id} doesn't exist in the records.'");
                return StatusCode(404);
            }
            catch (Exception e)
            {
                ProblemDetails exceptionDetails = new()
                {
                    Detail = e.Message,
                    Status = StatusCodes.Status500InternalServerError,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
                };
                _logger.LogInformation(exceptionDetails.Detail);
                return StatusCode(StatusCodes.Status500InternalServerError, exceptionDetails);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] int id)
        {
            try
            {
                CarListing listingFromRepository = await _unitOfWork.CarListingRepository.FindListing(id);

                if (listingFromRepository != null)
                {
                    await _unitOfWork.CarListingRepository.RemoveListing(listingFromRepository.Id);
                    _unitOfWork.Save();

                    return StatusCode(204);
                }
                _logger.LogInformation($"Listing with an id {id} updated successfully.");
                return StatusCode(404);
            }
            catch (Exception e)
            {
                ProblemDetails exceptionDetails = new()
                {
                    Detail = e.Message,
                    Status = StatusCodes.Status500InternalServerError,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
                };
                _logger.LogInformation(exceptionDetails.Detail);
                return StatusCode(StatusCodes.Status500InternalServerError, exceptionDetails);
            }
        }
    }
}
