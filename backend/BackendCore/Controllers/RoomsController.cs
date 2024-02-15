using AutoMapper;
using BackendCore.Utils.ActionFilters;
using BackendCore.Utils.RequestFeatures.Paging;
using BackendCore.Utils;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Shared.NotificationDTO;
using Shared.RoomDTO;
using BackendCore.Utils.RequestFeatures.EntityParameters;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Entities.Exceptions;

namespace BackendCore.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    [ResponseCache(CacheProfileName = "120SecondsDuration")]
    public class RoomsController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public RoomsController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms(
            [FromQuery] RoomParameter roomParameters)
        {

            var queryRoom = BuildQuery(_context.Rooms, roomParameters);

            var pagedRoom = await PagedList<Room>.ToPagedListAsync(queryRoom,
                roomParameters.PageNumber, roomParameters.PageSize);

            var roomsDTO = _mapper.Map<IEnumerable<ReadRoomDTO>>(pagedRoom);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagedRoom.MetaData));

            return Ok(roomsDTO);
        }

        private IQueryable<Room> BuildQuery(DbSet<Room> rooms, RoomParameter roomParameters)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:guid}", Name = "RoomById")]
        public async Task<IActionResult> GetRoom(Guid id)
        {
            var room = await FindRoom(id);

            var roomDTO = _mapper.Map<ReadRoomDTO>(room);

            return Ok(roomDTO);
        }

        //[HttpPost]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        //public async Task<IActionResult> CreateRoom(
        //    [FromBody] CreateRoomDTO createRoomDTO)
        //{
        //    var createRoom = _mapper.Map<Room>(createRoomDTO);

        //    await _context.Rooms.AddAsync(createRoom);
        //    await _context.SaveChangesAsync();

        //    var createdRoom = _mapper.Map<ReadRoomDTO>(createRoom);

        //    return CreatedAtRoute("RoomById", new { id = createdRoom.Id }, createdRoom);
        //}

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateRoom(Guid id,
            [FromBody] UpdateRoomDTO updateRoomDTO)
        {
            var room = await FindRoom(id);

            _mapper.Map(updateRoomDTO, room);
            await _context.SaveChangesAsync();

            return Ok("Update successful!");
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateRoom(Guid id,
            [FromBody] JsonPatchDocument<UpdateRoomDTO> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("patchDoc object is null.");
            }

            var room = await FindRoom(id);

            var roomToPatch = _mapper.Map<UpdateRoomDTO>(room);

            patchDoc.ApplyTo(roomToPatch, ModelState);

            TryValidateModel(roomToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _mapper.Map(roomToPatch, room);
            await _context.SaveChangesAsync();

            return Ok("Partially update successful!");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            var deleteRoom = await FindRoom(id);

            _context.Rooms.Remove(deleteRoom);
            await _context.SaveChangesAsync();

            return Ok("Delete successful!");
        }

        

        private async Task<Room> FindRoom(Guid id)
            => await _context.Rooms.FindAsync(id)
             ?? throw new RoomNotFoundException(id);
    }
}
