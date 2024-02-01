using AutoMapper;
using Backend.DTOs.BillStatusDTO;
using Backend.DTOs.RoomDTO;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 * Controller handling operations related to Rooms.
 * Provides endpoints to CRUD Room.
 * 
 * @author LongNCB
 */

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public RoomController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Room
        [HttpGet]
        public ActionResult<IEnumerable<Room>> Get()
        {
            return Ok(_context.Rooms.ToList());
        }

        // GET: api/Room/id
        [HttpGet("{id}")]
        public ActionResult<Room> Get(Guid id)
        {

            Room? room = _context.Rooms.FirstOrDefault(x => x.Id == id);

            if (room == null)
            {
                return NotFound(" Room not found!");
            }

            return Ok(room);
        }
        [HttpPost]
        public ActionResult Post(CreateRoomDTO roomDTO)
        {
            try
            {
                Room room = _mapper.Map<Room>(roomDTO);

                _context.Rooms.Add(room);

                _context.SaveChanges();

                return Ok("Save successfully !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT: api/Room/id
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, UpdateRoomDTO roomUpdateDTO)
        {
            // Check if Id is correct
            if (id != roomUpdateDTO.Id)
            {
                return BadRequest();
            }

            // Find in Database object with id 
            Room? room = _context.Rooms.FirstOrDefault(r => r.Id == id);

            // Not found will return 404
            if (room == null)
            {
                return NotFound(" Room not found!");
            }

            // Map DTO to model class
            _mapper.Map(roomUpdateDTO, room);

            _context.Entry(room).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok("Update successfully!");
        }

        // DELETE: api/Room/{id} 
        [HttpDelete("{id}")] 
        public ActionResult Delete(Guid id)
        {
            var deleteRoom = _context.Rooms.FirstOrDefault(r => r.Id == id);

            // If not found Room
            if (deleteRoom == null)
            {
                return NotFound("Room not found!");
            }

            _context.Rooms.Remove(deleteRoom);
            _context.SaveChanges();

            return Ok("Deleted successfully!");
        }

    }
}
