using AutoMapper;
using Backend.Models;

namespace Backend.DTOs.HomeManagerDTO.HomeManagerDTO
{
    public class HomeManagerProfile : Profile
    {
        public HomeManagerProfile()
        {
            CreateMap<CreateHomeManagerDTO, HomeManager>();
        }
    }
}
