using AutoMapper;
using BackendCore.Utils;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.NotificationDTO;
using Shared.TenantDTO;

namespace BackendCore.Controllers
{
    [Route("api/tenants")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public TenantController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTenants()
        {
            var tenants = await _context.Tenants.ToListAsync();

            var tenantsDTO = _mapper.Map<IEnumerable<ReadTenantDTO>>(tenants);

            return Ok(tenantsDTO);
        }

        [HttpGet("{id:guid}", Name = "TenantById")]
        public async Task<IActionResult> GetTenant(Guid id)
        {
            var tenant = await _context.Tenants.FindAsync(id)
                ?? throw new TenantNotFoundException(id);

            var tenantDTO = _mapper.Map<ReadTenantDTO>(tenant);

            return Ok(tenantDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTenant(
            [FromBody] CreateTenantDTO createTenantDTO)
        {
            if (createTenantDTO is null)
            {
                return BadRequest("Tenant object is null!");
            }

            var createTenant = _mapper.Map<Tenant>(createTenantDTO);

            await _context.Tenants.AddAsync(createTenant);
            await _context.SaveChangesAsync();

            var createdTenant = _mapper.Map<ReadTenantDTO>(createTenant);

            return CreatedAtRoute("TenantById", new { id = createdTenant.Id }, createdTenant);
        }

        [HttpGet("{id:guid}/notifications")]
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
    }
}
