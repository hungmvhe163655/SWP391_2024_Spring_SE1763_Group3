using AutoMapper;
using Backend.DTOs.ContractDTO;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 * Controller handling operations related to Contracts.
 * Provides endpoints to CRUD Contracts.
 * 
 * @author PhuVD
 */

namespace Backend.Controllers
{
    // Inject service
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public ContractsController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        // GET: api/Contracts
        [HttpGet]
        public ActionResult<IEnumerable<Contract>> Get()
        {
            return Ok(_context.Contracts.ToList());
        }

        // GET: api/Contracts/{id}
        [HttpGet("{id}")]
        public ActionResult<Contract> Get(Guid id)
        {
            Contract? contract = _context.Contracts.FirstOrDefault(x => x.Id == id);

            if (contract == null)
            {
                return NotFound("Contract not found!");
            }

            return Ok(contract);
        }

        // POST: api/Contracts
        [HttpPost]
        public ActionResult<Contract> Post(CreateContractDTO contractDTO)
        {
            try
            {
                Contract contract = _mapper.Map<Contract>(contractDTO);
                contract.CreatedAt = DateTime.UtcNow;

                _context.Contracts.Add(contract);

                _context.SaveChanges();

                return Ok("Save successfully !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Contracts/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateContractDTO contractUpdateDTO)
        {
            // Check if Id is correct
            /*if (id != contractUpdateDTO.Id)
            {
                return BadRequest();
            }*/

            // Find in Database object with id 
            Contract contract = _context.Contracts.FirstOrDefault(x => x.Id == id);

            // Not found will return 404
            if (contract == null)
            {
                return NotFound("Contract not found!");
            }

            // Map DTO to model class
            _mapper.Map(contractUpdateDTO, contract);
            contract.UpdatedAt = DateTime.UtcNow;

            _context.Entry(contract).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok("Update successfully!");
        }

        // DELETE: api/Contracts/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var deleteContract = _context.Contracts.FirstOrDefault(x => x.Id == id);
            // If not found Contract
            if (deleteContract == null)
            {
                return NotFound("Contract not found!");
            }

            _context.Contracts.Remove(deleteContract);
            _context.SaveChanges();

            return Ok("Delete successfully!");
        }
    }
}
