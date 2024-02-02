using Backend.DTOs;
using Backend.Models;
using Backend.Utils;
<<<<<<< HEAD
using AutoMapper;
using Backend.DTOs;
=======
using Microsoft.AspNetCore.Mvc;
>>>>>>> e8f06e7b9f74fe2e2f025c103fa96f53832f755a

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

<<<<<<< HEAD
        // GET: api/BillStatus
        [HttpGet("{id}")]
        public ActionResult<BillStatus> Get(int id)
        {
            BillStatus? billStatus = _context.BillStatuses.FirstOrDefault(b => b.Id == id);
            if (billStatus == null)
            {
                return NotFound("Bill Status Not Found");
            }
            return Ok(billStatus);
        }

=======
>>>>>>> e8f06e7b9f74fe2e2f025c103fa96f53832f755a
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
<<<<<<< HEAD
        public ActionResult Update(BillStatus billStatus)
        {
            try { }
        }
        //PUT: api/BillStatus/id
        [HttpPut("{id}")]

=======

        // DELETE: api/BillStatus/{id} 
>>>>>>> e8f06e7b9f74fe2e2f025c103fa96f53832f755a
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
