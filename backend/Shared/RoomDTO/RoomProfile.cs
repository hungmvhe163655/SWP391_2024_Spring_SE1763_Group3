using AutoMapper;
using Entities.Models;

namespace Shared.RoomDTO
{
    public class RoomProfile : Profile
    {
        public RoomProfile() {
            CreateMap<CreateRoomDTO, Room>();
        }
    }
}
