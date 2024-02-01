using AutoMapper;
using Backend.DTOs.RequestDTO;
using Backend.Models;

namespace Backend.DTOs.RoomDTO
{
    public class RoomProfile : Profile
    {
        public RoomProfile() {
            CreateMap<CreateRoomDTO, Room>();
        }
    }
}
