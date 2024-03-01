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
using Shared.RequestStatusDTO;
using System.Text.Json;

namespace BackendCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestStatusesController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public RequestStatusesController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRequestStatuses()
        {
            var requestStatuses = await _context.RequestStatuses.ToListAsync(); 

            var requestStatusesDTO = _mapper.Map<IEnumerable<ReadRequestStatusDTO>>(requestStatuses); 

            return Ok(requestStatusesDTO);
        }




        [HttpGet("{id:int}", Name = "RequestStatusById")]
        public async Task<IActionResult> GetRequestStatus(int id)
        {
            var requestStatus = await FindRequestStatus(id);

            var requestStatusDTO = _mapper.Map<ReadRequestStatusDTO>(requestStatus);

            return Ok(requestStatusDTO);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateRequestStatus(
            [FromBody] CreateRequestStatusDTO createRequestStatusDTO)
        {
            var createRequestStatus = _mapper.Map<RequestStatus>(createRequestStatusDTO);

            await _context.RequestStatuses.AddAsync(createRequestStatus);
            await _context.SaveChangesAsync();

            var createdRequestStatus = _mapper.Map<ReadRequestStatusDTO>(createRequestStatus);

            return CreatedAtRoute("RequestStatusById", new { id = createdRequestStatus.Id }, createdRequestStatus);
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateRequestStatus(int id,
            [FromBody] UpdateRequestStatusDTO updateRequestStatusDTO)
        {
            var requestStatus = await FindRequestStatus(id);

            _mapper.Map(updateRequestStatusDTO, requestStatus);
            await _context.SaveChangesAsync();

            return Ok("Update successful!");
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateRequestStatus(int id,
            [FromBody] JsonPatchDocument<UpdateRequestStatusDTO> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("patchDoc object is null.");
            }

            var requestStatus = await FindRequestStatus(id);

            var requestStatusToPatch = _mapper.Map<UpdateRequestStatusDTO>(requestStatus);

            patchDoc.ApplyTo(requestStatusToPatch, ModelState);

            TryValidateModel(requestStatusToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _mapper.Map(requestStatusToPatch, requestStatus);
            await _context.SaveChangesAsync();

            return Ok("Partially update successful!");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRequestStatus(int id)
        {
            var DeleteRequestStatus = await FindRequestStatus(id);

            _context.RequestStatuses.Remove(DeleteRequestStatus);
            await _context.SaveChangesAsync();

            return Ok("Delete successful!");
        }

        private async Task<RequestStatus> FindRequestStatus(int id)
            => await _context.RequestStatuses.FindAsync(id)
             ?? throw new RequestStatusNotFoundException(id);

        
    }
}

