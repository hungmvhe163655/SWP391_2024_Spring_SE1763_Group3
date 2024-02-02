using Backend.DTOs;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestStatusController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;

        public RequestStatusController(HomeManagementDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<RequestStatus>> Get()
        {
            return Ok(_context.RequestStatuses.ToList());
        }
        [HttpPost]
        public ActionResult Post(CreateRequestStatusDTO requestStatusPost)
        {
            try
            {
                RequestStatus requestStatus = new()
                {
                    Status = requestStatusPost.Status
                };
                _context.RequestStatuses.Add(requestStatus);
                _context.SaveChanges();
                return Ok("Save Successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var requestStatusToDelete = _context.RequestStatuses.FirstOrDefault(x => x.Id == id);
                if (requestStatusToDelete == null)
                {
                    return NotFound("Request status not found.");
                }

                _context.RequestStatuses.Remove(requestStatusToDelete);
                _context.SaveChanges();

                return Ok("Delete Successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
