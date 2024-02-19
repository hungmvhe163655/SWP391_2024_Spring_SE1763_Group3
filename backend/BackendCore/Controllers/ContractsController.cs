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
using Shared.ContractDTO;
using System.Text.Json;

namespace BackendCore.Controllers
{
    [Route("api/Contracts")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public ContractsController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetContracts(
            [FromQuery] ContractParameter contractParameters)
        {

            var queryContract = BuildQuery(_context.Contracts.AsNoTracking(),
                contractParameters);

            var pagedContract = await PagedList<Contract>.ToPagedListAsync(queryContract,
                contractParameters.PageNumber, contractParameters.PageSize);

            var contractsDTO = _mapper.Map<IEnumerable<ReadContractDTO>>(pagedContract);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagedContract.MetaData));

            return Ok(contractsDTO);
        }

        [HttpGet("{id:guid}", Name = "ContractById")]
        public async Task<IActionResult> GetContract(Guid id)
        {
            var contract = await FindContract(id);

            var contractDTO = _mapper.Map<ReadContractDTO>(contract);

            return Ok(contractDTO);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateContract(
            [FromBody] CreateContractDTO createContractDTO)
        {
            var createContract = _mapper.Map<Contract>(createContractDTO);

            await _context.Contracts.AddAsync(createContract);
            await _context.SaveChangesAsync();

            var createdContract = _mapper.Map<ReadContractDTO>(createContract);

            return CreatedAtRoute("ContractById", new { id = createdContract.Id }, createdContract);
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateContract(Guid id,
            [FromBody] UpdateContractDTO updateContractDTO)
        {
            var contract = await FindContract(id);

            _mapper.Map(updateContractDTO, contract);
            await _context.SaveChangesAsync();

            return Ok("Update successful!");
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateContract(Guid id,
            [FromBody] JsonPatchDocument<UpdateContractDTO> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("patchDoc object is null.");
            }

            var contract = await FindContract(id);

            var contractToPatch = _mapper.Map<UpdateContractDTO>(contract);

            patchDoc.ApplyTo(contractToPatch, ModelState);

            TryValidateModel(contractToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _mapper.Map(contractToPatch, contract);
            await _context.SaveChangesAsync();

            return Ok("Partially update successful!");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteContract(Guid id)
        {
            var deleteContract = await FindContract(id);

            _context.Contracts.Remove(deleteContract);
            await _context.SaveChangesAsync();

            return Ok("Delete successful!");
        }

        /*[HttpGet("{id:guid}/notifications")]
        public async Task<IActionResult> GetTenantNotifications(Guid id)
        {
            var tenant = await _context.Tenants
                .Include(t => t.Notifications)
                .FirstOrDefaultAsync(t => t.Id == id)
                ?? throw new TenantNotFoundException(id);

            var notificationsDTO = _mapper
                .Map<IEnumerable<ReadNotificationDTO>>(tenant.Notifications);

            return Ok(notificationsDTO);
        }

        [HttpGet("{id:guid}/requests")]
        public async Task<IActionResult> GetTenantRequests(Guid id)
        {
            var tenant = await _context.Tenants
                .SingleOrDefaultAsync(t => t.Id == id)
                ?? throw new TenantNotFoundException(id);

            await _context.Entry(tenant)
                .Collection(t => t.Requests)
                .Query()
                .Include(r => r.RequestStatus)
                .Include(r => r.RequestType)
                .LoadAsync();

            // Multiple round trip which will cause performance issues,
            // will adjust later
            foreach (var request in tenant.Requests)
                await _context.Entry(request).Reference(r => r.HomeManager).LoadAsync();

            var requestsDTO = _mapper
                .Map<IEnumerable<ReadRequestDTO>>(tenant.Requests);

            return Ok(requestsDTO);
        }*/

        private async Task<Contract> FindContract(Guid id)
            => await _context.Contracts.FindAsync(id)
             ?? throw new ContractNotFoundException(id);

        private IQueryable<Contract> BuildQuery(IQueryable<Contract> query,
            ContractParameter parameters)
        {

            return query;
        }
    }
}
