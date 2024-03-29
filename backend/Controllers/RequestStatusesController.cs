using AutoMapper;
using Backend.DTOs.RequestStatusDTO;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 * Controller handling operations related to Request Statuses.
 * Provides endpoints to CRUD Request Status.
 * 
 * @author LongNCB
 */

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestStatusesController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public RequestStatusesController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/RequestStatus
        [HttpGet]
        public ActionResult<IEnumerable<RequestStatus>> Get()
        {
            return Ok(_context.RequestStatuses.ToList());
        }

        // GET: api/RequestStatus/id
        [HttpGet("{id}")]
        public ActionResult<RequestStatus> Get(int id)
        {

            RequestStatus? requestlStatus = _context.RequestStatuses.FirstOrDefault(x => x.Id == id);

            if (requestlStatus == null)
            {
                return NotFound("Request Status not found!");
            }

            return Ok(requestlStatus);
        }

        // POST: api/RequestStatus
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

        // DELETE: api/RequestStatus/id
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

        // PUT: api/RequestStatus/id
        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateRequestStatusDTO requestStatusUpdateDTO)
        {
            // Check Id
            if(id != requestStatusUpdateDTO.Id)
            {
                return BadRequest();
            }
            RequestStatus? requestStatus = _context.RequestStatuses.FirstOrDefault(rs => rs.Id == id);

            // Not found will return 404
            if (requestStatus == null)
            {
                return NotFound("Request Status not found!");
            }

            // Map DTO to model class
            _mapper.Map(requestStatusUpdateDTO, requestStatus);

            _context.Entry(requestStatus).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok("Update successfully!");
        }
    }
}
