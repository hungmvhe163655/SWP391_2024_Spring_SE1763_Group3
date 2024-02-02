using AutoMapper;
using Backend.DTOs.HomeManagerDTO;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeManagersController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public HomeManagersController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        // GET: api/HomeManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeManager>>> GetHomeManagers()
        {
            if (_context.HomeManagers == null)
            {
                return NotFound();
            }
            return await _context.HomeManagers
                .Where(hm => !hm.IsDeleted)
                .ToListAsync();
        }

        // GET: api/HomeManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeManager>> GetHomeManager(Guid id)
        {
            if (_context.HomeManagers == null)
            {
                return NotFound();
            }
            var homeManager = await _context.HomeManagers.FindAsync(id);

            if (homeManager == null)
            {
                return NotFound();
            }

            return homeManager;
        }

        // PUT: api/HomeManagers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomeManager(Guid id, UpdateHomeManagerDTO homeManagerDTO)
        {
            if (id != homeManagerDTO.Id)
            {
                return BadRequest();
            }

            HomeManager? homeManager = await _context.HomeManagers.FindAsync(id);

            if (homeManager == null)
            {
                return NotFound();
            }

            _mapper.Map(homeManagerDTO, homeManager);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeManagerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HomeManagers
        [HttpPost]
        public async Task<ActionResult<HomeManager>> PostHomeManager(CreateHomeManagerDTO homeManagerDTO)
        {
            HomeManager homeManager = _mapper.Map<HomeManager>(homeManagerDTO);

            _context.HomeManagers.Add(homeManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomeManager", new { id = homeManager.Id }, homeManager);
        }

        // DELETE: api/HomeManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeManager(Guid id)
        {
            var homeManager = await _context.HomeManagers.FindAsync(id);
            if (homeManager == null)
            {
                return NotFound();
            }

            homeManager.IsDeleted = true;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomeManagerExists(Guid id)
        {
            return (_context.HomeManagers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
