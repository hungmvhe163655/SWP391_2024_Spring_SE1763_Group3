using AutoMapper;
using Backend.DTOs.BillStatusDTO;
using Backend.DTOs.BuildingServiceDTO;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


/**
 * Controller handling operations related to Building Services.
 * Provides endpoints to CRUD Building Service.
 * 
 * @author LongNCB
 */

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingServiceController : ControllerBase
    {
        // Inject service
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public BuildingServiceController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/BuildingService
        [HttpGet]
        public ActionResult<IEnumerable<BuildingService>> Get()
        {
            return Ok(_context.BuildingServices.ToList());
        }

        // GET: api/BuildingService/id
        [HttpGet("{id}")]
        public ActionResult<BuildingService> Get(int id)
        {

            BuildingService? buildingService = _context.BuildingServices.FirstOrDefault(x => x.Id == id);

            if (buildingService == null)
            {
                return NotFound("Building Service not found!");
            }

            return Ok(buildingService);
        }

        // POST: api/BuildingService
        [HttpPost]
        public ActionResult Post(CreateBuildingServiceDTO buildingServiceDTO)
        {
            try
            {
                BuildingService buildingService = _mapper.Map<BuildingService>(buildingServiceDTO);

                _context.BuildingServices.Add(buildingService);

                _context.SaveChanges();

                return Ok("Save successfully !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/BuildingService/id
        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateBuildingServiceDTO buildingServiceDTO)
        {
            // Check if Id is correct
            if (id != buildingServiceDTO.Id)
            {
                return BadRequest();
            }

            // Find in Database object with id 
            BuildingService? buildingService = _context.BuildingServices.FirstOrDefault(bs => bs.Id == id);

            // Not found will return 404
            if (buildingService == null)
            {
                return NotFound("Building Service not found!");
            }

            // Map DTO to model class
            _mapper.Map(buildingServiceDTO, buildingService);

            _context.Entry(buildingService).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok("Update successfully!");
        }

        // DELETE: api/BuildingService/{id} 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleteBuildingService = _context.BuildingServices.FirstOrDefault(b => b.Id == id);

            // If not found Bill Status
            if (deleteBuildingService == null)
            {
                return NotFound("Bill status not found!");
            }

            _context.BuildingServices.Remove(deleteBuildingService);
            _context.SaveChanges();

            return Ok("Deleted successfully!");
        }
    }
}
