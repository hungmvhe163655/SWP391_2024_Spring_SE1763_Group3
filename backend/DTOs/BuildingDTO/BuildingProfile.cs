using AutoMapper;
using Backend.Models;

namespace Backend.DTOs.BuildingDTO
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<CreateBuildingDTO, Building>();
        }
    }
}
