using AutoMapper;
using Backend.DTOs.RequestTypeDTO;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 * Controller handling operations related to Request Types.
 * Provides endpoints to CRUD Request Types.
 * 
 * @author PhuVD
 */

namespace Backend.Controllers
{
    // Inject service
    [ApiController]
    [Route("api/[controller]")]
    public class RequestTypesController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public RequestTypesController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        // GET: api/RequestTypes
        [HttpGet]
        public ActionResult<IEnumerable<RequestType>> Get()
        {
            return Ok(_context.RequestTypes.ToList());
        }

        // GET: api/RequestTypes/{id}
        [HttpGet("{id}")]
        public ActionResult<RequestType> Get(int id)
        {
            RequestType? requestType = _context.RequestTypes.FirstOrDefault(x => x.Id == id);

            if (requestType == null)
            {
                return NotFound("Request type not found!");
            }

            return Ok(requestType);
        }

        // POST: api/RequestTypes
        [HttpPost]
        public ActionResult<RequestType> Post(CreateRequestTypeDTO requestTypeDTO)
        {
            try
            {
                RequestType requestType = _mapper.Map<RequestType>(requestTypeDTO);

                _context.RequestTypes.Add(requestType);

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
        public IActionResult Update(int id, UpdateRequestTypeDTO requestTypeUpdateDTO)
        {
            // Check if Id is correct
            if (id != requestTypeUpdateDTO.Id)
            {
                return BadRequest();
            }

            // Find in Database object with id 
            RequestType requestType = _context.RequestTypes.FirstOrDefault(rt => rt.Id == id);

            // Not found will return 404
            if (requestType == null)
            {
                return NotFound("Request type not found!");
            }

            // Map DTO to model class
            _mapper.Map(requestTypeUpdateDTO, requestType);

            _context.Entry(requestType).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok("Update successfully!");
        }

        // DELETE: api/RequestTypes/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleteRequestType = _context.RequestTypes.FirstOrDefault(r => r.Id == id);
            // If not found Request Type
            if (deleteRequestType == null)
            {
                return NotFound("Request type not found!");
            }

            _context.RequestTypes.Remove(deleteRequestType);
            _context.SaveChanges();

            return Ok("Delete successfully!");
        }
    }
}