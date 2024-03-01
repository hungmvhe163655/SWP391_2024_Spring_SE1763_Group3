using AutoMapper;
using Azure;
using BackendCore.Utils;
using BackendCore.Utils.ActionFilters;
using BackendCore.Utils.RepositoryExtensions;
using BackendCore.Utils.RequestFeatures;
using BackendCore.Utils.RequestFeatures.EntityParameters;
using BackendCore.Utils.RequestFeatures.Paging;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.NotificationDTO;
using Shared.RequestDTO;
using Shared.TenantDTO;
using System.Text.Json;

namespace BackendCore.Controllers
{
    [Route("api/tenants")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public TenantsController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTenants(
            [FromQuery] TenantParameter tenantParameters)
        {

            var queryTenant = BuildQuery(_context.Tenants.AsNoTracking(),
                tenantParameters);

            var pagedTenant = await PagedList<Tenant>.ToPagedListAsync(queryTenant,
                tenantParameters.PageNumber, tenantParameters.PageSize);

            var tenantsDTO = _mapper.Map<IEnumerable<ReadTenantDTO>>(pagedTenant);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagedTenant.MetaData));

            return Ok(tenantsDTO);
        }

        [HttpGet("{id}", Name = "TenantById")]
        public async Task<IActionResult> GetTenant(string id)
        {
            var tenant = await FindTenant(id);

            var tenantDTO = _mapper.Map<ReadTenantDTO>(tenant);

            return Ok(tenantDTO);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateTenant(
            [FromBody] CreateTenantDTO createTenantDTO)
        {
            var createTenant = _mapper.Map<Tenant>(createTenantDTO);

            await _context.Tenants.AddAsync(createTenant);
            await _context.SaveChangesAsync();

            var createdTenant = _mapper.Map<ReadTenantDTO>(createTenant);

            return CreatedAtRoute("TenantById", new { id = createdTenant.Id }, createdTenant);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateTenant(string id,
            [FromBody] UpdateTenantDTO updateTenantDTO)
        {
            var tenant = await FindTenant(id);

            _mapper.Map(updateTenantDTO, tenant);
            await _context.SaveChangesAsync();

            return Ok("Update successful!");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateTenant(string id,
            [FromBody] JsonPatchDocument<UpdateTenantDTO> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("patchDoc object is null.");
            }

            var tenant = await FindTenant(id);

            var tenantToPatch = _mapper.Map<UpdateTenantDTO>(tenant);

            patchDoc.ApplyTo(tenantToPatch, ModelState);

            TryValidateModel(tenantToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _mapper.Map(tenantToPatch, tenant);
            await _context.SaveChangesAsync();

            return Ok("Partially update successful!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenant(string id)
        {
            var deleteTenant = await FindTenant(id);

            _context.Tenants.Remove(deleteTenant);
            await _context.SaveChangesAsync();

            return Ok("Delete successful!");
        }

        [HttpGet("{id}/notifications")]
        public async Task<IActionResult> GetTenantNotifications(string id, [FromQuery] RequestParameters tenantParameters)
        {
            var tenant = await _context.Tenants
                .Include(t => t.Notifications)
                .FirstOrDefaultAsync(t => t.Id == id)
                ?? throw new TenantNotFoundException(id);

            var pagedNotifications = ChangeToPagedList(tenant.Notifications, tenantParameters);

            var notificationsDTO = _mapper
                .Map<IEnumerable<ReadNotificationDTO>>(pagedNotifications);

            return Ok(notificationsDTO);
        }

        [HttpGet("{id}/requests")]
        public async Task<IActionResult> GetTenantRequests(string id, [FromQuery] RequestParameters tenantParameters)
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

            var pagedRequests = ChangeToPagedList(tenant.Requests, tenantParameters);

            var requestsDTO = _mapper
                .Map<IEnumerable<ReadRequestDTO>>(pagedRequests);


            return Ok(requestsDTO);
        }

        private async Task<Tenant> FindTenant(string id)
            => await _context.Tenants.FindAsync(id)
             ?? throw new TenantNotFoundException(id);

        private IQueryable<Tenant> BuildQuery(IQueryable<Tenant> query,
            TenantParameter parameters)
        {
            // Filter Gender
            if (parameters.IsMale != null)
            {
                query = query.FilterGender(parameters.IsMale);
            }

            // Filter Created Date
            if (parameters.StartCreatedDate != null && parameters.EndCreatedDate != null)
            {
                if (!parameters.ValidDateRange)
                {
                    throw new DateRangeBadRequestException();
                }

                query = query.FilterCreatedDate(parameters.StartCreatedDate,
                    parameters.EndCreatedDate);
            }

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

        private PagedList<T> ChangeToPagedList<T>(ICollection<T> list, 
            RequestParameters requestParameters)
        {

            requestParameters.OrderBy ??= "CreatedDate";

            var pagedList = new PagedList<T>(list.ToList(), list.Count,
                 requestParameters.PageNumber, requestParameters.PageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagedList.MetaData));

            return pagedList;

        }
    }
}
