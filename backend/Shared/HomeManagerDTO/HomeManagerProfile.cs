using AutoMapper;
using Entities.Models;

namespace Shared.HomeManagerDTO.HomeManagerDTO
{
    public class HomeManagerProfile : Profile
    {
        public HomeManagerProfile()
        {
            CreateMap<CreateHomeManagerDTO, HomeManager>();
        }
    }
}
