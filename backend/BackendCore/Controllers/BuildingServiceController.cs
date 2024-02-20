using AutoMapper;
using BackendCore.Utils;
using BackendCore.Utils.ActionFilters;
using BackendCore.Utils.RepositoryExtensions;
using BackendCore.Utils.RequestFeatures.EntityParameters;
using BackendCore.Utils.RequestFeatures.Paging;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.BuildingServiceDTO;

using Shared.TenantDTO;
using System.Text.Json;

namespace BackendCore.Controllers
{
    [Route("api/BuildingServices")]
    [ApiController]
    public class BuildingServiceController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public BuildingServiceController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBuildingServices(
            [FromQuery] BuildingServiceParameter buildingServiceParameters)
        {

            var queryBuildingService = BuildQuery(_context.BuildingServices.AsNoTracking(),
                buildingServiceParameters);

            var pagedBuildingService = await PagedList<BuildingService>.ToPagedListAsync(queryBuildingService,
                buildingServiceParameters.PageNumber, buildingServiceParameters.PageSize);

            var buildingServicesDTO = _mapper.Map<IEnumerable<ReadBuildingServiceDTO>>(pagedBuildingService);   

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagedBuildingService.MetaData));

            return Ok(buildingServicesDTO);
        }

        [HttpGet("{id:guid}", Name = "BuildingServiceById")]
        public async Task<IActionResult> GetBuildingService(Guid id)
        {
            var buildingService = await FindBuildingService(id);

            var buildingServiceDTO = _mapper.Map<ReadBuildingServiceDTO>(buildingService);

            return Ok(buildingServiceDTO);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateBuildingService(
            [FromBody] CreateBuildingServiceDTO createBuildingServiceDTO)
        {
            var createBuildingService = _mapper.Map<BuildingService>(createBuildingServiceDTO);

            await _context.BuildingServices.AddAsync(createBuildingService);
            await _context.SaveChangesAsync();

            var createdBuildingService = _mapper.Map<ReadBuildingServiceDTO>(createBuildingService);

            return CreatedAtRoute("BuildingServiceById", new { id = createBuildingService.Id }, createBuildingService);
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateBuildingService(Guid id,
            [FromBody] UpdateBuildingServiceDTO updateBuildingServiceDTO)
        {
            var buildingService = await FindBuildingService(id);

            _mapper.Map(updateBuildingServiceDTO, buildingService);
            await _context.SaveChangesAsync();

            return Ok("Update successful!");
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateBuildingService(Guid id,
            [FromBody] JsonPatchDocument<UpdateBuildingServiceDTO> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("patchDoc object is null.");
            }

            var buildingService = await FindBuildingService(id);

            var buildingServiceToPatch = _mapper.Map<UpdateBuildingServiceDTO>(buildingService);

            patchDoc.ApplyTo(buildingServiceToPatch, ModelState);

            TryValidateModel(buildingServiceToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _mapper.Map(buildingServiceToPatch, buildingService);
            await _context.SaveChangesAsync();

            return Ok("Partially update successful!");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBuildingService(Guid id)
        {
            var deleteBuildingService = await FindBuildingService(id);

            _context.BuildingServices.Remove(deleteBuildingService);
            await _context.SaveChangesAsync();

            return Ok("Delete successful!");
        }

        private async Task<BuildingService> FindBuildingService(Guid id)
            => await _context.BuildingServices.FindAsync(id)
             ?? throw new BuildingServiceNotFoundException(id);

        private IQueryable<BuildingService> BuildQuery(IQueryable<BuildingService> query,
            BuildingServiceParameter parameters)
        {

            // Search By Name
            if (!string.IsNullOrEmpty(parameters.SearchTerm))
            {
                query = query.Search(parameters.SearchTerm);
            }

            // Sort
            if (!string.IsNullOrEmpty(parameters.OrderBy))
            {
                query = query.Sort(parameters.OrderBy);
            }

            return query;
        }
    }
}
