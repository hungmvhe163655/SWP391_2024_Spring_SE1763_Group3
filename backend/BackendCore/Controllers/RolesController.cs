using Microsoft.AspNetCore.Mvc;
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
using Shared.RoleDTO;
using System.Text.Json;
using Shared.TenantDTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BackendCore.Controllers
{
    // API controller for managing roles
    [Route("api/role")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        // Constructor injecting database context and AutoMapper
        public RolesController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/role
        // Retrieves a list of roles based on query parameters
        [HttpGet]
        public async Task<IActionResult> GetRoles(
            [FromQuery] RoleParameter roleParameters)
        {
            // Build query based on parameters
            var queryRole = BuildQuery(_context.Roles.AsNoTracking(),
                roleParameters);

            // Paginate the results
            var pagedRole = await PagedList<Role>.ToPagedListAsync(queryRole,
                roleParameters.PageNumber, roleParameters.PageSize);

            // Map the roles to DTOs
            var RoleDTO = _mapper.Map<IEnumerable<ReadRoleDTO>>(pagedRole);

            // Add pagination metadata to response headers
            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagedRole.MetaData));

            return Ok(RoleDTO);
        }

        // GET: api/role/{id}
        // Retrieves a role by its ID
        [HttpGet("{id:int}", Name = "RoleById")]
        public async Task<IActionResult> GetRole(int id)
        {
            // Find role by ID
            var role = await FindRole(id);

            // Map role to DTO
            var roleDTO = _mapper.Map<ReadRoleDTO>(role);

            return Ok(roleDTO);
        }

        // POST: api/role
        // Creates a new role
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateRole(
            [FromBody] CreateRoleDTO createRoleDTO)
        {
            // Map DTO to entity
            var role = _mapper.Map<Role>(createRoleDTO);

            // Add role to database
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            // Map created role to DTO
            var createdRole = _mapper.Map<ReadRoleDTO>(role);

            // Return 201 Created response with created role DTO
            return CreatedAtRoute("RoleById", new { id = createdRole.Id }, createdRole);
        }

        // PUT: api/role/{id}
        // Updates an existing role
        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateRole(int id,
            [FromBody] UpdateRoleDTO updateRoleDTO)
        {
            // Find role by ID
            var role = await FindRole(id);

            // Map updated data to existing role entity
            _mapper.Map(updateRoleDTO, role);

            // Save changes to database
            await _context.SaveChangesAsync();

            // Return success message
            return Ok("Update successful!");
        }

        // Helper method to find a role by ID
        private async Task<Role> FindRole(int id)
            => await _context.Roles.FindAsync(id)
             ?? throw new RoleNotFoundException(id);

        // Helper method to build query based on parameters
        private IQueryable<Role> BuildQuery(IQueryable<Role> query, RoleParameter parameters)
        {
            if (!string.IsNullOrEmpty(parameters.SearchTerm))
            {
                // Filter roles by name if search term is provided
                query = query.Where(r => r.Name.Contains(parameters.SearchTerm));
            }
            return query;
        }
    }
}
