using AutoMapper;
using Backend.DTOs.BillStatusDTO;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 * Controller handling operations related to Bill Statuses.
 * Provides endpoints to CRUD Bill Status.
 * 
 * @author HungNN
 */

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillStatusController : ControllerBase
    {
        // Inject service
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public BillStatusController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/BillStatus
        [HttpGet]
        public ActionResult<IEnumerable<BillStatus>> Get()
        {
            return Ok(_context.BillStatuses.ToList());
        }

        // GET: api/BillStatus/id
        [HttpGet("{id}")]
        public ActionResult<BillStatus> Get(int id)
        {

            BillStatus? billStatus = _context.BillStatuses.FirstOrDefault(x => x.Id == id);

            if (billStatus == null)
            {
                return NotFound("Bill Status not found!");
            }

            return Ok(billStatus);
        }

        // POST: api/BillStatus
        [HttpPost]
        public ActionResult Post(CreateBillStatusDTO billStatusDTO)
        {
            try
            {
                BillStatus billStatus = _mapper.Map<BillStatus>(billStatusDTO);

                _context.BillStatuses.Add(billStatus);

                _context.SaveChanges();

                return Ok("Save successfully !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/BillStatus/id
        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateBillStatusDTO billStatusUpdateDTO)
        {
            // Check if Id is correct
            if (id != billStatusUpdateDTO.Id)
            {
                return BadRequest();
            }

            // Find in Database object with id 
            BillStatus? billStatus = _context.BillStatuses.FirstOrDefault(bs => bs.Id == id);

            // Not found will return 404
            if (billStatus == null)
            {
                return NotFound("Bill Status not found!");
            }

            // Map DTO to model class
            _mapper.Map(billStatusUpdateDTO, billStatus);

            _context.Entry(billStatus).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok("Update successfully!");
        }

        // DELETE: api/BillStatus/{id} 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleteBillStatus = _context.BillStatuses.FirstOrDefault(b => b.Id == id);

            // If not found Bill Status
            if (deleteBillStatus == null)
            {
                return NotFound("Bill status not found!");
            }

            _context.BillStatuses.Remove(deleteBillStatus);
            _context.SaveChanges();

            return Ok("Deleted successfully!");
        }
    }
}
