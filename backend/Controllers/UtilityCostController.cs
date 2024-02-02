using AutoMapper;
using Backend.DTOs.UtilityCostDTO;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 * Controller handling operations related to Utility Costs.
 * Provides endpoints to CRUD Utility Costs.
 * 
 * @author PhuVD
 */

namespace Backend.Controllers
{
    // Inject service
    [ApiController]
    [Route("api/[controller]")]
    public class UtilityCostsController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public UtilityCostsController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        // GET: api/UtilityCosts
        [HttpGet]
        public ActionResult<IEnumerable<UtilityCost>> Get()
        {
            return Ok(_context.UtilityCosts.ToList());
        }

        // GET: api/UtilityCosts/{id}
        [HttpGet("{id}")]
        public ActionResult<UtilityCost> Get(Guid id)
        {
            UtilityCost? utilityCost = _context.UtilityCosts.FirstOrDefault(x => x.Id == id);

            if (utilityCost == null)
            {
                return NotFound("Utility Cost not found!");
            }

            return Ok(utilityCost);
        }

        // POST: api/UtilityCosts
        [HttpPost]
        public ActionResult<UtilityCost> Post(CreateUtilityCostDTO utilityCostDTO)
        {
            try
            {
                UtilityCost utilityCost = _mapper.Map<UtilityCost>(utilityCostDTO);

                _context.UtilityCosts.Add(utilityCost);

                _context.SaveChanges();

                return Ok("Save successfully !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/RequestTypes/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateUtilityCostDTO utilityCostUpdateDTO)
        {
            // Check if Id is correct
            if (id != utilityCostUpdateDTO.Id)
            {
                return BadRequest();
            }

            // Find in Database object with id 
            UtilityCost utilityCost = _context.UtilityCosts.FirstOrDefault(rt => rt.Id == id);

            // Not found will return 404
            if (utilityCost == null)
            {
                return NotFound("Utility Cost not found!");
            }

            // Map DTO to model class
            _mapper.Map(utilityCostUpdateDTO, utilityCost);

            _context.Entry(utilityCost).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok("Update successfully!");
        }

        // DELETE: api/UtilityCosts/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var deleteUtilityCost = _context.UtilityCosts.FirstOrDefault(r => r.Id == id);
            // If not found Utility Cost
            if (deleteUtilityCost == null)
            {
                return NotFound("Utility Cost not found!");
            }

            _context.UtilityCosts.Remove(deleteUtilityCost);
            _context.SaveChanges();

            return Ok("Delete successfully!");
        }
    }
}