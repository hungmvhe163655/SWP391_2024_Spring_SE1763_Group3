using Backend.DTOs;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Mvc;

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

        public BillStatusController(HomeManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/BillStatus
        [HttpGet]
        public ActionResult<IEnumerable<BillStatus>> Get()
        {
            return Ok(_context.BillStatuses.ToList());
        }

        // POST: api/BillStatus
        [HttpPost]
        public ActionResult Post(CreateBillStatusDTO billStatusDTO)
        {
            try
            {
                BillStatus billStatus = new()
                {
                    Status = billStatusDTO.Status
                };
                _context.BillStatuses.Add(billStatus);
                _context.SaveChanges();
                return Ok("Save successfully !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
