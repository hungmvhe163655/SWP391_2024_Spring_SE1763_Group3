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
using Shared.NotificationDTO;
using Shared.RequestDTO;
using Shared.RequestTypeDTO;
using System.Text.Json;

namespace BackendCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTypesController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public RequestTypesController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRequestTypes(
            [FromQuery] RequestTypeParameter requestTypeParameters)
        {

            var queryRequestType = BuildQuery(_context.RequestTypes.AsNoTracking(),
                requestTypeParameters);

            var pageRequestType = await PagedList<RequestType>.ToPagedListAsync(queryRequestType,
                requestTypeParameters.PageNumber, requestTypeParameters.PageSize);

            var requestTypesDTO = _mapper.Map<IEnumerable<ReadRequestTypeDTO>>(pageRequestType);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pageRequestType.MetaData));

            return Ok(requestTypesDTO);
        }



        [HttpGet("{id:guid}", Name = "RequestTypeById")]
        public async Task<IActionResult> GetRequestType(Guid id)
        {
            var requestType = await FindRequestType(id);

            var requestTypeDTO = _mapper.Map<ReadRequestTypeDTO>(requestType);

            return Ok(requestTypeDTO);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateRequestType(
            [FromBody] CreateRequestTypeDTO createRequestTypeDTO)
        {
            var createRequestType = _mapper.Map<RequestType>(createRequestTypeDTO);

            await _context.RequestTypes.AddAsync(createRequestType);
            await _context.SaveChangesAsync();

            var createdRequestType = _mapper.Map<ReadRequestTypeDTO>(createRequestType);

            return CreatedAtRoute("RequestTypeById", new { id = createdRequestType.Id }, createdRequestType);
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateRequestType(Guid id,
            [FromBody] UpdateRequestTypeDTO updateRequestTypeDTO)
        {
            var requestType = await FindRequestType(id);

            _mapper.Map(updateRequestTypeDTO, requestType);
            await _context.SaveChangesAsync();

            return Ok("Update successful!");
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateRequestType(Guid id,
            [FromBody] JsonPatchDocument<UpdateRequestTypeDTO> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("patchDoc object is null.");
            }

            var requestType = await FindRequestType(id);

            var requestTypeToPatch = _mapper.Map<UpdateRequestTypeDTO>(requestType);

            patchDoc.ApplyTo(requestTypeToPatch, ModelState);

            TryValidateModel(requestTypeToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _mapper.Map(requestTypeToPatch, requestType);
            await _context.SaveChangesAsync();

            return Ok("Partially update successful!");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRequestType(Guid id)
        {
            var DeleteRequestType = await FindRequestType(id);

            _context.RequestTypes.Remove(DeleteRequestType);
            await _context.SaveChangesAsync();

            return Ok("Delete successful!");
        }

        [HttpGet("{id:guid}/notifications")]
        public async Task<IActionResult> GetRequestTypeNotifications(Guid id)
        {
            var requestType = await _context.RequestTypes
                .Include(rs => rs.Notifications)
                .FirstOrDefaultAsync(t => t.Id == id)
                ?? throw new RequestTypeNotFoundException(id);

            var notificationsDTO = _mapper
                .Map<IEnumerable<ReadNotificationDTO>>(requestType.Notifications);

            return Ok(notificationsDTO);
        }

        [HttpGet("{id:guid}/requests")]
        public async Task<IActionResult> GetRequestTypeRequests(Guid id)
        {
            var requestType = await _context.RequestTypes
                .SingleOrDefaultAsync(rs => rs.Id == id)
                ?? throw new RequestTypeNotFoundException(id);

            await _context.Entry(requestType)
                .Collection(t => t.Requests)
                .Query()
                .Include(r => r.RequestStatus)
                .Include(r => r.RequestType)
                .LoadAsync();

            // Multiple round trip which will cause performance issues,
            // will adjust later
            foreach (var request in requestType.Requests)
                await _context.Entry(request).Reference(r => r.HomeManager).LoadAsync();

            var requestsDTO = _mapper
                .Map<IEnumerable<ReadRequestDTO>>(requestType.Requests);

            return Ok(requestsDTO);
        }

        private async Task<RequestType> FindRequestType(Guid id)
            => await _context.RequestTypes.FindAsync(id)
             ?? throw new RequestTypeNotFoundException(id);

        private IQueryable<RequestType> BuildQuery(IQueryable<RequestType> query,
            RequestTypeParameter parameters)
        {

            return query;
        }
    }
}

